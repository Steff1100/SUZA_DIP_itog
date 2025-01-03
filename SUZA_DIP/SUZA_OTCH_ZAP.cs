using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SUZA_DIP
{
    public partial class SUZA_OTCH_ZAP : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;
        private int num;
        private string str;

        public SUZA_OTCH_ZAP()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT spis_Id, spis_zap, spis_data, spis_mol, spis_kol  FROM SUZA_BD_SPIS", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "SUZA_BD_SPIS");

                dataGridView1.DataSource = dataSet.Tables["SUZA_BD_SPIS"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Подключение к базе данных с использованием MultipleActiveResultSets
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString + ";MultipleActiveResultSets=True"))
            {
                connection.Open();

                string query = "SELECT zaph_name, zaph_stoy FROM SUZA_BD_ZAPH";
                int summ = 0;

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Выполнение запроса
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Чтение данных
                        while (reader.Read())
                        {
                            // Получение значений из столбцов
                            string zaphName = reader["zaph_name"].ToString(); // Значение столбца zaph_name
                            int zaphStoy = reader.GetInt32(reader.GetOrdinal("zaph_stoy")); // Значение столбца zaph_stoy

                            // Запрос для получения количества по zaphName
                            int totalQuantity = 0;
                            string query2 = "SELECT SUM(spis_kol) FROM SUZA_BD_SPIS WHERE spis_zap = @zaphName";

                            using (SqlCommand command2 = new SqlCommand(query2, connection))
                            {
                                command2.Parameters.AddWithValue("@zaphName", zaphName);

                                // Выполнение второго запроса и получение суммы
                                object result = command2.ExecuteScalar();
                                if (result != DBNull.Value)
                                {
                                    totalQuantity = Convert.ToInt32(result);
                                }
                            }

                            // Умножение стоимости на количество
                            summ += (zaphStoy * totalQuantity);

                            // Выводим имя и стоимость
                            //MessageBox.Show($"Имя: {zaphName}, Стоимость: {zaphStoy}, Количество: {totalQuantity}"); 
                            //MessageBox.Show($"Текущая сумма: {summ}");
                        }
                    }
                }
                str = $"Стоимость списанных запчастей: {summ} рублей";
                label3.Text = str;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string connectionString = "Data Source=your_server;Initial Catalog=SUZA_DB;Integrated Security=True;"; // Ваша строка подключения
            string filePath = "OtchZapch.txt"; // Путь к текстовому файлу

            try
            {
                // Получаем данные из базы данных
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT spis_zap, spis_data, spis_mol, spis_kol   FROM SUZA_BD_SPIS"; // Ваш SQL-запрос

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Открываем StreamWriter для записи данных в файл
                        using (StreamWriter writer = new StreamWriter(filePath))
                        {
                            // Читаем данные построчно
                            while (reader.Read())
                            {
                                string zaphName = reader["spis_zap"].ToString();
                                string zaphData = reader["spis_data"].ToString();
                                string zaphMol = reader["spis_mol"].ToString();
                                int zaphkol = reader.GetInt32(reader.GetOrdinal("spis_kol"));

                                // Записываем данные в файл
                                writer.WriteLine($"Название: {zaphName}, Дата: {zaphData}, МОЛ: {zaphMol} Количество: {zaphkol}");
                            }
                        }
                    }
                }

                // Добавляем строку в конец файла
                using (StreamWriter writer = new StreamWriter(filePath, true)) // 'true' для добавления в конец файла
                {
                    writer.WriteLine($"{str}"); // Здесь добавляем необходимую строку
                }

                MessageBox.Show("Данные успешно выгружены в файл", "Успех",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            this.Close();
        }

        private void SUZA_OTCH_ZAP_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString);

            sqlConnection.Open();

            LoadData();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            SUZA_OTCHET form = new SUZA_OTCHET();
            form.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
