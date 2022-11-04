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
    public partial class AddStudent : Form
    {
        public AddStudent()
        {
            InitializeComponent();
        }

        private void AddStudent_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void txtAuthor_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtBookName_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void txtPublication_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtQuantity_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "" && txtDepartment.Text != "" && txtRoll.Text != "" && txtSemester.Text != "" && txtContact.Text!="")
            {
                string sname = txtName.Text;
                string sroll = txtRoll.Text;
                string sdepart = txtDepartment.Text;
                string ssem = txtSemester.Text;
                Int64 scont = Int64.Parse(txtContact.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=LAPTOP-E80CA2K5; database = LibraryDB; integrated security='True'";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                con.Open();
                cmd.CommandText = "insert into newStudent (sName,sRoll,sDepart,sSem,sCont) values ('" + sname + "','" + sroll + "','" + sdepart + "','"+ssem+"'," + scont + ")";
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Student Added Successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Clear();
                txtDepartment.Clear();
                txtRoll.Clear();
                txtSemester.Clear();
                txtContact.Clear();
            }
            else
            {
                MessageBox.Show("Please fill all the boxes.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Hand) == DialogResult.Yes)
            {

                this.Close();
            }
        }
    }
}
