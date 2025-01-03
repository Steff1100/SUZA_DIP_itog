using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SUZA_DIP
{
    public partial class SUZA_OTCH_MOL : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;
        private int num;
        private string str;
        decimal totalSum = 0;

        public SUZA_OTCH_MOL()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT spis_Id, spis_mol, spis_data, spis_rab  FROM SUZA_BD_SPIS", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "SUZA_BD_SPIS");

                dataGridView1.DataSource = dataSet.Tables["SUZA_BD_SPIS"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT SUM(obsl_stoy) FROM SUZA_BD_OBSL"; // SQL запрос для получения суммы

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Выполняем запрос и получаем результат
                        object result = command.ExecuteScalar();
                        if (result != DBNull.Value)
                        {
                            totalSum = Convert.ToDecimal(result); // Преобразуем результат в decimal
                        }
                    }
                }

               // MessageBox.Show($"Сумма всех записей: {totalSum:F2}", "Результат", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            str = $"Стоимость затрат на обслуживание: {totalSum * 15} рублей";
            label3.Text = str;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string connectionString = "Data Source=your_server;Initial Catalog=SUZA_DB;Integrated Security=True;"; // Ваша строка подключения
            string filePath = "OtchetMOL.txt"; // Путь к текстовому файлу

            try
            {
                // Получаем данные из базы данных
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT spis_mol, spis_data, spis_rab FROM SUZA_BD_SPIS"; // Ваш SQL-запрос

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Открываем StreamWriter для записи данных в файл
                        using (StreamWriter writer = new StreamWriter(filePath))
                        {
                            // Читаем данные построчно
                            while (reader.Read())
                            {
                                string zaphName = reader["spis_mol"].ToString();
                                string zaphData = reader["spis_data"].ToString();
                                string zaphMol = reader["spis_rab"].ToString();
                               

                                // Записываем данные в файл
                                writer.WriteLine($" Мол: {zaphName}, Дата: {zaphData}, Вид работы {zaphMol}");
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

        private void SUZA_OTCH_MOL_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString);

            sqlConnection.Open();

            LoadData();
        }
    }
}
