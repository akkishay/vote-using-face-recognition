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
    public partial class AdminLogin : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root; password=2575; persistsecurityinfo=True; database=face");
        MySqlDataAdapter mda = new MySqlDataAdapter();
        MySqlCommand msc;
        public AdminLogin()
        {
            InitializeComponent();
        }

        private void AdminLogin_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                string squery = "SELECT * FROM admin WHERE uname = '" + textBox1.Text + "' AND pw = '" + textBox2.Text + "' ";
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
                    this.Hide();
                    MDIParent mdi = new MDIParent();
                    //Voting v = new Voting();
                    mdi.ShowDialog();
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
