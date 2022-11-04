using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryDBMS
{
    public partial class IssueBook : Form
    {
        public IssueBook()
        {
            InitializeComponent();
        }

        private void IssueBook_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=LAPTOP-E80CA2K5; database = LibraryDB; integrated security='True'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            con.Open();
            cmd= new SqlCommand("select bName from newBook",con);
            SqlDataReader sdr = cmd.ExecuteReader();

            while(sdr.Read())
            {
                for(int i = 0; i < sdr.FieldCount; i++)
                {
                    comboBox1.Items.Add(sdr.GetString(i));
                }
            }
            sdr.Close();
            con.Close();
        }

        int icount;
        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(txtRoll.Text!="")
            {
                string sroll = txtRoll.Text;

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=LAPTOP-E80CA2K5; database = LibraryDB; integrated security='True'";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from newStudent where sRoll='" + sroll + "'";
                SqlDataAdapter da= new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();

                da.Fill(ds);

                //To initialize if 3 books have been issued by the student

                cmd.CommandText = "select count(std_Roll) from IRBook where std_Roll='" + sroll + "' and book_return_date is null";
                SqlDataAdapter da1 = new SqlDataAdapter(cmd);
                DataSet ds1 = new DataSet();
                da1.Fill(ds1);

                icount= int.Parse(ds1.Tables[0].Rows[0][0].ToString());



                //To insert the data from roll no
                if (ds.Tables[0].Rows.Count!=0)
                {
                    txtName.Text= ds.Tables[0].Rows[0][1].ToString();
                    
                    txtDepartment.Text= ds.Tables[0].Rows[0][3].ToString();
                    txtSemester.Text= ds.Tables[0].Rows[0][4].ToString();
                    txtContact.Text= ds.Tables[0].Rows[0][5].ToString();
                }
                else
                {
                    txtName.Clear();
                    txtDepartment.Clear();
                    txtSemester.Clear();
                    txtContact.Clear();
                    MessageBox.Show("Invalid Roll Number","Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
                }

            }
        }

        private void btnIssue_Click(object sender, EventArgs e)
        {
            if (txtName.Text!="")
            {
                if (comboBox1.SelectedIndex != -1 && icount <= 2)
                { 
                    string std_roll = txtRoll.Text;
                    string std_name = txtName.Text;
                    string std_depart = txtDepartment.Text;
                    string std_sem= txtSemester.Text;
                    Int64 std_cont = Int64.Parse(txtContact.Text);
                    string book_name= comboBox1.Text;
                    string book_issue_date = dateTimePicker.Text;


                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = "data source=LAPTOP-E80CA2K5; database = LibraryDB; integrated security='True'";
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = con;

                    con.Open();
                    cmd.CommandText = "insert into IRBook(std_Roll, std_Name , std_Depart , std_Sem , std_Cont, book_name, book_issue_date) values('"+std_roll+"','"+std_name+"','"+std_depart+"','"+std_sem+"',"+std_cont+",'"+book_name+"','"+book_issue_date+"')";
                    cmd.ExecuteNonQuery();
                    con.Close();

                    MessageBox.Show("The book has been issued","Book Issued",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Please select a book or Maximum amount of books has been issued for the student.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please enter valid roll number.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtRoll_TextChanged(object sender, EventArgs e)
        {
            if(txtRoll.Text == "")
            {
                txtName.Clear();
                txtDepartment.Clear();
                txtSemester.Clear();
                txtContact.Clear();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtRoll.Clear();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Exit Issue Book", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
