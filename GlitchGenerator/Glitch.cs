namespace GlitchGenerator
{
    using System;
    using System.Drawing;

    internal class Glitch
    {
        internal Glitch(string parent, string name, Converter<Bitmap, Bitmap> method)
        {
            this.Parent = parent;
            this.Name = name;
            this.Method = method;
        }

        internal string Parent { get; set; }

        internal string Name { get; set; }

        internal Converter<Bitmap, Bitmap> Method { get; set; }
    }
}