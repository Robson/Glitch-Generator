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
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.GenerateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.corruptFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.UndoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomOneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.randomMultipleNoCompressionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripSeparator();
            this.randomToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.randomImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SmallImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MediumImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.LargeImagesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.UndoToolStripMenuItem,
            this.randomToolStripMenuItem,
            this.toolStripMenuItem1});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(961, 24);
            this.menuStrip.TabIndex = 0;
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseToolStripMenuItem,
            this.GenerateToolStripMenuItem,
            this.toolStripMenuItem2,
            this.corruptFilesToolStripMenuItem});
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.newToolStripMenuItem.Text = "New";
            // 
            // browseToolStripMenuItem
            // 
            this.browseToolStripMenuItem.Name = "browseToolStripMenuItem";
            this.browseToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.browseToolStripMenuItem.Text = "Open Image...";
            this.browseToolStripMenuItem.Click += new System.EventHandler(this.BrowseToolStripMenuItem_Click);
            // 
            // GenerateToolStripMenuItem
            // 
            this.GenerateToolStripMenuItem.Name = "GenerateToolStripMenuItem";
            this.GenerateToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.GenerateToolStripMenuItem.Text = "Generate Image...";
            this.GenerateToolStripMenuItem.Click += new System.EventHandler(this.GenerateToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(199, 6);
            // 
            // corruptFilesToolStripMenuItem
            // 
            this.corruptFilesToolStripMenuItem.Name = "corruptFilesToolStripMenuItem";
            this.corruptFilesToolStripMenuItem.Size = new System.Drawing.Size(202, 22);
            this.corruptFilesToolStripMenuItem.Text = "Glitch Multiple Images...";
            this.corruptFilesToolStripMenuItem.Click += new System.EventHandler(this.CorruptFolderToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Enabled = false;
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Visible = false;
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.SaveToolStripMenuItem_Click);
            // 
            // UndoToolStripMenuItem
            // 
            this.UndoToolStripMenuItem.Enabled = false;
            this.UndoToolStripMenuItem.Name = "UndoToolStripMenuItem";
            this.UndoToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.UndoToolStripMenuItem.Text = "Undo";
            this.UndoToolStripMenuItem.Visible = false;
            this.UndoToolStripMenuItem.Click += new System.EventHandler(this.UndoToolStripMenuItem_Click);
            // 
            // randomToolStripMenuItem
            // 
            this.randomToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.randomOneToolStripMenuItem,
            this.randomMultipleNoCompressionToolStripMenuItem,
            this.toolStripMenuItem3,
            this.randomToolStripMenuItem1});
            this.randomToolStripMenuItem.Enabled = false;
            this.randomToolStripMenuItem.Name = "randomToolStripMenuItem";
            this.randomToolStripMenuItem.Size = new System.Drawing.Size(64, 20);
            this.randomToolStripMenuItem.Text = "Random";
            this.randomToolStripMenuItem.Visible = false;
            // 
            // randomOneToolStripMenuItem
            // 
            this.randomOneToolStripMenuItem.Name = "randomOneToolStripMenuItem";
            this.randomOneToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
            this.randomOneToolStripMenuItem.Text = "One Glitch";
            this.randomOneToolStripMenuItem.Click += new System.EventHandler(this.RandomOneToolStripMenuItem_Click);
            // 
            // randomMultipleNoCompressionToolStripMenuItem
            // 
            this.randomMultipleNoCompressionToolStripMenuItem.Name = "randomMultipleNoCompressionToolStripMenuItem";
            this.randomMultipleNoCompressionToolStripMenuItem.Size = new System.Drawing.Size(321, 22);
            this.randomMultipleNoCompressionToolStripMenuItem.Text = "Multiple Glitches";
            this.randomMultipleNoCompressionToolStripMenuItem.Click += new System.EventHandler(this.RandomMultipleNoCompressionToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(318, 6);
            // 
            // randomToolStripMenuItem1
            // 
            this.randomToolStripMenuItem1.Name = "randomToolStripMenuItem1";
            this.randomToolStripMenuItem1.Size = new System.Drawing.Size(321, 22);
            this.randomToolStripMenuItem1.Text = "Create Multiple Outputs With Multiple Glitches";
            this.randomToolStripMenuItem1.Click += new System.EventHandler(this.RandomToolStripMenuItem1_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(24, 20);
            this.toolStripMenuItem1.Text = "•";
            this.toolStripMenuItem1.Visible = false;
            // 
            // randomImageToolStripMenuItem
            // 
            this.randomImageToolStripMenuItem.Name = "randomImageToolStripMenuItem";
            this.randomImageToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // SmallImagesToolStripMenuItem
            // 
            this.SmallImagesToolStripMenuItem.Name = "SmallImagesToolStripMenuItem";
            this.SmallImagesToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // MediumImagesToolStripMenuItem
            // 
            this.MediumImagesToolStripMenuItem.Name = "MediumImagesToolStripMenuItem";
            this.MediumImagesToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // LargeImagesToolStripMenuItem
            // 
            this.LargeImagesToolStripMenuItem.Name = "LargeImagesToolStripMenuItem";
            this.LargeImagesToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
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
        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.ToolStripMenuItem greyscaleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem brightToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomToolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem randomToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomOneToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomMultipleNoCompressionToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem randomToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog sfd;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem corruptFilesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem randomImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem SmallImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem MediumImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem LargeImagesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem GenerateToolStripMenuItem;
    }
}

