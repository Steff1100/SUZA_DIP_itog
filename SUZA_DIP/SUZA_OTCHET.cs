using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SUZA_DIP
{
    public partial class SUZA_OTCHET : Form
    {
        public SUZA_OTCHET()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
            SUZA_OTCH_ZAP form = new SUZA_OTCH_ZAP();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
            SUZA_OTCH_MOL form = new SUZA_OTCH_MOL();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            SUZA_OTCH_AUT form = new SUZA_OTCH_AUT();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            SUZA_OTCH_OBS form = new SUZA_OTCH_OBS();
            form.Show();
        }
    }
}
