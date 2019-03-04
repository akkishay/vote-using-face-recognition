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
    public partial class DeleteVoter : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=2575;persistsecurityinfo=True;database=face");
        MySqlCommand msc;
        MySqlDataAdapter mda;
        public DeleteVoter()
        {
            InitializeComponent();
        }

        private void DeleteVoter_Load(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string squery = "SELECT voter.vid, voter.vname, voter.uname, voter.pw, voter.eid, voter.vnum, voter.vadd, election.ename FROM voter INNER JOIN election ON voter.eid = election.eid";
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
            dataGridView1.Columns[6].Visible = false;
            dataGridView1.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            richTextBox1.Enabled = false;
            button2.Enabled = false;
            button1.Enabled = false;
        }

        public void cleardata() 
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox7.Text = "";
            richTextBox1.Text = "";
            dataGridView1.Enabled = false;
            dataGridView1.ClearSelection();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "vname like '%" + textBox7.Text + "%'";
            dataGridView1.DataSource = bs;
            dataGridView1.Enabled = true;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
                textBox4.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
                textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
                richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
                button1.Enabled = true;
                button2.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Please select row properly.");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            string squery = "SELECT voter.vid, voter.vname, voter.uname, voter.pw, voter.eid, voter.vnum, voter.vadd, election.ename FROM voter INNER JOIN election ON voter.eid = election.eid";
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
            dataGridView1.Columns[6].Visible = false;
            cleardata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string squery = " DELETE FROM voter WHERE vid = '" + Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value) + "'; ";
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
                    string str = "SELECT voter.vid, voter.vname, voter.uname, voter.pw, voter.eid, voter.vnum, voter.vadd, election.ename FROM voter INNER JOIN election ON voter.eid = election.eid";
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
                    dataGridView1.Columns[6].Visible = false;
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
        }
    }
}
