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
    public partial class UpdateCandidate : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=2575;persistsecurityinfo=True;database=face");
        MySqlCommand msc;
        MySqlDataAdapter mda;
        int eid;
        public UpdateCandidate()
        {
            InitializeComponent();
        }

        public void cleardata() 
        {
            textBox1.Enabled = true;
            textBox2.Enabled = false;
            textBox4.Enabled = false;
            textBox7.Enabled = false;
            richTextBox1.Enabled = false;
            textBox3.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox2.Text = "";
            textBox4.Text = "";
            textBox7.Text = "";
            richTextBox1.Text = "";
            button1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
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
            textBox1.Text = "";
            textBox1.Focus();
            dataGridView1.Enabled = false;
            dataGridView1.ClearSelection();
            dataGridView2.Enabled = false;
            dataGridView2.ClearSelection();
        }

        private void UpdateCandidate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'faceDataSet.election' table. You can move, or remove it, as needed.
            this.electionTableAdapter.Fill(this.faceDataSet.election);
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox7.Enabled = false;
            richTextBox1.Enabled = false;
            dataGridView1.Enabled = false;
            dataGridView2.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
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
            eid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[2].Value);
            byte[] bytes = (byte[])dataGridView1.SelectedRows[0].Cells[3].Value;
            System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
            Image img = (Image)converter.ConvertFrom(bytes);
            pictureBox1.Image = img;
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            button5.Enabled = true;
            button6.Enabled = true;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView2.DataSource;
            bs.Filter = "ename like '%" + textBox4.Text + "%'";
            dataGridView2.DataSource = bs;
            dataGridView2.Enabled = true;
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            eid = Convert.ToInt32(dataGridView2.SelectedRows[0].Cells[0].Value);
            textBox5.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
            button7.Enabled = true;
            button3.Enabled = true;
            dataGridView1.Enabled = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox5.Text = textBox3.Text;
            button4.Enabled = true;
            button6.Enabled = false;
            button4.Enabled = true;
            button7.Enabled = true;
            button3.Enabled = true;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            button1.Enabled = true;
            button3.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            button7.Enabled = false;
            textBox1.Enabled = false;
            textBox2.Enabled = true;
            textBox7.Enabled = true;
            richTextBox1.Enabled = true;
            dataGridView2.Enabled = false;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            button4.Enabled = true;
            button5.Enabled = false;
            button4.Enabled = true;
            textBox4.Enabled = true;
            button6.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picloc = dlg.FileName.ToString();
                textBox6.Text = picloc;
                pictureBox2.ImageLocation = picloc;
                button3.Enabled = false;
                button7.Enabled = false;
                dataGridView2.Enabled = false;
                textBox2.Enabled = true;
                textBox4.Enabled = false;
                textBox7.Enabled = true;
                richTextBox1.Enabled = true;
                textBox1.Enabled = false;
                button1.Enabled = true;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cleardata();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
            {
                string squery = "UPDATE candidate SET cname= '"+textBox2.Text+"', eid= '"+eid+"',cnum= '"+textBox7.Text+"', cadd= '"+richTextBox1.Text+"' WHERE cid = '"+Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value)+"'";
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                msc = new MySqlCommand(squery, con);
                try
                {
                    if (msc.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Data is Updated");
                        cleardata();
                    }
                    else
                    {
                        MessageBox.Show("Data is not Updated");
                        cleardata();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                con.Close();
                msc.Parameters.Clear();
            }
            else
            {
                byte[] img = null;
                FileStream fs = new FileStream(textBox6.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                string squery = "UPDATE candidate SET cname= '" + textBox2.Text + "', eid= '" + eid + "', img= @IMG, cnum= '" + textBox7.Text + "', cadd= '" + richTextBox1.Text + "' WHERE cid = '" + Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value) + "'";
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                msc = new MySqlCommand(squery, con);
                try
                {
                    msc.Parameters.Add(new MySqlParameter("@IMG", img));
                    if (msc.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Data is Updated");
                        cleardata();
                    }
                    else
                    {
                        MessageBox.Show("Data is not Updated");
                        cleardata();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                con.Close();
                msc.Parameters.Clear();
            }
        }
    }
}
