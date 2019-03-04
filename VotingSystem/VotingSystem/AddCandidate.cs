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
    public partial class AddCandidate : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=2575;persistsecurityinfo=True;database=face");
        MySqlCommand msc;
        public AddCandidate()
        {
            InitializeComponent();
        }

        private void AddCandidate_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'faceDataSet.election' table. You can move, or remove it, as needed.
            this.electionTableAdapter.Fill(this.faceDataSet.election);
            dataGridView1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox5.Enabled = false;
            richTextBox1.Enabled = false;
            button1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            textBox2.Enabled = true;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "ename like '%" + textBox2.Text + "%'";
            dataGridView1.DataSource = bs;
            dataGridView1.Enabled = true;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Do you want to select this Election?", "Select Election", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    textBox3.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
                    textBox2.Enabled = false;
                    dataGridView1.Enabled = false;
                    textBox5.Enabled = true;
                    richTextBox1.Enabled = true;
                    button3.Enabled = true;
                }
                catch (Exception)
                {
                    MessageBox.Show("Please select election properly.");
                }
            }
            else if (dialogResult == DialogResult.No)
            {
                dataGridView1.ClearSelection();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picloc = dlg.FileName.ToString();
                textBox4.Text = picloc;
                pictureBox1.ImageLocation = picloc;
                button3.Enabled = false;
                button1.Enabled = true;
                button4.Enabled = true;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Enabled = true;
            textBox1.Focus();
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            richTextBox1.Enabled = false;
            richTextBox1.Text = "";
            pictureBox1.Image = null;
            button1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            dataGridView1.Enabled = false;
            dataGridView1.ClearSelection();
            this.electionTableAdapter.Fill(this.faceDataSet.election);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("New Candidate", "Do you want to add? ", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                byte[] img = null;
                FileStream fs = new FileStream(textBox4.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                string squery = "INSERT INTO candidate(cname, eid, img, cnum, cadd) VALUES('" + textBox1.Text + "', '" + Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value) + "', @IMG, '"+textBox5.Text+"', '"+richTextBox1.Text+"')";
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
                        MessageBox.Show("Data is Inserted");
                    }
                    else
                    {
                        MessageBox.Show("Data is not Inserted");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                con.Close();
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                richTextBox1.Text = "";
                richTextBox1.Enabled = false;
                pictureBox1.Image = null;
                button3.Enabled = false;
                button1.Enabled = false;
                button4.Enabled = false;
                dataGridView1.Enabled = false;
                dataGridView1.ClearSelection();
            }
            else if (dialogResult == DialogResult.No)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox2.Enabled = false;
                textBox3.Enabled = false;
                textBox4.Enabled = false;
                textBox5.Enabled = false;
                richTextBox1.Text = "";
                richTextBox1.Enabled = false;
                pictureBox1.Image = null;
                button3.Enabled = false;
                button1.Enabled = false;
            }
        }
    }
}