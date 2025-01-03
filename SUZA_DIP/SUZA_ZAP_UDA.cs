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
    public partial class SUZA_ZAP_UDA : Form
    {
        private SqlCommandBuilder BD_sql_Builder = null;
        private SqlDataAdapter BD_sql_DataAdapter = null;
        private DataSet BD_dataSet = null;
        private SqlConnection BD_sql_Connection = null;
        private int num;
        private string secondColumnValue;

        public SUZA_ZAP_UDA()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            try
            {
                BD_sql_DataAdapter = new SqlDataAdapter("SELECT zaph_Id, zaph_name, zaph_marka, zaph_stoy, zaph_koli, N'Удалить' AS [Удалить] FROM SUZA_BD_ZAPH", BD_sql_Connection);
                BD_sql_Builder = new SqlCommandBuilder(BD_sql_DataAdapter);

                BD_sql_Builder.GetInsertCommand();
                BD_sql_Builder.GetUpdateCommand();
                BD_sql_Builder.GetDeleteCommand();

                BD_dataSet = new DataSet();
                BD_sql_DataAdapter.Fill(BD_dataSet, "SUZA_BD_ZAPH");

                dataGridView1.DataSource = BD_dataSet.Tables["SUZA_BD_ZAPH"];

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
                BD_dataSet.Tables["SUZA_BD_ZAPH"].Clear();

                BD_sql_DataAdapter.Fill(BD_dataSet, "SUZA_BD_ZAPH");

                dataGridView1.DataSource = BD_dataSet.Tables["SUZA_BD_ZAPH"];

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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Удалить запчасть?", "Удаление", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {

                    int rowIndex = e.RowIndex;

                    try
                    {
                        // Замените n на номер строки и m на номер столбца, начиная с 0
                        int n = rowIndex; // номер строки
                        int m = 2; // номер столбца

                        // Получаем значение из ячейки
                        var cellValue = dataGridView1.Rows[n].Cells[m].Value;
                        //secondColumnValue = "";
                        secondColumnValue = cellValue != null ? cellValue.ToString() : string.Empty;

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Ошибка: {ex.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    dataGridView1.Rows.RemoveAt(rowIndex);

                    BD_dataSet.Tables["SUZA_BD_ZAPH"].Rows[rowIndex].Delete();

                    BD_sql_DataAdapter.Update(BD_dataSet, "SUZA_BD_ZAPH");
                }

                ReloadData();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ОШИБКА!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SUZA_ZAP_UDA_Load(object sender, EventArgs e)
        {
            BD_sql_Connection = new SqlConnection(ConfigurationManager.ConnectionStrings["SUZA_DB"].ConnectionString);

            BD_sql_Connection.Open();

            LoadData();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            SUZA_ZAPHAST form = new SUZA_ZAPHAST();
            form.Show();
        }
    }
}
