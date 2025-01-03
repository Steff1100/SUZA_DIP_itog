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
    public partial class SUZA_OTCH_AUT : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;
        private int summ = 0;
        private string str;
        decimal totalSum = 0;

        public SUZA_OTCH_AUT()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT obsl_avto, obsl_vid, obsl_stoy FROM SUZA_BD_OBSL", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);
                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "SUZA_BD_OBSL");

                dataGridView1.DataSource = dataSet.Tables["SUZA_BD_OBSL"];
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

                try
                {
                    using (SqlConnection connection2 = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString))
                    {
                        connection2.Open();
                        string query2 = "SELECT SUM(obsl_stoy) FROM SUZA_BD_OBSL"; // SQL запрос для получения суммы

                        using (SqlCommand command = new SqlCommand(query2, connection2))
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

                str = $"Общая сумма затрат: {summ + totalSum * 15}";
                label3.Text = str;
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
            // Печать
        }

        private void SUZA_OTCH_AUT_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString);

            sqlConnection.Open();

            LoadData();
        }
    }
}
