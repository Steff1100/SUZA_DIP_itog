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
    public partial class SUZA_OTCH_OBS : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;
        private int num;
        private string str;
        decimal totalSum = 0;

        public SUZA_OTCH_OBS()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT obsl_Id, obsl_vid, obsl_avto, obsl_stoy FROM SUZA_BD_OBSL", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "SUZA_BD_OBSL");

                dataGridView1.DataSource = dataSet.Tables["SUZA_BD_OBSL"];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            decimal totalSum = 0;

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

                str = $"Суммарно затраченное время персонала: {totalSum} часов";
                label3.Text = str;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Произошла ошибка: " + ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
            SUZA_OTCHET form = new SUZA_OTCHET();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //string connectionString = "Data Source=your_server;Initial Catalog=SUZA_DB;Integrated Security=True;"; // Ваша строка подключения
            string filePath = "OtchObsl.txt"; // Путь к текстовому файлу

            try
            {
                // Получаем данные из базы данных
                using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT obsl_vid, obsl_avto, obsl_stoy FROM SUZA_BD_OBSL"; // Ваш SQL-запрос

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Открываем StreamWriter для записи данных в файл
                        using (StreamWriter writer = new StreamWriter(filePath))
                        {
                            // Читаем данные построчно
                            while (reader.Read())
                            {
                                string zaphName = reader["obsl_vid"].ToString();
                                string zaphData = reader["obsl_avto"].ToString();
                                int zaphkol = reader.GetInt32(reader.GetOrdinal("obsl_stoy"));

                                // Записываем данные в файл
                                writer.WriteLine($"Вид: {zaphName}, Авто: {zaphData}, Часы: {zaphkol}");
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

        private void SUZA_OTCH_OBS_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString);

            sqlConnection.Open();

            LoadData();
        }
    }
}
