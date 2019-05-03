using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiniProject
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 q = new Form1();
            this.Hide();
            q.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 w = new Form2();
            this.Hide();
            w.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form5 o = new Form5();
            this.Hide();
            o.Show();
        }
    }
}
