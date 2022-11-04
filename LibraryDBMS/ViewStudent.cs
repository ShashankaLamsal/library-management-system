using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryDBMS
{
    public partial class ViewStudent : Form
    {
        public ViewStudent()
        {
            InitializeComponent();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        int sid;
        Int64 rowid;

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                sid = int.Parse(dataGridView2.Rows[e.RowIndex].Cells[0].Value.ToString());
            }

            panel2.Visible = true;
            panel3.Visible = true;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=LAPTOP-E80CA2K5; database = LibraryDB; integrated security='True'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from newStudent where sid=" + sid + "";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            rowid = Int64.Parse(ds.Tables[0].Rows[0][0].ToString());

            txtSName.Text = ds.Tables[0].Rows[0][1].ToString();
            txtRoll.Text = ds.Tables[0].Rows[0][2].ToString();
            txtDepartment.Text = ds.Tables[0].Rows[0][3].ToString();
            txtSemester.Text = ds.Tables[0].Rows[0][4].ToString();
            txtContact.Text = ds.Tables[0].Rows[0][5].ToString();
        }

        private void ViewStudent_Load(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=LAPTOP-E80CA2K5; database = LibraryDB; integrated security='True'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from newStudent";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView2.DataSource = ds.Tables[0];
        }

        private void txtStudentSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtStudentSearch.Text != "")
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=LAPTOP-E80CA2K5; database = LibraryDB; integrated security='True'";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from newStudent where sroll LIKE '" + txtStudentSearch.Text + "%'";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView2.DataSource = ds.Tables[0];

            }
            else
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=LAPTOP-E80CA2K5; database = LibraryDB; integrated security='True'";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "select * from newStudent";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                dataGridView2.DataSource = ds.Tables[0];
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtStudentSearch.Clear();
            panel2.Visible = false;
            panel3.Visible = false;

            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=LAPTOP-E80CA2K5; database = LibraryDB; integrated security='True'";
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from newStudent";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            dataGridView2.DataSource = ds.Tables[0];
        }

        private void txtContact_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("The data will be updated. Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                string sName = txtSName.Text;
                string sRoll = txtRoll.Text;
                string sDepart = txtDepartment.Text;
                string sSem = txtSemester.Text;
                Int64 sCont = Int64.Parse(txtContact.Text);

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=LAPTOP-E80CA2K5; database = LibraryDB; integrated security='True'";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "update newStudent set sName ='" + sName + "', sRoll ='" + sRoll+ "', sDepart='" + sDepart + "',sSem='" + sSem + "', sCont =" + sCont + " where sid=" + rowid + " ";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewStudent_Load(this, null);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panel2.Visible = false;
            panel3.Visible = false;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("The data will be deleted. Are you sure?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {

                SqlConnection con = new SqlConnection();
                con.ConnectionString = "data source=LAPTOP-E80CA2K5; database = LibraryDB; integrated security='True'";
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                cmd.CommandText = "delete from newStudent where sid=" + rowid + "";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataSet ds = new DataSet();
                da.Fill(ds);

                ViewStudent_Load(this, null);
            }
        }
    }
}
