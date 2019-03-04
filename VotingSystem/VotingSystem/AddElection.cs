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
    public partial class AddElection : Form
    {
        MySqlConnection con = new MySqlConnection("server=localhost;user id=root;password=2575;persistsecurityinfo=True;database=face");
        MySqlCommand msc;
        public AddElection()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sure", "Add New Election", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                string status = "Open";
                byte[] img = null;
                FileStream fs = new FileStream(textBox2.Text, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                img = br.ReadBytes((int)fs.Length);
                string squery = "INSERT INTO election (ename, edate, logo, status) values('" + textBox1.Text + "','" + dateTimePicker1.Text + "',@IMG,'" + status + "')";
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
                dateTimePicker1.ResetText();
                button3.Enabled = true;
                button1.Enabled = false;
                pictureBox1.Image = null;
            }
            else if (dialogResult == DialogResult.No)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                dateTimePicker1.ResetText();
                button3.Enabled = true;
                button1.Enabled = false;
                pictureBox1.Image = null;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "JPG Files(*.jpg)|*.jpg|PNG Files(*.png)|*.png|All Files(*.*)|*.*";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                string picloc = dlg.FileName.ToString();
                textBox2.Text = picloc;
                pictureBox1.ImageLocation = picloc;
                button1.Enabled = true;
                button3.Enabled = false;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            button1.Enabled = false;
            textBox2.Enabled = false;
        }
    }
}
