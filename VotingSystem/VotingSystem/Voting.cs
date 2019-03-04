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
    public partial class Voting : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root; password=2575; persistsecurityinfo=True; database=face");
        MySqlCommand msc;
        MySqlDataAdapter mda = new MySqlDataAdapter();
        int vid1 = Vote.vid;
        int vid2 = VoterLogin.vid;
        int eid, cid, vidd;
        public Voting()
        {
            InitializeComponent();
        }

        private void Voting_Load(object sender, EventArgs e)
        {
            //this block will fetch voter details on form with help of information from previous form
            try
            {
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string squery = "SELECT voter.vid, voter.vname, election.eid, election.ename FROM voter INNER JOIN election ON voter.eid = election.eid WHERE vid = '" + vid1 + "'";
                mda = new MySqlDataAdapter(squery, con);
                con.Close();
                DataTable dt = new DataTable();
                mda.Fill(dt);
                textBox3.Text = dt.Rows[0][1].ToString();
                textBox4.Text = dt.Rows[0][3].ToString();
                eid = Convert.ToInt32(dt.Rows[0][2]);
                label9.Text = Convert.ToString(vid1);
                vidd = vid1;
            }
            catch (Exception) 
            {
                MessageBox.Show("Please wait.");
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                string squery = "SELECT voter.vid, voter.vname, election.eid, election.ename FROM voter INNER JOIN election ON voter.eid = election.eid WHERE vid = '" + vid2 + "'";
                mda = new MySqlDataAdapter(squery, con);
                con.Close();
                DataTable dt = new DataTable();
                mda.Fill(dt);
                textBox3.Text = dt.Rows[0][1].ToString();
                textBox4.Text = dt.Rows[0][3].ToString();
                eid = Convert.ToInt32(dt.Rows[0][2]);
                label9.Text = Convert.ToString(vid2);
                vidd = vid2;
            }

            //this block will fetch info about candidate into datagridview with help of eid fetched from above block.
            try
            {
                string squery1 = "SELECT candidate.*, election.eid AS Expr1, election.ename FROM candidate INNER JOIN election ON candidate.eid = election.eid WHERE candidate.eid = '" + eid + "'";
                mda = new MySqlDataAdapter(squery1, con);
                con.Close();
                DataTable dt1 = new DataTable();
                mda.Fill(dt1);
                dataGridView1.DataSource = dt1;
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.Columns[2].Visible = false;
                dataGridView1.Columns[3].Visible = false;
                dataGridView1.Columns[4].Visible = false;
                dataGridView1.Columns[5].Visible = false;
                dataGridView1.Columns[6].Visible = false;
                dataGridView1.Columns[7].Visible = false;
                con.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Please select candidate properly..");
            }

            
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                byte[] bytes = (byte[])dataGridView1.SelectedRows[0].Cells[3].Value;
                System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                Image img = (Image)converter.ConvertFrom(bytes);
                pictureBox1.Image = img;
                cid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
            }
            catch (Exception)
            {
                MessageBox.Show("Please select candidate properly.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult dialogResult = MessageBox.Show("Sure", "Add New Vote", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string squery = "INSERT INTO vote (eid, vid, cid) values('" + eid + "','" + vidd + "', '" + cid + "')";
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    msc = new MySqlCommand(squery, con);
                    try
                    {
                        if (msc.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Vote is Added");
                            if (vid2 != 0)
                            {
                                this.Hide();
                                var v1 = new VoterLogin();
                                v1.Closed += (s, args) => this.Close();
                                v1.Show();
                            }
                            else
                            {
                                this.Hide();
                                var v1 = new Vote();
                                v1.Closed += (s, args) => this.Close();
                                v1.Show();
                            }
                        }
                        else
                        {
                            MessageBox.Show("Vote is not added");
                            if (vid2 != 0)
                            {
                                this.Hide();
                                var v1 = new VoterLogin();
                                v1.Closed += (s, args) => this.Close();
                                v1.Show();
                            }
                            else
                            {
                                this.Hide();
                                var v1 = new Vote();
                                v1.Closed += (s, args) => this.Close();
                                v1.Show();
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    con.Close();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error.");
            }
        }
    }
}
