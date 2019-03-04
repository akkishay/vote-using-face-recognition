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
    public partial class DeleteElection : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=2575;persistsecurityinfo=True;database=face");
        MySqlCommand msc;
        public DeleteElection()
        {
            InitializeComponent();
        }

        private void DeleteElection_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'faceDataSet.election' table. You can move, or remove it, as needed.
            this.electionTableAdapter.Fill(this.faceDataSet.election);
            dataGridView1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            dateTimePicker1.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = false;
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
            try
            {
                textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                dateTimePicker1.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
                byte[] bytes = (byte[])dataGridView1.SelectedRows[0].Cells[3].Value;
                System.Drawing.ImageConverter converter = new System.Drawing.ImageConverter();
                Image img = (Image)converter.ConvertFrom(bytes);
                pictureBox1.Image = img;
                dataGridView1.Enabled = false;
                textBox3.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                button3.Enabled = true;
                textBox1.Enabled = false;
                button1.Enabled = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Please select election properly.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox1.Enabled = true;
            textBox1.Focus();
            dataGridView1.Enabled = false;
            textBox2.Text = "";
            dateTimePicker1.ResetText();
            pictureBox1.Image = null;
            textBox3.Text = "";
            button1.Enabled = false;
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string squery = " DELETE FROM election WHERE eid = '" + Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value) + "'; ";
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
                    this.electionTableAdapter.Fill(this.faceDataSet.election);
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
            this.dataGridView1.Update();
            this.dataGridView1.Refresh();
            con.Close();
            msc.Parameters.Clear();
            textBox1.Text = "";
            textBox1.Enabled = true;
            textBox1.Focus();
            dataGridView1.Enabled = false;
            textBox2.Text = "";
            dateTimePicker1.ResetText();
            pictureBox1.Image = null;
            textBox3.Text = "";
            button1.Enabled = false;
            button3.Enabled = false;
        }
    }
}
