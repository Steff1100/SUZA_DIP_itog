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
    public partial class SUZA_AUT_DOB : Form
    {
        private SqlConnection sqlConnection = null;

        public SUZA_AUT_DOB()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SUZA_AUTO form = new SUZA_AUTO();
            form.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                $"INSERT INTO [SUZA_BD_AUTO] (auto_name, auto_ob, auto_reg) VALUES (N'{textBox1.Text}', N'{textBox3.Text}', N'{textBox2.Text}')", sqlConnection);
            MessageBox.Show("Авто успешно добавленно", command.ExecuteNonQuery().ToString());
            this.Close();
        }

        private void UMSZ_AUT_DOB_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString);

            sqlConnection.Open();

            label1.Parent = pictureBox1;

            label1.BackColor = Color.Transparent;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}
