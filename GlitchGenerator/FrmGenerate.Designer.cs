namespace GlitchGenerator
{
    partial class FrmGenerate
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.GbSettings = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.LblPreview = new System.Windows.Forms.Label();
            this.CbInitialDesign = new System.Windows.Forms.ComboBox();
            this.LblInitialDesign = new System.Windows.Forms.Label();
            this.NumHeight = new System.Windows.Forms.NumericUpDown();
            this.LblHeight = new System.Windows.Forms.Label();
            this.NumWidth = new System.Windows.Forms.NumericUpDown();
            this.LblWidth = new System.Windows.Forms.Label();
            this.PbPreview = new System.Windows.Forms.PictureBox();
            this.BtnCancel = new System.Windows.Forms.Button();
            this.BtnGenerate = new System.Windows.Forms.Button();
            this.tableLayoutPanel2.SuspendLayout();
            this.GbSettings.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.NumHeight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.GbSettings, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.BtnCancel, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.BtnGenerate, 1, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(6, 6);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(546, 364);
            this.tableLayoutPanel2.TabIndex = 8;
            // 
            // GbSettings
            // 
            this.tableLayoutPanel2.SetColumnSpan(this.GbSettings, 2);
            this.GbSettings.Controls.Add(this.tableLayoutPanel1);
            this.GbSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GbSettings.Location = new System.Drawing.Point(3, 4);
            this.GbSettings.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GbSettings.Name = "GbSettings";
            this.GbSettings.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.GbSettings.Size = new System.Drawing.Size(540, 318);
            this.GbSettings.TabIndex = 8;
            this.GbSettings.TabStop = false;
            this.GbSettings.Text = "Settings";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoSize = true;
            this.tableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.LblPreview, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.CbInitialDesign, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.LblInitialDesign, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.NumHeight, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.LblHeight, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.NumWidth, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.LblWidth, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.PbPreview, 1, 3);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 24);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(385, 233);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // LblPreview
            // 
            this.LblPreview.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblPreview.Location = new System.Drawing.Point(3, 151);
            this.LblPreview.Name = "LblPreview";
            this.LblPreview.Size = new System.Drawing.Size(117, 30);
            this.LblPreview.TabIndex = 6;
            this.LblPreview.Text = "Preview:";
            this.LblPreview.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CbInitialDesign
            // 
            this.CbInitialDesign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CbInitialDesign.FormattingEnabled = true;
            this.CbInitialDesign.ImeMode = System.Windows.Forms.ImeMode.On;
            this.CbInitialDesign.ItemHeight = 17;
            this.CbInitialDesign.Location = new System.Drawing.Point(126, 70);
            this.CbInitialDesign.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.CbInitialDesign.Name = "CbInitialDesign";
            this.CbInitialDesign.Size = new System.Drawing.Size(171, 25);
            this.CbInitialDesign.TabIndex = 5;
            this.CbInitialDesign.SelectedIndexChanged += new System.EventHandler(this.CbInitialDesign_SelectedIndexChanged);
            // 
            // LblInitialDesign
            // 
            this.LblInitialDesign.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblInitialDesign.Location = new System.Drawing.Point(3, 67);
            this.LblInitialDesign.Name = "LblInitialDesign";
            this.LblInitialDesign.Size = new System.Drawing.Size(117, 30);
            this.LblInitialDesign.TabIndex = 4;
            this.LblInitialDesign.Text = "Initial Design:";
            this.LblInitialDesign.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumHeight
            // 
            this.NumHeight.Location = new System.Drawing.Point(126, 37);
            this.NumHeight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NumHeight.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumHeight.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumHeight.Name = "NumHeight";
            this.NumHeight.Size = new System.Drawing.Size(85, 25);
            this.NumHeight.TabIndex = 3;
            this.NumHeight.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // LblHeight
            // 
            this.LblHeight.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblHeight.Location = new System.Drawing.Point(3, 34);
            this.LblHeight.Name = "LblHeight";
            this.LblHeight.Size = new System.Drawing.Size(117, 30);
            this.LblHeight.TabIndex = 2;
            this.LblHeight.Text = "Height:";
            this.LblHeight.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // NumWidth
            // 
            this.NumWidth.Location = new System.Drawing.Point(126, 4);
            this.NumWidth.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.NumWidth.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.NumWidth.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.NumWidth.Name = "NumWidth";
            this.NumWidth.Size = new System.Drawing.Size(85, 25);
            this.NumWidth.TabIndex = 1;
            this.NumWidth.Value = new decimal(new int[] {
            1024,
            0,
            0,
            0});
            // 
            // LblWidth
            // 
            this.LblWidth.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.LblWidth.Location = new System.Drawing.Point(3, 1);
            this.LblWidth.Name = "LblWidth";
            this.LblWidth.Size = new System.Drawing.Size(117, 30);
            this.LblWidth.TabIndex = 0;
            this.LblWidth.Text = "Width:";
            this.LblWidth.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PbPreview
            // 
            this.PbPreview.Location = new System.Drawing.Point(126, 102);
            this.PbPreview.Name = "PbPreview";
            this.PbPreview.Size = new System.Drawing.Size(256, 128);
            this.PbPreview.TabIndex = 7;
            this.PbPreview.TabStop = false;
            // 
            // BtnCancel
            // 
            this.BtnCancel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.BtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BtnCancel.ForeColor = System.Drawing.Color.Red;
            this.BtnCancel.Location = new System.Drawing.Point(3, 330);
            this.BtnCancel.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnCancel.Name = "BtnCancel";
            this.BtnCancel.Size = new System.Drawing.Size(87, 30);
            this.BtnCancel.TabIndex = 9;
            this.BtnCancel.Text = "Cancel";
            this.BtnCancel.UseVisualStyleBackColor = true;
            this.BtnCancel.Click += new System.EventHandler(this.BtnGenerate_Click);
            // 
            // BtnGenerate
            // 
            this.BtnGenerate.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.BtnGenerate.Location = new System.Drawing.Point(456, 330);
            this.BtnGenerate.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.BtnGenerate.Name = "BtnGenerate";
            this.BtnGenerate.Size = new System.Drawing.Size(87, 30);
            this.BtnGenerate.TabIndex = 10;
            this.BtnGenerate.Text = "Generate";
            this.BtnGenerate.UseVisualStyleBackColor = true;
            this.BtnGenerate.Click += new System.EventHandler(this.BtnGenerate_Click_1);
            // 
            // FrmGenerate
            // 
            this.AcceptButton = this.BtnGenerate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BtnCancel;
            this.ClientSize = new System.Drawing.Size(558, 376);
            this.ControlBox = false;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Font = new System.Drawing.Font("Segoe UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmGenerate";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Generate Image";
            this.tableLayoutPanel2.ResumeLayout(false);
            this.GbSettings.ResumeLayout(false);
            this.GbSettings.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.NumHeight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.NumWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PbPreview)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.GroupBox GbSettings;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ComboBox CbInitialDesign;
        private System.Windows.Forms.Label LblInitialDesign;
        private System.Windows.Forms.NumericUpDown NumHeight;
        private System.Windows.Forms.Label LblHeight;
        private System.Windows.Forms.NumericUpDown NumWidth;
        private System.Windows.Forms.Label LblWidth;
        private System.Windows.Forms.Button BtnCancel;
        private System.Windows.Forms.Button BtnGenerate;
        private System.Windows.Forms.Label LblPreview;
        private System.Windows.Forms.PictureBox PbPreview;
    }
}