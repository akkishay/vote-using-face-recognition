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
    public partial class UpdateElection : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=2575;persistsecurityinfo=True;database=face");
        MySqlCommand msc;
        public UpdateElection()
        {
            InitializeComponent();
        }

        private void UpdateElection_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'faceDataSet.election' table. You can move, or remove it, as needed.
            this.electionTableAdapter.Fill(this.faceDataSet.election);
            dataGridView1.Enabled = false;
            textBox2.Enabled = false;
            dateTimePicker1.Enabled = false;
            comboBox1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button1.Enabled = false;
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
                comboBox1.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
                dataGridView1.Enabled = false;
                textBox2.Enabled = true;
                dateTimePicker1.Enabled = true;
                button1.Enabled = true;
                button3.Enabled = true;
                button4.Enabled = true;
                comboBox1.Enabled = true;
            }
            catch (Exception) 
            {
                MessageBox.Show("Please select election properly.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picloc = dlg.FileName.ToString();
                textBox3.Text = picloc;
                pictureBox2.ImageLocation = picloc;
                button3.Enabled = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox2.Image == null)
            {
                string squery = "UPDATE election SET ename= '" + textBox2.Text + "', edate= '" + dateTimePicker1.Text + "', status = '" + comboBox1.Text + "' WHERE eid = '" + Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value) + "' ;";
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
                        this.electionTableAdapter.Fill(this.faceDataSet.election);
                    }
                    else
                    {
                        MessageBox.Show("Data is not Updated");
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
                FileStream fs = new FileStream(textBox3.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                string squery = "UPDATE election SET ename= '" + textBox2.Text + "', edate= '" + dateTimePicker1.Text + "', logo= @IMG , status = '" + comboBox1.Text + "' WHERE eid = '" + Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value) + "' ;";
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
                        this.electionTableAdapter.Fill(this.faceDataSet.election);
                    }
                    else
                    {
                        MessageBox.Show("Data is not Updated");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }

                con.Close();
                msc.Parameters.Clear();
            }
            textBox1.Text = "";
            textBox1.Enabled = true;
            textBox1.Focus();
            dataGridView1.Enabled = false;
            textBox2.Text = "";
            textBox2.Enabled = false;
            dateTimePicker1.ResetText();
            dateTimePicker1.Enabled = false;
            comboBox1.SelectedIndex = -1;
            comboBox1.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            button4.Enabled = false;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox1.Text = "";
            textBox1.Focus();
            dataGridView1.Enabled = false;
            textBox2.Text = "";
            textBox2.Enabled = false;
            dateTimePicker1.ResetText();
            dateTimePicker1.Enabled = false;
            comboBox1.SelectedIndex = -1;
            comboBox1.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            pictureBox1.Image = null;
            pictureBox2.Image = null;
            button4.Enabled = false;
        }
    }
}
