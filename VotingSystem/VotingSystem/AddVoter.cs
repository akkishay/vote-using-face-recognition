using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace VotingSystem
{
    public partial class AddVoter : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=2575;persistsecurityinfo=True;database=face");
        MySqlCommand msc = new MySqlCommand();
        MySqlDataAdapter mda = new MySqlDataAdapter();
        int idnum;
        public AddVoter()
        {
            InitializeComponent();
        }

        private void AddVoter_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'faceDataSet.election' table. You can move, or remove it, as needed.
            this.electionTableAdapter.Fill(this.faceDataSet.election);
            string str = "SELECT MAX(vid) from voter";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            msc = new MySqlCommand(str, con);
            idnum = Convert.ToInt32(msc.ExecuteScalar());
            idnum = idnum + 1;
            label11.Text = Convert.ToString(idnum);
            con.Close();
            msc.Parameters.Clear();
            dataGridView1.Enabled = false;
            button3.Enabled = false;
            button1.Enabled = false;
            button4.Enabled = false;
        }

        public void cleardata() 
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            richTextBox1.Text = "";
            dataGridView1.Enabled = false;
            dataGridView1.ClearSelection();
            checkBox1.Checked = false;
            button1.Enabled = false;
            button3.Enabled = false;
            button4.Enabled = false;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            BindingSource bs = new BindingSource();
            bs.DataSource = dataGridView1.DataSource;
            bs.Filter = "ename like '%" + textBox4.Text + "%'";
            dataGridView1.DataSource = bs;
            dataGridView1.Enabled = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox5.Text == "" || textBox6.Text == "" || richTextBox1.Text == "")
            {
                MessageBox.Show("Please fill all fields.");
            }
            else 
            {
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

        private void dataGridView1_MouseClick(object sender, MouseEventArgs e)
        {
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            button3.Enabled = true;
            button4.Enabled = true;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cleardata();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string squery = "SELECT * FROM voter WHERE uname = '" + textBox2.Text + "'";
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            msc = new MySqlCommand(squery, con);
            mda.SelectCommand = msc;
            DataTable dt1 = new DataTable();
            mda.Fill(dt1);
            if (dt1.Rows.Count == 1)
            {
                MessageBox.Show("User Name is already taken");
                con.Close();
                msc.Parameters.Clear();
            }
            else
            {
                DialogResult dialogResult = MessageBox.Show("Sure", "Add New Voter", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    string squery1 = "INSERT INTO voter (vname, uname, pw, eid, vnum, vadd) values('" + textBox1.Text + "','" + textBox2.Text + "', '" + textBox3.Text + "', '" + Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value) + "', '" + textBox6.Text + "', '" + richTextBox1.Text + "')";
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    msc.Parameters.Clear();
                    msc = new MySqlCommand(squery1, con);
                    try
                    {
                        if (msc.ExecuteNonQuery() == 1)
                        {
                            MessageBox.Show("Data is Inserted");
                            string str = "SELECT MAX(vid) from voter";
                            if (con.State == ConnectionState.Closed)
                            {
                                con.Open();
                            }
                            msc = new MySqlCommand(str, con);
                            idnum = Convert.ToInt32(msc.ExecuteScalar());
                            idnum = idnum + 1;
                            label11.Text = Convert.ToString(idnum);
                            con.Close();
                            msc.Parameters.Clear();
                            dataGridView1.Enabled = false;
                            button3.Enabled = false;
                            button1.Enabled = false;
                            button4.Enabled = false;
                            cleardata();
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
                }
                else if (dialogResult == DialogResult.No)
                {
                    MessageBox.Show("Process canceled.");
                    cleardata();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            button1.Enabled = true;
        }
    }
}
