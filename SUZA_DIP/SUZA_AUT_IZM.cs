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
    public partial class SUZA_AUT_IZM : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;
        private int num;

        public SUZA_AUT_IZM()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                //sqlDataAdapter = new SqlDataAdapter("SELECT auto_Id AS 'Номер', auto_name AS 'Авто', auto_ob AS 'Обьем', auto_reg AS 'Рег.Знак', N'Изменить' AS [Изменить] FROM SUZA_BD_AUTO", sqlConnection);
                sqlDataAdapter = new SqlDataAdapter("SELECT auto_Id, auto_name, auto_ob, auto_reg, N'Изменить' AS [Изменить] FROM SUZA_BD_AUTO", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "SUZA_BD_AUTO");

                dataGridView1.DataSource = dataSet.Tables["SUZA_BD_AUTO"];

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
                dataSet.Tables["SUZA_BD_AUTO"].Clear();

                sqlDataAdapter.Fill(dataSet, "SUZA_BD_AUTO");

                dataGridView1.DataSource = dataSet.Tables["SUZA_BD_AUTO"];

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

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            SUZA_AUTO form = new SUZA_AUTO();
            form.Show();
        }

        private void SUZA_AUT_IZM_Load(object sender, EventArgs e)
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

                    dataSet.Tables["SUZA_BD_AUTO"].Rows[rowIndex]["auto_name"] = dataGridView1.Rows[rowIndex].Cells["auto_name"].Value;
                    dataSet.Tables["SUZA_BD_AUTO"].Rows[rowIndex]["auto_ob"] = dataGridView1.Rows[rowIndex].Cells["auto_ob"].Value;
                    dataSet.Tables["SUZA_BD_AUTO"].Rows[rowIndex]["auto_reg"] = dataGridView1.Rows[rowIndex].Cells["auto_reg"].Value;
                   // dataSet.Tables["SUZA_BD_AUTO"].Rows[rowIndex]["auto_id_bd_zap"] = "Tru";

                    sqlDataAdapter.Update(dataSet, "SUZA_BD_AUTO");
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
