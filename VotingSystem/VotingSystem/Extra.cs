using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;
using System.IO;

namespace VotingSystem
{
    public partial class Extra : Form
    {
        public Extra()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string python = @"C:\Python27\python.exe";
            string myPythonApp = @"C:\Python27\frc\DataSetGen.py";
            int id = 3;
            //string y = "akshay";
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;
            //myProcessStartInfo.Arguments = myPythonApp + " " + x + " " + y;
            //myProcessStartInfo.Arguments = myPythonApp + " " + id;
            myProcessStartInfo.Arguments = string.Format(" {0} {1}", myPythonApp, id);
            Process myProcess = new Process();
            myProcess.StartInfo = myProcessStartInfo;
            myProcess.Start();
            myProcess.WaitForExit();
            myProcess.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string python = @"C:\Python27\python.exe";
            string myPythonApp = @"C:\Python27\frc\Recognizer.py";
            ProcessStartInfo myProcessStartInfo = new ProcessStartInfo(python);
            myProcessStartInfo.UseShellExecute = false;
            myProcessStartInfo.RedirectStandardOutput = true;
            myProcessStartInfo.Arguments = myPythonApp;
            Process myProcess = new Process();
            myProcess.StartInfo = myProcessStartInfo;
            myProcess.Start();
            string standard_output;
            standard_output = myProcess.StandardOutput.ReadLine();
            label1.Text = standard_output;
            myProcess.WaitForExit(10000);
            myProcess.Close();
        }
    }
}
