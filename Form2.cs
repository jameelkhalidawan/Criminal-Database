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
namespace dbms_project
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            SqlConnection sqlcon = new SqlConnection(@"Data Source = MJK; Initial Catalog = criminaldata; Integrated Security = True");
            string query = "select*from login Where username ='" + textBox1.Text.Trim() + "'and password ='" + textBox2.Text.Trim() + "'";                 

            SqlDataAdapter sda = new SqlDataAdapter(query, sqlcon);
            DataTable dtbl = new DataTable(); 
       
            sda.Fill(dtbl);
            
            if (dtbl.Rows.Count == 1) 
             {
                Form1 objform1 = new Form1();
                this.Hide();
               objform1.Show();            

             } 
            else 
            {
               MessageBox.Show("Invalid Username or Password");



            }
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text== "Username")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;

            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if(textBox1.Text == "")
            {
                textBox1.Text = "Username";
                textBox1.ForeColor = Color.White;
            }
            
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Password")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
                textBox2.PasswordChar = '*';

            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Password";
                textBox2.ForeColor = Color.White;
                textBox2.PasswordChar = '\0';
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
