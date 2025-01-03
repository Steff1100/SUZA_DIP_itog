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
    public partial class SUZA_ZAP_DOB : Form
    {
        private SqlConnection sqlConnection = null;

        public SUZA_ZAP_DOB()
        {
            InitializeComponent();
        }

        private void SUZA_ZAP_DOB_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString);

            sqlConnection.Open();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            SUZA_ZAPHAST sUZA_ZAPHAST = new SUZA_ZAPHAST();
            sUZA_ZAPHAST.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                $"INSERT INTO [SUZA_BD_ZAPH] (zaph_name, zaph_marka, zaph_stoy, zaph_koli) VALUES (N'{textBox3.Text}', N'{textBox1.Text}', N'{textBox2.Text}', N'{textBox4.Text}')", sqlConnection);
            MessageBox.Show("Запчасть успешно добавленна", command.ExecuteNonQuery().ToString());
            this.Close();
        }
    }
}
