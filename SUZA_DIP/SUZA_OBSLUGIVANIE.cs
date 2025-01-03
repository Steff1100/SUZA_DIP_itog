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
    public partial class SUZA_OBSLUGIVANIE : Form
    {
        private SqlConnection sqlConnection = null;

        public SUZA_OBSLUGIVANIE()
        {
            InitializeComponent();
        }

        private void SUZA_OBSLUGIVANIE_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString);

            sqlConnection.Open();

            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                "SELECT obsl_Id, obsl_vid, obsl_avto, obsl_stoy FROM SUZA_BD_OBSL", sqlConnection);

            DataSet ds = new DataSet();

            dataAdapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            SUZA_OBS_DOB form = new SUZA_OBS_DOB();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            SUZA_OBS_IZM form = new SUZA_OBS_IZM();
            form.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            SUZA_OBS_UDA form = new SUZA_OBS_UDA();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
