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
    public partial class SUZA_NASTROYKI : Form
    {
        private SqlConnection sqlConnection = null;
        private SqlCommandBuilder sqlBuilder = null;
        private SqlDataAdapter sqlDataAdapter = null;
        private DataSet dataSet = null;
        private int num;
        private SqlCommandBuilder BD_sql_Builder = null;
        private SqlDataAdapter BD_sql_DataAdapter = null;
        private DataSet BD_dataSet = null;
        private SqlConnection BD_sql_Connection = null;
        private string secondColumnValue;

        public SUZA_NASTROYKI()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                sqlDataAdapter = new SqlDataAdapter("SELECT nst_Id, nst_name, N'Изменить' AS [Изменить] FROM SUZA_BD_NST", sqlConnection);
                sqlBuilder = new SqlCommandBuilder(sqlDataAdapter);

                sqlBuilder.GetInsertCommand();
                sqlBuilder.GetUpdateCommand();
                sqlBuilder.GetDeleteCommand();

                dataSet = new DataSet();
                sqlDataAdapter.Fill(dataSet, "SUZA_BD_NST");

                dataGridView1.DataSource = dataSet.Tables["SUZA_BD_NST"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCCell = new DataGridViewLinkCell();
                    dataGridView1[2, i] = linkCCell;

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
                dataSet.Tables["SUZA_BD_NST"].Clear();

                sqlDataAdapter.Fill(dataSet, "SUZA_BD_NST");

                dataGridView1.DataSource = dataSet.Tables["SUZA_BD_NST"];

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCCell = new DataGridViewLinkCell();
                    dataGridView1[2, i] = linkCCell;
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Изменить строку?", "Изменение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    int rowIndex = e.RowIndex;

                    dataSet.Tables["SUZA_BD_NST"].Rows[rowIndex]["nst_name"] = dataGridView1.Rows[rowIndex].Cells["nst_name"].Value;

                    sqlDataAdapter.Update(dataSet, "SUZA_BD_NST");
                }

                ReloadData();
                ReloadDataDell();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataDell()
        {
            try
            {
                BD_sql_DataAdapter = new SqlDataAdapter("SELECT nst_Id AS 'Номер', nst_name AS 'МОЛ', N'Удалить' AS [Удалить] FROM SUZA_BD_NST", BD_sql_Connection);
                BD_sql_Builder = new SqlCommandBuilder(BD_sql_DataAdapter);

                BD_sql_Builder.GetInsertCommand();
                BD_sql_Builder.GetUpdateCommand();
                BD_sql_Builder.GetDeleteCommand();

                BD_dataSet = new DataSet();
                BD_sql_DataAdapter.Fill(BD_dataSet, "SUZA_BD_NST");

                dataGridView2.DataSource = BD_dataSet.Tables["SUZA_BD_NST"];

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCCell = new DataGridViewLinkCell();
                    dataGridView2[2, i] = linkCCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ReloadDataDell()
        {
            try
            {
                BD_dataSet.Tables["SUZA_BD_NST"].Clear();

                BD_sql_DataAdapter.Fill(BD_dataSet, "SUZA_BD_NST");

                dataGridView2.DataSource = BD_dataSet.Tables["SUZA_BD_NST"];

                for (int i = 0; i < dataGridView2.Rows.Count; i++)
                {
                    DataGridViewLinkCell linkCCell = new DataGridViewLinkCell();
                    dataGridView2[2, i] = linkCCell;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SUZA_NASTROYKI_Load(object sender, EventArgs e)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString);

            sqlConnection.Open();

            BD_sql_Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString);

            BD_sql_Connection.Open();

            LoadData();
            LoadDataDell();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand(
                $"INSERT INTO [SUZA_BD_NST] (nst_name) VALUES (N'{textBox1.Text}')", sqlConnection);
            MessageBox.Show("Свойство успешно добавленно", command.ExecuteNonQuery().ToString());
            this.Close();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

            try
            {
                if (MessageBox.Show("Удалить запись?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    int rowIndex = e.RowIndex;

                    try
                    {
                        // Замените n на номер строки и m на номер столбца, начиная с 0
                        int n = rowIndex; // номер строки
                        int m = 2; // номер столбца

                        // Получаем значение из ячейки
                        var cellValue = dataGridView2.Rows[n].Cells[m].Value;
                        //secondColumnValue = "";
                        secondColumnValue = cellValue != null ? cellValue.ToString() : string.Empty;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    dataGridView2.Rows.RemoveAt(rowIndex);

                    BD_dataSet.Tables["SUZA_BD_NST"].Rows[rowIndex].Delete();

                    BD_sql_DataAdapter.Update(BD_dataSet, "SUZA_BD_NST");
                }

                ReloadData();
                ReloadDataDell();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
