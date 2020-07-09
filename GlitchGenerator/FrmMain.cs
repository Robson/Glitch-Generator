namespace GlitchGenerator
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Windows.Forms;

    internal partial class FrmDisplay : Form
	{
        private readonly Stack<string> filenames = new Stack<string>();
        private Bitmap formBitmap;
        private Graphics formGraphics;        

		internal FrmDisplay()
		{
			this.InitializeComponent();
            this.Invalidate();
            RNG.Random = new Random();
            var lastParent = string.Empty;
            var glitches = Actions.GetAllGlitches();
            ToolStripMenuItem menu = null;
            foreach (var glitch in glitches)
            {
                if (glitch.Parent != lastParent)
                {
                    menu = new ToolStripMenuItem(glitch.Parent);
                    menu.Enabled = false;
                    this.MainMenuStrip.Items.Add(menu);
                    lastParent = glitch.Parent;
                }

                var menuItem = new ToolStripMenuItem(glitch.Name);
                menuItem.Click += this.MenuItem_Click;
                menuItem.Tag = glitch.Method;
                menu.DropDownItems.Add(menuItem);
            }

            this.WindowState = FormWindowState.Maximized;
            this.Text = this.MakeVersionNumber();
        }

        private void MenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Working on it...";
            this.formBitmap = ((Converter<Bitmap, Bitmap>)((ToolStripMenuItem)sender).Tag).Invoke(this.formBitmap);
            this.SaveLatestImage();
            this.Text = this.MakeVersionNumber();
        }

        private void FrmDisplay_Paint(object sender, PaintEventArgs e)
		{
            if (this.formBitmap != null)
            {
                e.Graphics.DrawImage(this.formBitmap, new Rectangle(0, 25, this.formBitmap.Width, this.formBitmap.Height));
            }
		}

		private void FrmDisplay_Resize(object sender, EventArgs e)
		{
            this.Invalidate();
        }        

        private void OpenToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ofd.InitialDirectory = Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "Examples";
            this.ofd.Filter = "Images|*.png;*.jpg;*.jpeg;*.gif;*.bmp";
            this.ofd.FileName = string.Empty;
            this.ofd.ShowDialog();
            if (File.Exists(this.ofd.FileName))
            {
                this.filenames.Clear();
                if (this.formBitmap != null)
                {
                    this.formBitmap.Dispose();
                }

                this.formBitmap = new Bitmap(this.ofd.FileName);
                var filename = Path.GetTempFileName() + ".png";
                this.formBitmap.Save(filename);
                this.filenames.Push(filename);
                this.formGraphics = Graphics.FromImage(this.formBitmap);                
                this.Invalidate();
                foreach (ToolStripMenuItem menu in this.MainMenuStrip.Items)
                {
                    menu.Enabled = true;
                }
                this.UndoToolStripMenuItem.Enabled = false;
            }
        }

        private void RandomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Working on it...";
            var glitches = Actions.GetAllGlitches();
            var amount = RNG.Random.Next(3, 7);
            for (int i = 0; i < amount; i++)
            {
                var glitch = glitches[RNG.Random.Next(glitches.Count)].Method;
                this.formBitmap = glitch.Invoke(this.formBitmap);
            }

            this.SaveLatestImage();
            this.Text = this.MakeVersionNumber();
        }

        private void UndoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Working on it...";
            this.filenames.Pop();
            this.formBitmap.Dispose();
            var temp = new Bitmap(this.filenames.Peek());
            this.formBitmap = new Bitmap(temp);
            temp.Dispose();
            this.formGraphics = Graphics.FromImage(this.formBitmap);
            this.Invalidate();
            this.UndoToolStripMenuItem.Enabled = this.filenames.Count > 1;
            this.Text = this.MakeVersionNumber();
        }

        private void RandomOneToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Working on it...";
            this.ApplyRandomGlitch(1, isAllowingCompression: true);
            this.SaveLatestImage();
            this.Text = this.MakeVersionNumber();
        }

        private void RandomMultipleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Working on it...";
            this.ApplyRandomGlitch(RNG.Random.Next(3, 8), isAllowingCompression: true);
            this.SaveLatestImage();
            this.Text = this.MakeVersionNumber();
        }

        private void RandomMultipleNoCompressionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Text = "Working on it...";
            this.ApplyRandomGlitch(RNG.Random.Next(3, 8), isAllowingCompression: false);
            this.SaveLatestImage();
            this.Text = this.MakeVersionNumber();
        }

        private void ApplyRandomGlitch(int amount, bool isAllowingCompression)
        {
            var glitches = Actions.GetAllGlitches();
            do
            {
                var glitch = glitches[RNG.Random.Next(glitches.Count)];
                if (!glitch.Parent.Contains("Compress") || isAllowingCompression)
                {
                    this.formBitmap = glitch.Method.Invoke(this.formBitmap);
                    amount--;
                }
            }
            while (amount > 0);
        }

        private void RandomToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var collageBitmap = new Bitmap(this.formBitmap.Width * 3, this.formBitmap.Height * 3);
            var collageGraphics = Graphics.FromImage(collageBitmap);
            var folderName = Path.GetTempFileName() + "x" + Path.DirectorySeparatorChar;
            Directory.CreateDirectory(folderName);
            var originalImage = (Bitmap)this.formBitmap.Clone();
            for (int i = 0; i < 10; i++)
            {
                this.Text = "Creating Image " + (i + 1) + " of 10...";
                GC.Collect();
                GC.GetTotalMemory(forceFullCollection: true);
                this.formBitmap = (Bitmap)originalImage.Clone();
                this.formGraphics = Graphics.FromImage(this.formBitmap);
                this.ApplyRandomGlitch(RNG.Random.Next(3, 10), isAllowingCompression: false);
                if (i < 10)
                {
                    var x = i % 3;
                    var y = (int)(i / 3);
                    collageGraphics.DrawImage(this.formBitmap, new RectangleF(this.formBitmap.Width * x, this.formBitmap.Height * y, this.formBitmap.Width, this.formBitmap.Height));
                }
                this.Invalidate();
                this.Refresh();
                var imageCopy = new Bitmap(this.formBitmap);
                this.formBitmap.Dispose();
                this.formBitmap = imageCopy;
                this.formBitmap.Save(folderName + string.Format("{0:00}.png", i), Glitches.GetEncoder(ImageFormat.Png), null);
                this.formBitmap.Dispose();
                this.formGraphics.Dispose();
                this.formBitmap = new Bitmap(100, 100);
                this.formGraphics = Graphics.FromImage(this.formBitmap);
                imageCopy.Dispose();
            }

            collageBitmap.Save(folderName + "Collage.png", Glitches.GetEncoder(ImageFormat.Png), null);
            collageBitmap.Dispose();
            collageGraphics.Dispose();

            this.formBitmap = (Bitmap)originalImage.Clone();
            originalImage.Dispose();
            Process.Start(folderName);
            this.Text = MakeVersionNumber();
            this.Invalidate();
            this.Refresh();
        }

        private void SaveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            sfd.Filter = "Images|*.png;*.jpg";
            sfd.ShowDialog();
            if (sfd.FileName != string.Empty)
            {
                if (sfd.FileName.ToLower().EndsWith("png"))
                {
                    this.formBitmap.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Png);
                }
                else if(sfd.FileName.ToLower().EndsWith("jpg") || sfd.FileName.ToLower().EndsWith("jpeg"))
                {
                    this.formBitmap.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
            }
        }

        private void SaveLatestImage()
        {
            this.filenames.Push(Path.GetTempFileName() + ".png");
            var imageCopy = new Bitmap(this.formBitmap);
            this.formBitmap.Dispose();
            this.formBitmap = imageCopy;
            this.formBitmap.Save(this.filenames.Peek(), Glitches.GetEncoder(ImageFormat.Png), null);
            this.formBitmap.Dispose();
            this.formBitmap = new Bitmap(this.filenames.Peek());
            this.formGraphics = Graphics.FromImage(this.formBitmap);
            this.Invalidate();
            imageCopy.Dispose();
            this.UndoToolStripMenuItem.Enabled = true;
        }

        private string MakeVersionNumber()
        {
            Version ver = System.Reflection.Assembly.GetEntryAssembly().GetName().Version;
            string ret = Application.ProductName.ToString() + " v" + ver.Major;
            if (ver.Minor != 0 || ver.Build != 0 || ver.Revision != 0)
            {
                ret += "." + ver.Minor;
                if (ver.Build != 0 || ver.Revision != 0)
                {
                    ret += "." + ver.Build;
                    if (ver.Revision != 0)
                    {
                        ret += "." + ver.Revision;
                    }
                }
            }

            return ret;
        }
    }
}