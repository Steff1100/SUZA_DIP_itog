using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.SqlClient;


namespace SUZA_DIP
{
    public partial class SUZA_AUTO : Form
    {
        private SqlConnection sqlConnection = null;

        public SUZA_AUTO()
        {
            InitializeComponent();
        }

        private void SUZA_AUTO_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString);

            sqlConnection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                "SELECT auto_Id, auto_name, auto_ob, auto_reg FROM SUZA_BD_AUTO" , sqlConnection);

            DataSet ds = new DataSet();

            dataAdapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SUZA_AUT_DOB form = new SUZA_AUT_DOB();
            form.Show();
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SUZA_AUT_IZM form = new SUZA_AUT_IZM();
            form.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SUZA_AUT_UDA form = new SUZA_AUT_UDA();
            form.Show();
            this.Close();
        }
    }
}
