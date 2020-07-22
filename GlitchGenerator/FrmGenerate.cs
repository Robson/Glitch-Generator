namespace GlitchGenerator
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Windows.Forms;

    public partial class FrmGenerate : Form
    {
        internal Bitmap CreatedInitialImage { get; set; }

        private static List<IInitialImage> types = new InitialImages().GetInitialImageTypes();

        public FrmGenerate()
        {
            InitializeComponent();
            
            foreach (var type in types)
            {
                if (type.IsPossible())
                {
                    this.CbInitialDesign.Items.Add(type.GetName());
                }
            }

            this.CbInitialDesign.SelectedIndex = 0;
            this.Text = "Generate Image";
            ShowPreview();
        }

        private void BtnGenerate_Click(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void ShowPreview()
        {
            foreach (var type in types)
            {
                if (type.GetName() == this.CbInitialDesign.Text)
                {
                    this.PbPreview.Image = type.GenerateImage(this.PbPreview.Width, this.PbPreview.Height, isPreview: true);
                }
            }
        }

        private void CbInitialDesign_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.ShowPreview();
        }

        private void BtnGenerate_Click_1(object sender, System.EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            foreach (var type in types)
            {
                if (type.GetName() == this.CbInitialDesign.Text)
                {
                    this.CreatedInitialImage = type.GenerateImage((int)this.NumWidth.Value, (int)this.NumHeight.Value, isPreview: false);
                }
            }

            this.Close();
        }
    }
}