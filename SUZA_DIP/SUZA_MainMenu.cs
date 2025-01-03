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
    public partial class SUZA_MainMenu : Form
    {
        public SUZA_MainMenu()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SUZA_AUTO form = new SUZA_AUTO();
            form.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            SUZA_ZAPHAST form = new SUZA_ZAPHAST();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            SUZA_OBSLUGIVANIE form = new SUZA_OBSLUGIVANIE();
            form.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            SUZA_NASTROYKI sUZA_NASTROYKI = new SUZA_NASTROYKI();
            sUZA_NASTROYKI.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SUZA_SPISANIE form = new SUZA_SPISANIE();
            form.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            SUZA_OTCHET form = new SUZA_OTCHET();
            form.Show();
        }
    }
}
