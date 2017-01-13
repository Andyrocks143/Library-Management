using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace lib
{

    public partial class User : Form
    {
        public User()
        {
            InitializeComponent();
        }

        public void label1_Click(object sender, EventArgs e)
        {

        }

        public void add(String g)
        {
            label1.Text = "Welcome " + g;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogIn a = new LogIn();
            a.Show();
            this.Hide();
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
         
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {  
            //Change Password
            if (radioButton4.Checked)
            {
                ChangePassword a = new ChangePassword();
                a.Show();
                this.Hide();
            }
            //add or remove books
            if (radioButton3.Checked)
            {
                ManageBooks a = new ManageBooks();
                a.Show();
                this.Hide();
            }
         
        }

        public void normal_User()
        {
            radioButton3.Hide();
        }
    }
}
