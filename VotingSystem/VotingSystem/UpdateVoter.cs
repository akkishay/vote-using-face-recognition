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
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace VotingSystem
{
    public partial class UpdateVoter : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=2575;persistsecurityinfo=True;database=face");
        MySqlCommand msc;
        MySqlDataAdapter mda;
        int idnum;
        int eid;
        public UpdateVoter()
        {
            InitializeComponent();
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "vname like '%" + textBox7.Text + "%'";
            dataGridView1.DataSource = bs;
            dataGridView1.Enabled = true;
        }

        private void UpdateVoter_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'faceDataSet.election' table. You can move, or remove it, as needed.
            this.electionTableAdapter.Fill(this.faceDataSet.election);
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

        public void cleardata() 
        {
            textBox7.Enabled = true;
            textBox1.Enabled = false;
            textBox2.Enabled = false;
            textBox3.Enabled = false;
            textBox4.Enabled = false;
            textBox5.Enabled = false;
            textBox6.Enabled = false;
            textBox8.Enabled = false;
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            button1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = false;
            dataGridView1.Enabled = false;
            dataGridView1.ClearSelection();
            dataGridView2.Enabled = false;
            dataGridView2.ClearSelection();
            checkBox1.Checked = false;
            richTextBox1.Enabled = false;
            richTextBox1.Text = "";
            label12.Text = "";
            button3.Enabled = false;
        }

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            label12.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            richTextBox1.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            eid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[4].Value);
            button4.Enabled = true;
            button5.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            button6.Enabled = true;
            button5.Enabled = false;
            textBox4.Text = textBox8.Text;
            button4.Enabled = false;
            textBox1.Enabled = true;
            textBox2.Enabled = true;
            textBox3.Enabled = true;
            textBox5.Enabled = true;
            richTextBox1.Enabled = true;
            dataGridView1.Enabled = false;
            textBox7.Enabled = false;
            button1.Enabled = true;
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView2.DataSource;
            bs.Filter = "ename like '%" + textBox6.Text + "%'";
            dataGridView2.DataSource = bs;
            dataGridView2.Enabled = true;
        }

        private void dataGridView2_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                eid = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value);
                textBox4.Text = dataGridView2.SelectedRows[0].Cells[1].Value.ToString();
                button1.Enabled = true;
                textBox1.Enabled = true;
                textBox2.Enabled = true;
                textBox3.Enabled = true;
                textBox5.Enabled = true;
                textBox6.Enabled = false;
                richTextBox1.Enabled = true;
                dataGridView1.Enabled = false;
                textBox7.Enabled = false;
            }
            catch (Exception)
            {
                MessageBox.Show("Please select election properly.");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            textBox6.Enabled = true;
            button4.Enabled = false;
            button5.Enabled = false;
            button6.Enabled = true;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            cleardata();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || richTextBox1.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
            }
            else
            {
                idnum = Convert.ToInt32(label12.Text);
                string python = @"C:\Python27\python.exe";
                string myPythonApp = @"C:\Python27\frc\DataSetGen.py";
                ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);
                myProcessStartInfo.UseShellExecute = false;
                myProcessStartInfo.RedirectStandardOutput = true;
                myProcessStartInfo.Arguments = string.Format(" {0} {1}", myPythonApp, idnum);
                Process myProcess = new Process();
                myProcess.StartInfo = myProcessStartInfo;
                myProcess.Start();
                string standard_output;
                standard_output = myProcess.StandardOutput.ReadLine();
                if (standard_output == "YES")
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked = false;
                }
                myProcess.WaitForExit();
                myProcess.Close();
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button3.Enabled = true;
            button2.Enabled = false;
            button6.Enabled = false;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Some Title", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                //do something
                string squery = "UPDATE voter SET vname = '" + textBox1.Text + "', uname = '" + textBox2.Text + "', pw = '" + textBox3.Text + "', eid = '" + eid + "', vnum = '" + Convert.ToInt32(textBox5.Text) + "', vadd = '" + richTextBox1.Text + "' WHERE vid = '" + idnum + "'";
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
            else if (dialogResult == DialogResult.No)
            {
                MessageBox.Show("Process canceled.");
            }
            
        }
    }
}
