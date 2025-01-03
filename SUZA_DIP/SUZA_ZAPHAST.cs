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
    public partial class SUZA_ZAPHAST : Form
    {
        private SqlConnection sqlConnection = null;

        public SUZA_ZAPHAST()
        {
            InitializeComponent();
        }

        private void SUZA_ZAPHAST_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString);

            sqlConnection.Open();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(
                "SELECT zaph_Id, zaph_name, zaph_marka, zaph_stoy, zaph_koli FROM SUZA_BD_ZAPH", sqlConnection);

            DataSet ds = new DataSet();

            dataAdapter.Fill(ds);

            dataGridView1.DataSource = ds.Tables[0];
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SUZA_ZAP_DOB form = new SUZA_ZAP_DOB();
            form.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SUZA_ZAP_IZM form = new SUZA_ZAP_IZM();
            form.Show();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SUZA_ZAP_UDA form = new SUZA_ZAP_UDA();
            form.Show();
            this.Close();
        }
    }
}
