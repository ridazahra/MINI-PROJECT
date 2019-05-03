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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void status_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void add_Click(object sender, EventArgs e)
        { 
            
            SqlConnection con = new SqlConnection("Server=.; Database=ProjectB; Integrated Security=True;");
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Student (FirstName, LastName, Contact, Email, RegistrationNumber, Status) VALUES (@FistName, @LastName, @Contact, @Email, @RegistrationNumber, @Status)", con);
                cmd.Parameters.AddWithValue("@FistName", textBox1.Text);
                cmd.Parameters.AddWithValue("@LastName", textBox2.Text);
                cmd.Parameters.AddWithValue("@Contact", textBox3.Text);
                cmd.Parameters.AddWithValue("@Email", textBox4.Text);
                cmd.Parameters.AddWithValue("@RegistrationNumber", textBox5.Text);
                cmd.Parameters.AddWithValue("@Status", Convert.ToInt32(textBox6.Text));
                SqlDataReader rdr = cmd.ExecuteReader();

                String conURL = "Server=.; Database=ProjectB; Integrated Security=True;";
                SqlConnection c = new SqlConnection(conURL);

                string s = "Select * FROM Student";
                SqlCommand CMD = new SqlCommand(s, c);

                //cmd.Parameters.Add(new SqlParameter("0", 1));
                SqlDataAdapter da = new SqlDataAdapter(s, c);
                DataSet d = new DataSet();
                c.Open();
                da.Fill(d, "Student");
                c.Close();
                dataGridView1.DataSource = d;
                dataGridView1.DataMember = "Student";
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            String conURL = "Server=.; Database=ProjectB; Integrated Security=True;";
            SqlConnection c = new SqlConnection(conURL);
            if(e.ColumnIndex==0)
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

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'projectBDataSet2.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter1.Fill(this.projectBDataSet2.Student);
            // TODO: This line of code loads data into the 'projectBDataSet.Student' table. You can move, or remove it, as needed.
            this.studentTableAdapter.Fill(this.projectBDataSet.Student);

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 E = new Form4();
            this.Hide();
            E.Show();

        }
    }
        }

    



