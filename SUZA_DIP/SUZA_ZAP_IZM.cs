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
    public partial class SUZA_ZAP_IZM : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;
        private int num;

        public SUZA_ZAP_IZM()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT zaph_Id, zaph_name, zaph_marka, zaph_stoy, zaph_koli, N'Изменить' AS [Изменить] FROM SUZA_BD_ZAPH", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "SUZA_BD_ZAPH");

                dataGridView1.DataSource = dataSet.Tables["SUZA_BD_ZAPH"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCCell = new DataGridViewLinkCell();
                    dataGridView1[5, i] = linkCCell;

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadData()
        {
            try
            {
                dataSet.Tables["SUZA_BD_ZAPH"].Clear();

                sqlDataAdapter.Fill(dataSet, "SUZA_BD_ZAPH");

                dataGridView1.DataSource = dataSet.Tables["SUZA_BD_ZAPH"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCCell = new DataGridViewLinkCell();
                    dataGridView1[5, i] = linkCCell;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            SUZA_ZAPHAST form = new SUZA_ZAPHAST();
            form.Show();
        }

        private void SUZA_ZAP_IZM_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString);

            sqlConnection.Open();

            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Изменить строку?", "Изменение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int rowIndex = e.RowIndex;

                    dataSet.Tables["SUZA_BD_ZAPH"].Rows[rowIndex]["zaph_name"] = dataGridView1.Rows[rowIndex].Cells["zaph_name"].Value;
                    dataSet.Tables["SUZA_BD_ZAPH"].Rows[rowIndex]["zaph_marka"] = dataGridView1.Rows[rowIndex].Cells["zaph_marka"].Value;
                    dataSet.Tables["SUZA_BD_ZAPH"].Rows[rowIndex]["zaph_stoy"] = dataGridView1.Rows[rowIndex].Cells["zaph_stoy"].Value;
                    dataSet.Tables["SUZA_BD_ZAPH"].Rows[rowIndex]["zaph_koli"] = dataGridView1.Rows[rowIndex].Cells["zaph_koli"].Value;
                    
                    sqlDataAdapter.Update(dataSet, "SUZA_BD_ZAPH");
                }

                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
