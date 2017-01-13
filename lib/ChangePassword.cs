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
    public partial class ChangePassword : Form
    {
       public string myConnection = "Dsn=LibraryDB;UID=admin",tname,tpasss;

       public void extra(string temp)
       {
           try
           {
               int param = 5;
               OdbcConnection myConn = new OdbcConnection(myConnection);
               string myQuery = "SELECT Username,Password FROM User WHERE Username='" + temp + "';";
               OdbcCommand myOdbcCommand = new OdbcCommand(myQuery, myConn);
               myOdbcCommand.Parameters.AddWithValue("@pricePoint", param);
               myOdbcCommand.Connection = myConn;
               myConn.Open();
               MessageBox.Show("connected");
               //exec query
               OdbcDataReader reader = myOdbcCommand.ExecuteReader();
               while (reader.Read())
               {
                   // for testing
                   Console.WriteLine("\t{0}\t{1}",
                   reader[0], reader[1]);
                   tname = reader[0].ToString();
                   tpasss = reader[1].ToString();
               }
               MessageBox.Show(tpasss);
               reader.Close();

               myOdbcCommand.Connection.Close();

           }
           catch (Exception ad)
           {
               MessageBox.Show(ad.Message + "Not done succesfully\n");

               //connection over

           }
       }
        public ChangePassword()
        {
            InitializeComponent();
            //temp
            
            //end temp
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        

        private void button1_Click(object sender, EventArgs e)
        {
            LogIn t = new LogIn();
            ManageBooks m = new ManageBooks();
            // odbc
            extra(textBox1.Text);
            if (textBox2.Text == tpasss && textBox3.Text==textBox4.Text)
            {
                try
                {
                    OdbcConnection myConn = new OdbcConnection(myConnection);
                    string myInsertQuery = "UPDATE User SET Password='" + textBox3.Text + "' WHERE Username='" + textBox1.Text + "';";
                    OdbcCommand myOdbcCommand = new OdbcCommand(myInsertQuery);
                    myOdbcCommand.Connection = myConn;
                    myConn.Open();
                    MessageBox.Show("Connected");

                    myOdbcCommand.ExecuteNonQuery();
                    myOdbcCommand.Connection.Close();
                    MessageBox.Show("Updated succesfully");
                    m.Clear_func();
                }
                catch (Exception ad)
                {
                    MessageBox.Show("Not updated succesfully\n"+ad);
                   // Console.WriteLine("An error occurred: '{0}'", ad);
                }
                //end connec
            }
            else
            {
                MessageBox.Show("Old Password doesn't Match");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            LogIn a = new LogIn();
            a.Show();
            this.Hide();
        }

        public string tpass { get; set; }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }
    }
}
