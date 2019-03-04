using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;

namespace VotingSystem
{
    public partial class DeleteCandidate : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=2575;persistsecurityinfo=True;database=face");
        MySqlCommand msc;
        MySqlDataAdapter mda;
        public DeleteCandidate()
        {
            InitializeComponent();
        }

        private void DeleteCandidate_Load(object sender, EventArgs e)
        {
            dataGridView1.Enabled = false;
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string squery = "SELECT candidate.cid, candidate.cname, candidate.eid, candidate.img, candidate.cnum, candidate.cadd, election.ename FROM candidate INNER JOIN election ON candidate.eid = election.eid";
            mda = new MySqlDataAdapter(squery, con);
            con.Close();
            DataTable dt = new DataTable();
            mda.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[3].Visible = false;
            dataGridView1.Columns[4].Visible = false;
            dataGridView1.Columns[5].Visible = false;
            button3.Enabled = false;
            button1.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "cname like '%" + textBox1.Text + "%'";
            dataGridView1.DataSource = bs;
            dataGridView1.Enabled = true;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            byte[] bytes = (byte[])dataGridView1.SelectedRows[0].Cells[3].Value;
            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            Image img = (Image)converter.ConvertFrom(bytes);
            pictureBox1.Image = img;
            button1.Enabled = true;
            button3.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string squery = " DELETE FROM candidate WHERE cid = '" + Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value) + "'; ";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            msc = new MySqlCommand(squery, con);
            try
            {
                if (msc.ExecuteNonQuery() == 1)
                {
                    MessageBox.Show("Data is Deleted");
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    string str = "SELECT candidate.cid, candidate.cname, candidate.eid, candidate.img, candidate.cnum, candidate.cadd, election.ename FROM candidate INNER JOIN election ON candidate.eid = election.eid";
                    mda = new MySqlDataAdapter(str, con);
                    con.Close();
                    DataTable dt = new DataTable();
                    mda.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Columns[0].Visible = false;
                    dataGridView1.Columns[2].Visible = false;
                    dataGridView1.Columns[3].Visible = false;
                    dataGridView1.Columns[4].Visible = false;
                    dataGridView1.Columns[5].Visible = false;
                }
                else
                {
                    MessageBox.Show("Data is not Deleted");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            richTextBox1.Text = "";
            pictureBox1.Image = null;
            dataGridView1.Enabled = false;
            dataGridView1.ClearSelection();
            button3.Enabled = false;
            button1.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            richTextBox1.Text = "";
            pictureBox1.Image = null;
            dataGridView1.Enabled = false;
            dataGridView1.ClearSelection();
            button1.Enabled = false;
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
