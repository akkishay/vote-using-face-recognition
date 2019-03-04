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
    public partial class qb : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=2575;persistsecurityinfo=True;database=face");
        MySqlCommand msc;
        MySqlDataAdapter mda;
        public qb()
        {
            InitializeComponent();
        }

        private void qb_Load(object sender, EventArgs e)
        {
            string squery = "SELECT candidate.cname AS Candidate, COUNT(*) AS Votes FROM vote INNER JOIN candidate ON vote.cid = candidate.cid WHERE (vote.eid = 2) GROUP BY vote.cid";
            mda = new MySqlDataAdapter(squery, con);
            con.Close();
            DataTable dt = new DataTable();
            mda.Fill(dt);
            dataGridView1.DataSource = dt;
        }
    }
}
