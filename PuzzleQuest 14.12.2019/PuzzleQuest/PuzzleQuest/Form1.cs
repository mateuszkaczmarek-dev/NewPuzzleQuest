using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PuzzleQuest
{
    public partial class Autorzy : Form
    {
        public Autorzy()
        {
            InitializeComponent();
        }

        private void button1_wroc_Click(object sender, EventArgs e)
        {
            //wyjdz z okna O_Grze do Menu Glownego
            this.Hide();
            PuzzleQuest ss = new PuzzleQuest();
            ss.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
