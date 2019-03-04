using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;
using MySql.Data.MySqlClient;

namespace VotingSystem
{
    public partial class Vote : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root; password=2575; persistsecurityinfo=True; database=face");
        MySqlDataAdapter mda;
        MySqlCommand msc;
        public static int vid;
        public int eid;
        public Vote()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string python = @"C:\Python27\python.exe";
                string myPythonApp = @"C:\Python27\frc\Recognizer.py";
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);
                myProcessStartInfo.UseShellExecute = false;
                myProcessStartInfo.RedirectStandardOutput = true;
                myProcessStartInfo.Arguments = myPythonApp;
                Process myProcess = new Process();
                myProcess.StartInfo = myProcessStartInfo;
                myProcess.Start();
                string standard_output;
                standard_output = myProcess.StandardOutput.ReadLine();
                label1.Text = standard_output;
                vid = Convert.ToInt32(standard_output);
                myProcess.WaitForExit(10000);
                myProcess.Close();

                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string squery = "SELECT voter.vid, voter.uname, voter.eid FROM voter WHERE vid = '" + vid + "'";
                mda = new MySqlDataAdapter(squery, con);
                con.Close();
                DataTable dt = new DataTable();
                mda.Fill(dt);
                textBox1.Text = dt.Rows[0][1].ToString();
                eid = Convert.ToInt32(dt.Rows[0][2]);
                if (textBox1.Text != "") 
                {
                    string str1 = "SELECT `voteid` FROM `vote` WHERE vid = '" + vid + "' AND eid = '" + eid + "'";
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    msc = new MySqlCommand(str1, con);
                    DataTable dt2 = new DataTable();
                    mda.SelectCommand = msc;
                    mda.Fill(dt2);
                    if (dt2.Rows.Count >= 1)
                    {
                        MessageBox.Show("You have already voted..");
                        textBox1.Text = "";
                        label1.Text = "label1";
                    }
                    else
                    {
                        MessageBox.Show("You can Vote..");
                    }
                    button3.Enabled = true;
                }

            }
            catch (Exception) 
            {
                MessageBox.Show("Try again.");
                button3.Enabled = false;
            }
        }

        private void Vote_Load(object sender, EventArgs e)
        {
            button3.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
            }
            else
            {
                string squery = "SELECT * FROM voter WHERE uname = '" + textBox1.Text + "' AND pw = '" + textBox2.Text + "' ";
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                msc = new MySqlCommand(squery, con);
                mda.SelectCommand = msc;
                DataTable dt1 = new DataTable();
                mda.Fill(dt1);
                if (dt1.Rows.Count == 1)
                {
                    this.Hide();
                    var v = new Voting();
                    v.Closed += (s, args) => this.Close();
                    v.Show();
                }
                else
                {
                    MessageBox.Show("Please Check your Username and Password");
                }
                con.Close();
                msc.Parameters.Clear();
            }
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            var vl = new VoterLogin();
            vl.Closed += (s, args) => this.Close();
            vl.Show();
        }
    }
}
