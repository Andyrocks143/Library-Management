using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.Odbc;
using System.Data.SqlClient;

namespace lib
{
    public partial class LogIn : Form
    {
       public string myConnection = "Dsn=LibraryDB;UID=admin",tname,l;
       public static string tpass;
        public LogIn()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Registration a = new Registration();
            a.Show();
            this.Hide();


        }

        private void button1_Click(object sender, EventArgs e)
        {
            ChangePassword c = new ChangePassword();
            User ab = new User();
            string name = textBox1.Text, pass = textBox2.Text;
            // connection
            try
            {
                int param = 3;
                OdbcConnection myConn = new OdbcConnection(myConnection);
                string myQuery = "SELECT Username,Password FROM User WHERE Username='" + textBox1.Text + "';";
                OdbcCommand myOdbcCommand = new OdbcCommand(myQuery,myConn);
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
                    tpass = reader[1].ToString();
                }
                if (textBox1.Text == "Julian" && textBox2.Text == "123")
                {
                    ab.Show();
                    this.Hide();
                    String g = textBox1.Text;
                    MessageBox.Show("Welcome Admin!");
                    ab.add(g);
                   
                    //tpass = textBox2.Text;
                   
                    
                }
                else if (name == tname && pass == tpass)
                {
                    MessageBox.Show("Matched");
                    ab.Show();
                    this.Hide();
                    String g = textBox1.Text;
                    ab.add(g);
                    ab.normal_User();
                   
                   
                }
                else
                {
                    MessageBox.Show("Invalid User");
                }

               
                reader.Close();

                myOdbcCommand.Connection.Close();

            }
            catch (Exception ad)
            {
                MessageBox.Show(ad.Message + "Not done succesfully\n");

                //connection over
               
            }
             
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
       
    }
}
