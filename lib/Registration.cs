using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;

namespace lib
{
    public partial class Registration : Form
    {
        string myConnection = "Dsn=LibraryDB;UID=admin";
        public Registration()
        {
            InitializeComponent();
        }

        //clear function
        public void Clear_func()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogIn a = new LogIn();
            a.Show();
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == textBox3.Text)
            {
                try
                {
                    OdbcConnection myConn = new OdbcConnection(myConnection);
                    string myInsertQuery = "INSERT INTO User(ID,Username,Password,eid,book) Values(" + textBox4.Text + ",'" + textBox1.Text + "','" + textBox2.Text + "','"+textBox5.Text+"','0');";
                    OdbcCommand myOdbcCommand = new OdbcCommand(myInsertQuery);
                    myOdbcCommand.Connection = myConn;
                    myConn.Open();
                    MessageBox.Show("connected");
                    myOdbcCommand.ExecuteNonQuery();
                    myOdbcCommand.Connection.Close();
                    MessageBox.Show("Added succesfully");
                    Clear_func();
                }
                catch (Exception ad)
                {
                    MessageBox.Show("Not added succesfully\n");
                    Console.WriteLine("An error occurred: '{0}'", ad);
                }
            }
            else
            {
                MessageBox.Show("Password doesnt match.");
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
