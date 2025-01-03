//using MySql.Data.MySqlClient;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SUZA_DIP
{
    public partial class SUZA_SPISANIE : Form
    {

        //private SqlConnection Connect = null;
        private SqlConnection sqlConnection = null;

        public SUZA_SPISANIE()
        {
            InitializeComponent();
            LoadDataIntoListBox();
        }

        private void SUZA_SPISANIE_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString);

            sqlConnection.Open();
        }

        private void LoadDataIntoListBox()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT zaph_name FROM SUZA_BD_ZAPH"; // Замените на ваш запрос
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    HashSet<string> uniqueItems = new HashSet<string>(); // Создаем HashSet для уникальных значений

                    while (reader.Read())
                    {
                        string item = reader["zaph_name"].ToString();
                        // Добавляем только уникальные значения
                        if (uniqueItems.Add(item)) // Add возвращает false, если элемент уже существует
                        {
                            comboBox4.Items.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }



            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT obsl_vid FROM SUZA_BD_OBSL"; // Замените на ваш запрос
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    HashSet<string> uniqueItems = new HashSet<string>(); // Используем HashSet для уникальности

                    while (reader.Read())
                    {
                        string item = reader["obsl_vid"].ToString();
                        // Добавляем в HashSet и проверяем успех добавления
                        if (uniqueItems.Add(item)) // Если item уже существует, метод Add вернет false
                        {
                            comboBox3.Items.Add(item);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }

                using (SqlConnection connectionSQL = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString))
                {
                    try
                    {
                        connectionSQL.Open();
                        string query = "SELECT nst_name FROM SUZA_BD_NST";
                        SqlCommand command = new SqlCommand(query, connectionSQL);
                        SqlDataReader reader = command.ExecuteReader();

                        HashSet<string> uniqueItemsNST = new HashSet<string>(); // Новый HashSet для уникальных значений nst_name

                        while (reader.Read())
                        {
                            string itemNST = reader["nst_name"].ToString();
                            // Добавляем в HashSet и проверяем успех добавления
                            if (uniqueItemsNST.Add(itemNST)) // Если itemNST уже существует, метод Add вернет false
                            {
                                comboBox1.Items.Add(itemNST);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка: " + ex.Message);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    string query = "INSERT INTO [SUZA_BD_SPIS] (spis_zap, spis_rab, spis_data, spis_mol, spis_kol) VALUES (@spis_zap, @spis_rab, @spis_data, @spis_mol, @spis_kol)";

                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        // Используем параметры для предотвращения SQL-инъекций
                        command.Parameters.AddWithValue("@spis_zap", comboBox4.Text);
                        command.Parameters.AddWithValue("@spis_rab", comboBox3.Text);
                        command.Parameters.AddWithValue("@spis_data", dateTimePicker1.Text);
                        command.Parameters.AddWithValue("@spis_mol", comboBox1.Text);
                        command.Parameters.AddWithValue("@spis_kol", numericUpDown1.Value);


                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show("Списание успешно добавлено.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }

            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    string query = $"UPDATE [SUZA_BD_ZAPH] SET zaph_koli = zaph_koli - {numericUpDown1.Value} WHERE zaph_name = @zaph_name"; // Замените Id на ваш идентификатор

                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        // Передаем идентификатор записи
                        command.Parameters.AddWithValue("@zaph_name", comboBox4.Text);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Значение успешно уменьшено");
                        }
                        else
                        {
                            MessageBox.Show("Запись не найдена или значение уже равно 0.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
