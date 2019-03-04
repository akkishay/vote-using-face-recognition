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
    public partial class Result : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=2575;persistsecurityinfo=True;database=face");
        MySqlDataAdapter mda;
        public Result()
        {
            InitializeComponent();
        }

        private void Result_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'faceDataSet.election' table. You can move, or remove it, as needed.
            this.electionTableAdapter.Fill(this.faceDataSet.election);

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "ename like '%" + textBox1.Text + "%'";
            dataGridView1.DataSource = bs;
            dataGridView1.Enabled = true;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string squery = "SELECT candidate.eid, candidate.cname AS Candidate, count(vote.voteid) AS Votes FROM candidate LEFT JOIN vote ON vote.cid = candidate.cid WHERE (candidate.eid = '" + Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value) + "' ) GROUP BY candidate.cid ORDER BY Votes DESC";
            mda = new MySqlDataAdapter(squery, con);
            con.Close();
            DataTable dt = new DataTable();
            mda.Fill(dt);
            dataGridView2.DataSource = dt;
            dataGridView2.Columns[0].Visible = false;
            textBox3.Text = dataGridView2.Rows[0].Cells[1].Value.ToString();
            button1.Enabled = false;
        }
    }
}
