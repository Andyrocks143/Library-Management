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
    public partial class ManageBooks : Form
    {
        string myConnection = "Dsn=LibraryDB;UID=admin"; 
          //dbq=D:\\VB PRO\\lib\\lib\\testdb.accdb;driverid=25;fil=MS Access;maxbuffersize=2048;pagetimeout=5;uid=admin";
        public ManageBooks()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            User a = new User();
            a.Show();
            this.Hide();
        }

        //clear function

        public void Clear_func()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OdbcConnection myConn = new OdbcConnection(myConnection);
                string myInsertQuery = "INSERT INTO Student(ISBN,Title,Edition,Author) Values(" + textBox1.Text + ",'" + textBox2.Text + "'," + textBox4.Text + ",'" + textBox3.Text + "')";
                OdbcCommand myOdbcCommand = new OdbcCommand(myInsertQuery);
                myOdbcCommand.Connection = myConn;
                myConn.Open();
                MessageBox.Show("connected");
                myOdbcCommand.ExecuteNonQuery();
                myOdbcCommand.Connection.Close();
                MessageBox.Show("Added succesfully");
                Clear_func();
            }
            catch(Exception ad)
            {
              MessageBox.Show("Not added succesfully\n");
              Console.WriteLine("An error occurred: '{0}'", ad);
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                OdbcConnection myConn = new OdbcConnection(myConnection);
                string myInsertQuery = "DELETE FROM Student WHERE ISBN="+textBox1.Text+";";
                OdbcCommand myOdbcCommand = new OdbcCommand(myInsertQuery);
                myOdbcCommand.Connection = myConn;
                myConn.Open();
                MessageBox.Show("Connected");
                myOdbcCommand.ExecuteNonQuery();
                myOdbcCommand.Connection.Close();
                MessageBox.Show("Removed succesfully");
                Clear_func();
            }
            catch (Exception ad)
            {
                MessageBox.Show("Not added succesfully\n");
                Console.WriteLine("An error occurred: '{0}'", ad);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OdbcConnection myConn = new OdbcConnection(myConnection);
                string myInsertQuery = "UPDATE Student SET ISBN="+textBox1.Text+",Title='"+textBox2.Text+"',Edition="+textBox4.Text+",Author='"+textBox3.Text+"' WHERE ISBN="+textBox1.Text+";";
                OdbcCommand myOdbcCommand = new OdbcCommand(myInsertQuery);
                myOdbcCommand.Connection = myConn;
                myConn.Open();
                MessageBox.Show("Connected");
                myOdbcCommand.ExecuteNonQuery();
                myOdbcCommand.Connection.Close();
                MessageBox.Show("Updated succesfully");
                Clear_func();
            }
            catch (Exception ad)
            {
                MessageBox.Show("Not added succesfully\n");
                Console.WriteLine("An error occurred: '{0}'", ad);
            }

        }
    }
}
