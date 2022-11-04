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
    public partial class LoginPage : Form
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            con.ConnectionString = "data source=LAPTOP-E80CA2K5; database = LibraryDB; integrated security='True'" ;
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;

            cmd.CommandText = "select * from loginTable where username ='"+ textBox_Username.Text + "' and password ='"+ textBox_Password.Text + "'";
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            da.Fill(ds);

            if (ds.Tables[0].Rows.Count!=0)
            {
                this.Hide();
                MainMenu dsa = new MainMenu();
                dsa.Show();
            }
            else
            {
                MessageBox.Show("Wrong Username or Password","Error", MessageBoxButtons.OK,MessageBoxIcon.Error);
            }

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox_Username_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox_Username.Text == "Username")
            {
                textBox_Username.Clear();
            }
        }

        private void textBox_Password_MouseClick(object sender, MouseEventArgs e)
        {
            if (textBox_Password.Text == "Password")
            {
                textBox_Password.Clear();
                textBox_Password.PasswordChar = '*';
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }
    }
}
