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
    public partial class SUZA_OBS_DOB : Form
    {
        private SqlConnection sqlConnection = null;


        public SUZA_OBS_DOB()
        {
            InitializeComponent();
            LoadDataIntoListBox();
        }

        private void LoadDataIntoListBox()
        {
            using (SqlConnection connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString))
            {
                try
                {
                    connection.Open();
                    string query = "SELECT auto_name FROM SUZA_BD_AUTO"; // Замените на ваш запрос
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    // Создаем HashSet для отслеживания уникальных названий
                    HashSet<string> uniqueAutoNames = new HashSet<string>();

                    while (reader.Read())
                    {
                        // Получаем название автомобиля
                        string autoName = reader["auto_name"].ToString();

                        // Проверяем, добавлено ли уже название
                        if (uniqueAutoNames.Add(autoName))
                        {
                            // Если название уникально, добавляем его в ComboBox
                            comboBox3.Items.Add(autoName);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }

        }

        private void SUZA_OBS_DOB_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString);

            sqlConnection.Open();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            SUZA_OBSLUGIVANIE form = new SUZA_OBSLUGIVANIE();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (SqlConnection sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString))
            {
                try
                {
                    sqlConnection.Open();
                    string query = "INSERT INTO [SUZA_BD_OBSL] (obsl_vid, obsl_avto, obsl_stoy) VALUES (@vid, @avto, @stoy)";

                    using (SqlCommand command = new SqlCommand(query, sqlConnection))
                    {
                        command.Parameters.AddWithValue("@vid", textBox1.Text);
                        command.Parameters.AddWithValue("@avto", comboBox3.Text);
                        command.Parameters.AddWithValue("@stoy", numericUpDown1.Value);

                        int rowsAffected = command.ExecuteNonQuery();
                        MessageBox.Show("Строка успешно добавлена.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }
            this.Close();
            SUZA_SPISANIE form = new SUZA_SPISANIE();
            form.Show();
        }
    }
}
