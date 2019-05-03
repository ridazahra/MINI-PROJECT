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
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection("Server=.; Database=ProjectB; Integrated Security=True;");
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO RubricLevel (Id, RubricId, Details, MeasurementLevel) VALUES (@Id, @Rubric, @Details, @MeasurementLeve)", con);
                cmd.Parameters.AddWithValue("@Id", textBox1.Text);
                cmd.Parameters.AddWithValue("@Rubric", textBox2.Text);
                cmd.Parameters.AddWithValue("@Detils", textBox3.Text);
                cmd.Parameters.AddWithValue("@MeasurementLevel", textBox4.Text);

                SqlDataReader rdr = cmd.ExecuteReader();

                String conURL = "Server=.; Database=ProjectB; Integrated Security=True;";
                SqlConnection c = new SqlConnection(conURL);

                string s = "Select * FROM RubricLevel";
                SqlCommand CMD = new SqlCommand(s, c);

                //cmd.Parameters.Add(new SqlParameter("0", 1));
                SqlDataAdapter da = new SqlDataAdapter(s, c);
                DataSet d = new DataSet();
                c.Open();
                da.Fill(d, "RubricLeve");
                c.Close();
                dataGridView1.DataSource = d;
                dataGridView1.DataMember = "RubricLeve";
            }
        }

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet3.RubricLevel' table. You can move, or remove it, as needed.
            this.rubricLevelTableAdapter.Fill(this.projectBDataSet3.RubricLevel);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form4 p = new Form4();
            this.Hide();
            p.Show();
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
    }
}
