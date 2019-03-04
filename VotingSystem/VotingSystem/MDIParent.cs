using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace VotingSystem
{
    public partial class MDIParent : Form
    {
        private int childFormNumber = 0;

        public MDIParent()
        {
            InitializeComponent();
        }

        private void ShowNewForm(object sender, EventArgs e)
        {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = openFileDialog.FileName;
            }
        }
/*
        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form childForm in MdiChildren)
            {
                childForm.Close();
            }
        }
        */
        private void addElectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddElection form = new AddElection();
            form.MdiParent = this;
            form.Show();
        }

        private void updateElectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateElection form = new UpdateElection();
            form.MdiParent = this;
            form.Show();
        }

        private void deleteElectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteElection form = new DeleteElection();
            form.MdiParent = this;
            form.Show();
        }

        private void addCandidatesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCandidate form = new AddCandidate();
            form.MdiParent = this;
            form.Show();
        }

        private void updateCandidateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateCandidate form = new UpdateCandidate();
            form.MdiParent = this;
            form.Show();
        }

        private void deleteCandidateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DeleteCandidate form = new DeleteCandidate();
            form.MdiParent = this;
            form.Show();
        }

        private void addVoterToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            AddVoter form = new AddVoter();
            form.MdiParent = this;
            form.Show();
        }

        private void updateCandidateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            UpdateVoter form = new UpdateVoter();
            form.MdiParent = this;
            form.Show();
        }

        private void deleteCandidateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DeleteVoter form = new DeleteVoter();
            form.MdiParent = this;
            form.Show();
        }

        private void calculateResultToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Result form = new Result();
            form.MdiParent = this;
            form.Show();
        }
    }
}
