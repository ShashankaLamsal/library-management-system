using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryDBMS
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void booksToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void aboutUsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to exit?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void viewBooksToolStripMenuItem_Click(object sender, EventArgs e) //add books
        {
            bool Isopen = false;

            foreach (Form f in Application.OpenForms)                           //to check whether addbooks form is already open or not
            {
                if(f.Text== "AddBook")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }

            if (Isopen == false)
            {
                AddBook abs = new AddBook();
                abs.Show();
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            bool Isopen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "AboutUs")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }

            if (Isopen == false)
            {
                AboutUs abu = new AboutUs();
                abu.Show();
            }
        }

        private void addStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "AddStudent")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }

            if (Isopen == false)
            {
                AddStudent ads = new AddStudent();
                ads.Show();
            }
        }

        private void MainMenu_Load(object sender, EventArgs e)
        {

        }

        private void viewBooksToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ViewBook vb = new ViewBook();
            vb.Show();
        }

        private void viewStudentsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            bool Isopen = false;

            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "AddStudent")
                {
                    Isopen = true;
                    f.BringToFront();
                    break;
                }
            }

            if (Isopen == false)
            {
                ViewStudent vs = new ViewStudent();
                vs.Show();
            }
        }

        private void issueBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            IssueBook ib = new IssueBook();
            ib.Show();
        }

        private void returnBookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReturnBook rb = new ReturnBook();
            rb.Show();
        }
    }
}
