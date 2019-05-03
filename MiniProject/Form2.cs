using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MiniProject
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection Con = new SqlConnection("Server=.; Database=ProjectB; Integrated Security=True;");
            {
                Con.Open();
                SqlCommand cod = new SqlCommand("INSERT INTO Clo (Name, DateCreated, DateUpdated) VALUES (@Name, @DateCreated, @DateUpdated)", Con);
                cod.Parameters.AddWithValue("@Name", textBox1.Text);
                cod.Parameters.AddWithValue("@DateCreated", textBox2.Text);
                cod.Parameters.AddWithValue("@DateUpdated", textBox3.Text);

                SqlDataReader Rdr = cod.ExecuteReader();
                String conURL = "Server=.; Database=ProjectB; Integrated Security=True;";
                SqlConnection C = new SqlConnection(conURL);

                string S = "Select * FROM Clo";
                SqlCommand Cod = new SqlCommand(S, C);

                //cmd.Parameters.Add(new SqlParameter("0", 1));
                SqlDataAdapter Da = new SqlDataAdapter(S, C);
                DataSet D = new DataSet();
                C.Open();

                Da.Fill(D, "Clo");
                C.Close();
                dataGridView1.DataSource = D;
                dataGridView1.DataMember = "Clo";

            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet1.Clo' table. You can move, or remove it, as needed.
            this.cloTableAdapter.Fill(this.projectBDataSet1.Clo);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            String conURL = "Server=.; Database=ProjectB; Integrated Security=True;";
            SqlConnection c = new SqlConnection(conURL);
            if (e.ColumnIndex == 0)
            {
                c.Open();
                this.dataGridView1.Rows.RemoveAt(e.ColumnIndex);
                String x = ("Selected item is Deleted");
                SqlCommand q = new SqlCommand(x, c);

                MessageBox.Show("Selected item is Deleted");
                String y = ("Select");
                SqlCommand w = new SqlCommand(y, c);
                c.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 r = new Form4();
            this.Hide();
            r.Show();
        }
    }
}
