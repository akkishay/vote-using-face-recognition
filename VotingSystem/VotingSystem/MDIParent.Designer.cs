namespace VotingSystem
{
    partial class MDIParent
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.electionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addElectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateElectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteElectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.candidatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addCandidatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateCandidateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCandidateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addVoterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.addVoterToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.updateCandidateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteCandidateToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.resultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateResultToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.electionsToolStripMenuItem,
            this.candidatesToolStripMenuItem,
            this.addVoterToolStripMenuItem,
            this.resultsToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(802, 24);
            this.menuStrip.TabIndex = 0;
            this.menuStrip.Text = "MenuStrip";
            // 
            // electionsToolStripMenuItem
            // 
            this.electionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addElectionToolStripMenuItem,
            this.updateElectionToolStripMenuItem,
            this.deleteElectionToolStripMenuItem});
            this.electionsToolStripMenuItem.Name = "electionsToolStripMenuItem";
            this.electionsToolStripMenuItem.Size = new System.Drawing.Size(66, 20);
            this.electionsToolStripMenuItem.Text = "Elections";
            // 
            // addElectionToolStripMenuItem
            // 
            this.addElectionToolStripMenuItem.Name = "addElectionToolStripMenuItem";
            this.addElectionToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.addElectionToolStripMenuItem.Text = "Add Election";
            this.addElectionToolStripMenuItem.Click += new System.EventHandler(this.addElectionToolStripMenuItem_Click);
            // 
            // updateElectionToolStripMenuItem
            // 
            this.updateElectionToolStripMenuItem.Name = "updateElectionToolStripMenuItem";
            this.updateElectionToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.updateElectionToolStripMenuItem.Text = "Update Election";
            this.updateElectionToolStripMenuItem.Click += new System.EventHandler(this.updateElectionToolStripMenuItem_Click);
            // 
            // deleteElectionToolStripMenuItem
            // 
            this.deleteElectionToolStripMenuItem.Name = "deleteElectionToolStripMenuItem";
            this.deleteElectionToolStripMenuItem.Size = new System.Drawing.Size(157, 22);
            this.deleteElectionToolStripMenuItem.Text = "Delete Election";
            this.deleteElectionToolStripMenuItem.Click += new System.EventHandler(this.deleteElectionToolStripMenuItem_Click);
            // 
            // candidatesToolStripMenuItem
            // 
            this.candidatesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addCandidatesToolStripMenuItem,
            this.updateCandidateToolStripMenuItem,
            this.deleteCandidateToolStripMenuItem});
            this.candidatesToolStripMenuItem.Name = "candidatesToolStripMenuItem";
            this.candidatesToolStripMenuItem.Size = new System.Drawing.Size(78, 20);
            this.candidatesToolStripMenuItem.Text = "Candidates";
            // 
            // addCandidatesToolStripMenuItem
            // 
            this.addCandidatesToolStripMenuItem.Name = "addCandidatesToolStripMenuItem";
            this.addCandidatesToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.addCandidatesToolStripMenuItem.Text = "Add Candidates";
            this.addCandidatesToolStripMenuItem.Click += new System.EventHandler(this.addCandidatesToolStripMenuItem_Click);
            // 
            // updateCandidateToolStripMenuItem
            // 
            this.updateCandidateToolStripMenuItem.Name = "updateCandidateToolStripMenuItem";
            this.updateCandidateToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.updateCandidateToolStripMenuItem.Text = "Update Candidate";
            this.updateCandidateToolStripMenuItem.Click += new System.EventHandler(this.updateCandidateToolStripMenuItem_Click);
            // 
            // deleteCandidateToolStripMenuItem
            // 
            this.deleteCandidateToolStripMenuItem.Name = "deleteCandidateToolStripMenuItem";
            this.deleteCandidateToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.deleteCandidateToolStripMenuItem.Text = "Delete Candidate";
            this.deleteCandidateToolStripMenuItem.Click += new System.EventHandler(this.deleteCandidateToolStripMenuItem_Click);
            // 
            // addVoterToolStripMenuItem
            // 
            this.addVoterToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.addVoterToolStripMenuItem1,
            this.updateCandidateToolStripMenuItem1,
            this.deleteCandidateToolStripMenuItem1});
            this.addVoterToolStripMenuItem.Name = "addVoterToolStripMenuItem";
            this.addVoterToolStripMenuItem.Size = new System.Drawing.Size(51, 20);
            this.addVoterToolStripMenuItem.Text = "Voters";
            // 
            // addVoterToolStripMenuItem1
            // 
            this.addVoterToolStripMenuItem1.Name = "addVoterToolStripMenuItem1";
            this.addVoterToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.addVoterToolStripMenuItem1.Text = "Add Voter";
            this.addVoterToolStripMenuItem1.Click += new System.EventHandler(this.addVoterToolStripMenuItem1_Click);
            // 
            // updateCandidateToolStripMenuItem1
            // 
            this.updateCandidateToolStripMenuItem1.Name = "updateCandidateToolStripMenuItem1";
            this.updateCandidateToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.updateCandidateToolStripMenuItem1.Text = "Update Voter";
            this.updateCandidateToolStripMenuItem1.Click += new System.EventHandler(this.updateCandidateToolStripMenuItem1_Click);
            // 
            // deleteCandidateToolStripMenuItem1
            // 
            this.deleteCandidateToolStripMenuItem1.Name = "deleteCandidateToolStripMenuItem1";
            this.deleteCandidateToolStripMenuItem1.Size = new System.Drawing.Size(142, 22);
            this.deleteCandidateToolStripMenuItem1.Text = "Delete Voter";
            this.deleteCandidateToolStripMenuItem1.Click += new System.EventHandler(this.deleteCandidateToolStripMenuItem1_Click);
            // 
            // resultsToolStripMenuItem
            // 
            this.resultsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.calculateResultToolStripMenuItem});
            this.resultsToolStripMenuItem.Name = "resultsToolStripMenuItem";
            this.resultsToolStripMenuItem.Size = new System.Drawing.Size(56, 20);
            this.resultsToolStripMenuItem.Text = "Results";
            // 
            // calculateResultToolStripMenuItem
            // 
            this.calculateResultToolStripMenuItem.Name = "calculateResultToolStripMenuItem";
            this.calculateResultToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.calculateResultToolStripMenuItem.Text = "Calculate Result";
            this.calculateResultToolStripMenuItem.Click += new System.EventHandler(this.calculateResultToolStripMenuItem_Click);
            // 
            // MDIParent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(802, 538);
            this.Controls.Add(this.menuStrip);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MDIParent";
            this.Text = "MDIParent";
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion


        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem electionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addElectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateElectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteElectionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem candidatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addCandidatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateCandidateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteCandidateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addVoterToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem addVoterToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem updateCandidateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem deleteCandidateToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem resultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculateResultToolStripMenuItem;
    }
}



