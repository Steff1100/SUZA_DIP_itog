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
    public partial class SUZA_OBS_IZM : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;
        private int num;

        public SUZA_OBS_IZM()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT obsl_Id, obsl_vid, obsl_avto, obsl_stoy, N'Изменить' AS [Изменить] FROM SUZA_BD_OBSL", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "SUZA_BD_OBSL");

                dataGridView1.DataSource = dataSet.Tables["SUZA_BD_OBSL"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCCell = new DataGridViewLinkCell();
                    dataGridView1[4, i] = linkCCell;

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
                dataSet.Tables["SUZA_BD_OBSL"].Clear();

                sqlDataAdapter.Fill(dataSet, "SUZA_BD_OBSL");

                dataGridView1.DataSource = dataSet.Tables["SUZA_BD_OBSL"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCCell = new DataGridViewLinkCell();
                    dataGridView1[4, i] = linkCCell;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SUZA_OBS_IZM_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString);

            sqlConnection.Open();

            LoadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            SUZA_OBSLUGIVANIE sUZA_OBSLUGIVANIE = new SUZA_OBSLUGIVANIE();
            sUZA_OBSLUGIVANIE.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Изменить строку?", "Изменение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int rowIndex = e.RowIndex;

                    dataSet.Tables["SUZA_BD_OBSL"].Rows[rowIndex]["obsl_vid"] = dataGridView1.Rows[rowIndex].Cells["obsl_vid"].Value;
                    dataSet.Tables["SUZA_BD_OBSL"].Rows[rowIndex]["obsl_avto"] = dataGridView1.Rows[rowIndex].Cells["obsl_avto"].Value;
                    dataSet.Tables["SUZA_BD_OBSL"].Rows[rowIndex]["obsl_stoy"] = dataGridView1.Rows[rowIndex].Cells["obsl_stoy"].Value;
                    dataSet.Tables["SUZA_BD_OBSL"].Rows[rowIndex]["obsl_id_zap"] = dataGridView1.Rows[rowIndex].Cells["obsl_id_zap"].Value;

                    sqlDataAdapter.Update(dataSet, "SUZA_BD_OBSL");
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
