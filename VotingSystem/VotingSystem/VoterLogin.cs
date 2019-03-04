using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace VotingSystem
{
    public partial class VoterLogin : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root; password=2575; persistsecurityinfo=True; database=face");
        MySqlDataAdapter mda = new MySqlDataAdapter();
        MySqlCommand msc;
        public static int vid;
        public int eid;
        public VoterLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string squery = "SELECT * FROM voter WHERE uname = '" + textBox1.Text + "' AND pw = '" + textBox2.Text + "' ";
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                msc = new MySqlCommand(squery, con);
                mda.SelectCommand = msc;
                mda.SelectCommand = msc;
                DataTable dt1 = new DataTable();
                mda.Fill(dt1);
                if (dt1.Rows.Count == 1)
                {
                    vid = Convert.ToInt32(dt1.Rows[0][0]);
                    eid = Convert.ToInt32(dt1.Rows[0][4]);

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
                        textBox2.Text = "";
                    }
                    else
                    {
                        MessageBox.Show("You can Vote..");
                        this.Hide();
                        var v = new Voting();
                        v.Closed += (s, args) => this.Close();
                        v.Show();
                    }
                }
                else
                {
                    MessageBox.Show("Please Check your Username and Password");
                }
                con.Close();
                msc.Parameters.Clear();
            }
            else 
            {
                MessageBox.Show("Please fill all fields.");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
