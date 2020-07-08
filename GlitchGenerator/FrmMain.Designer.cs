namespace GlitchGenerator
{
	internal partial class FrmDisplay
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
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomOneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomMultipleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomMultipleNoCompressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.greyscaleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.brightToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomToolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.sfd = new System.Windows.Forms.SaveFileDialog();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.UndoToolStripMenuItem,
            this.randomToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(961, 24);
            this.menuStrip.TabIndex = 0;
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.OpenToolStripMenuItem_Click);
            // 
            // UndoToolStripMenuItem
            // 
            this.UndoToolStripMenuItem.Enabled = false;
            this.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem";
            this.UndoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.UndoToolStripMenuItem.Text = "Undo";
            this.UndoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // randomToolStripMenuItem
            // 
            this.randomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomOneToolStripMenuItem,
            this.randomMultipleToolStripMenuItem,
            this.randomMultipleNoCompressionToolStripMenuItem,
            this.randomToolStripMenuItem1});
            this.randomToolStripMenuItem.Enabled = false;
            this.randomToolStripMenuItem.Name = "randomToolStripMenuItem";
            this.randomToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.randomToolStripMenuItem.Text = "Random";
            // 
            // randomOneToolStripMenuItem
            // 
            this.randomOneToolStripMenuItem.Name = "randomOneToolStripMenuItem";
            this.randomOneToolStripMenuItem.Size = new System.Drawing.Size(349, 22);
            this.randomOneToolStripMenuItem.Text = "One Glitch";
            this.randomOneToolStripMenuItem.Click += new System.EventHandler(this.RandomOneToolStripMenuItem_Click);
            // 
            // randomMultipleToolStripMenuItem
            // 
            this.randomMultipleToolStripMenuItem.Name = "randomMultipleToolStripMenuItem";
            this.randomMultipleToolStripMenuItem.Size = new System.Drawing.Size(349, 22);
            this.randomMultipleToolStripMenuItem.Text = "Multiple Glitches";
            this.randomMultipleToolStripMenuItem.Click += new System.EventHandler(this.RandomMultipleToolStripMenuItem_Click);
            // 
            // randomMultipleNoCompressionToolStripMenuItem
            // 
            this.randomMultipleNoCompressionToolStripMenuItem.Name = "randomMultipleNoCompressionToolStripMenuItem";
            this.randomMultipleNoCompressionToolStripMenuItem.Size = new System.Drawing.Size(349, 22);
            this.randomMultipleNoCompressionToolStripMenuItem.Text = "Multiple Glitches, No Compression";
            this.randomMultipleNoCompressionToolStripMenuItem.Click += new System.EventHandler(this.RandomMultipleNoCompressionToolStripMenuItem_Click);
            // 
            // randomToolStripMenuItem1
            // 
            this.randomToolStripMenuItem1.Name = "randomToolStripMenuItem1";
            this.randomToolStripMenuItem1.Size = new System.Drawing.Size(349, 22);
            this.randomToolStripMenuItem1.Text = "Multiple Glitches, No Compression, Multiple Images";
            this.randomToolStripMenuItem1.Click += new System.EventHandler(this.RandomToolStripMenuItem1_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "•";
            // 
            // greyscaleToolStripMenuItem
            // 
            this.greyscaleToolStripMenuItem.Name = "greyscaleToolStripMenuItem";
            this.greyscaleToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // brightToolStripMenuItem
            // 
            this.brightToolStripMenuItem.Name = "brightToolStripMenuItem";
            this.brightToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // randomToolStripMenuItem2
            // 
            this.randomToolStripMenuItem2.Name = "randomToolStripMenuItem2";
            this.randomToolStripMenuItem2.Size = new System.Drawing.Size(32, 19);
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // FrmDisplay
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(961, 559);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FrmDisplay";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Glitch Generator";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FrmDisplay_Paint);
            this.Resize += new System.EventHandler(this.FrmDisplay_Resize);
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem UndoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ToolStripMenuItem greyscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem randomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomOneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomMultipleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomMultipleNoCompressionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem randomToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfd;
    }
}

