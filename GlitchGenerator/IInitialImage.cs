namespace GlitchGenerator
{
    using System.Drawing;

    interface IInitialImage
    {
        string GetName();

        bool IsPossible();

        Bitmap GenerateImage(int width, int height, bool isPreview);
    }
}
