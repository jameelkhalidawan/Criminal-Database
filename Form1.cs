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
    public partial class Form1 : Form
    {
        Bitmap bitmap;
        public Form1()
        {
            InitializeComponent();
        }
        private void fetchdata()
        {
            string ConnectionString = "Data Source=MJK;Initial Catalog=criminaldata;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "SELECT * FROM data where CID = '" + IDtxt.Text + "'order by CID";
            SqlCommand cmd = new SqlCommand(query, con);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                NameTxt.Text = dr["Cname"].ToString();
                CNICTxt.Text = dr["CCNIC"].ToString();
                SecTxt.Text = dr["CSec"].ToString();
                CellTxt.Text = dr["CCellno"].ToString();
            }
            con.Close();
        }
        private void populate()
        {
            string ConnectionString = "Data Source=MJK;Initial Catalog=criminaldata;Integrated Security=True";
            SqlConnection con = new SqlConnection(ConnectionString);
            con.Open();
            string query = "SELECT * FROM data";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            SqlCommandBuilder builder = new SqlCommandBuilder(da);
            var ds = new DataSet();
            da.Fill(ds);
            criminaldata.DataSource = ds.Tables[0];
            con.Close();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult iExit;
            try
            {
                iExit = MessageBox.Show("Confirm if you want to Exit ", "MYSQL Connector",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (iExit == DialogResult.Yes)
                {
                    Application.Exit();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }






        }

        private void button3_Click(object sender, EventArgs e)
        {
             
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            try
            {
                int height = criminaldata.Height;
                criminaldata.Height = criminaldata.RowCount * criminaldata.RowTemplate.Height * 2;
                bitmap = new Bitmap(criminaldata.Width, criminaldata.Height);
                criminaldata.DrawToBitmap(bitmap, new Rectangle(0, 0, criminaldata.Width, criminaldata.Height));
                printPreviewDialog1.PrintPreviewControl.Zoom = 1;
                printPreviewDialog1.ShowDialog();
                criminaldata.Height = height;





            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);

            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                e.Graphics.DrawImage(bitmap, 0, 0);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string stringConnection = "Data Source=MJK;Initial Catalog=criminaldata;Integrated Security=True;";
            SqlConnection con = new SqlConnection(stringConnection);
            con.Open();
            try
            {
                string query = "INSERT INTO data VALUES('" + IDtxt.Text + "', '" + NameTxt.Text + "', '" + CNICTxt.Text + "', '" + SecTxt.Text + "', '" + CellTxt.Text + "')";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data entered successfully");
            }catch (Exception)
            {
                MessageBox.Show("Error");
            }
            con.Close();
            populate();
            resettt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                string stringConnection = "Data Source=MJK;Initial Catalog=criminaldata;Integrated Security=True;";
                SqlConnection con = new SqlConnection(stringConnection);
                con.Open();
                string query = "DELETE FROM data where CID = '" + IDtxt.Text + "';";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record deleted successfully.");
                con.Close();
                populate();
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
            }
            resettt();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            populate();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fetchdata();
        }

        private void criminaldata_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            string stringConnection = "Data Source=MJK;Initial Catalog=criminaldata;Integrated Security=True;";
            //update
            SqlConnection sqlcon1 = new SqlConnection(stringConnection);
            sqlcon1.Open();
            SqlCommand cmd1 = new SqlCommand("UPDATE data SET Cname=@name,CCNIC=@ccn,CSec=@cse,CCellno=@cell WHERE CID=@em", sqlcon1);
            cmd1.Parameters.AddWithValue("em", IDtxt.Text.ToString());
            cmd1.Parameters.AddWithValue("name", NameTxt.Text.ToString());
            cmd1.Parameters.AddWithValue("ccn", CNICTxt.Text.ToString());
            cmd1.Parameters.AddWithValue("cse", SecTxt.Text.ToString());
            cmd1.Parameters.AddWithValue("cell", CellTxt.Text.ToString());
            cmd1.ExecuteNonQuery();
            sqlcon1.Close();
            populate();
            resettt();

        }

        private void button7_Click(object sender, EventArgs e)
        {
            resettt();
        }
        private void resettt() 
        {
            IDtxt.Text = "";
            NameTxt.Text = "";
            CNICTxt.Text = "";
            SecTxt.Text = "";
            CellTxt.Text = "";



        }

        private void NameTxt_TextChanged(object sender, EventArgs e)
        {

        }

        private void criminaldata_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                IDtxt.Text = criminaldata.SelectedRows[0].Cells[0].Value.ToString();
                NameTxt.Text = criminaldata.SelectedRows[0].Cells[1].Value.ToString();
                CNICTxt.Text = criminaldata.SelectedRows[0].Cells[2].Value.ToString();
                SecTxt.Text = criminaldata.SelectedRows[0].Cells[3].Value.ToString();
                CellTxt.Text = criminaldata.SelectedRows[0].Cells[4].Value.ToString();

            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }
    }
    
}
