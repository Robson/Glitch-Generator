namespace GlitchGenerator
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Windows.Forms;

    internal class InitialImages
    {
        internal List<IInitialImage> GetInitialImageTypes()
        {
            return new List<IInitialImage>()
            {
                new InitialImageBlank(),
                new InitialImageImages(),
                new InitialImageNoiseBinary(),
                new InitialImageNoiseColour(),
                new InitialImageNoiseMonochrome(),
                new InitialImageNoiseMonochromeSquares(),
                new InitialImageShapes(),
            };
        }

        internal class InitialImageBlank : IInitialImage
        {
            public string GetName()
            {
                return "Blank";
            }

            public bool IsPossible()
            {
                return false;
            }

            public Bitmap GenerateImage(int width, int height, bool isPreview)
            {
                var bitmap = new Bitmap(width, height);
                var graphics = Graphics.FromImage(bitmap);
                graphics.Clear(Color.White);
                return bitmap;
            }
        }

        internal class InitialImageImages : IInitialImage
        {
            public string GetName()
            {
                return "Images";
            }

            public bool IsPossible()
            {
                return Directory.Exists(Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "Examples");
            }

            public Bitmap GenerateImage(int width, int height, bool isPreview)
            {
                var multiplier = isPreview ? 0.2 : 0.75 + (((width + height / 2) - 500) / 2000);
                var bitmap = new Bitmap(width, height);
                var graphics = Graphics.FromImage(bitmap);
                var border = isPreview ? 50 : 300;
                graphics.Clear(Color.Black);
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                var sources = Directory.GetFiles(Path.GetDirectoryName(Application.ExecutablePath) + Path.DirectorySeparatorChar + "Examples", "*.*");

                for (int i = 0; i < (isPreview ? 50 : 100); i++)
                {
                    var source = new Bitmap(sources[RNG.Random.Next(sources.Length)]);
                    var sourceW = RNG.Random.Next((int)(source.Width * 0.25), source.Width);
                    var sourceH = RNG.Random.Next((int)(source.Height * 0.25), source.Height);
                    var sourceX = RNG.Random.Next(0, source.Width - sourceW);
                    var sourceY = RNG.Random.Next(0, source.Height - sourceH);
                    var destinationW = (int)(sourceW * multiplier);
                    var destinationH = (int)(sourceH * multiplier);
                    if (destinationW > bitmap.Width + border ||
                        destinationH > bitmap.Height + border)
                    {
                        i--;
                        continue;
                    }

                    var destinationX = RNG.Random.Next(-border, (bitmap.Width + border) - destinationW);
                    var destinationY = RNG.Random.Next(-border, (bitmap.Height + border) - destinationH);
                    graphics.DrawImage(source, new Rectangle(destinationX, destinationY, destinationW, destinationH), new Rectangle(sourceX, sourceY, sourceW, sourceH), GraphicsUnit.Point);
                }

                return bitmap;
            }
        }

        internal class InitialImageNoiseBinary : IInitialImage
        {
            public string GetName()
            {
                return "Noise, Binary";
            }

            public bool IsPossible()
            {
                return true;
            }

            public Bitmap GenerateImage(int width, int height, bool isPreview)
            {
                var bitmap = new Bitmap(width, height);
                for (int y = 0; y < height; )
                {
                    var h = 16 * (isPreview ? RNG.Random.Next(2, 4) : RNG.Random.Next(2, 6));
                    Glitches.GenerateBinaryNoiseAtLocation(bitmap, new Rectangle(0, y, width, h));
                    y += h;
                }

                return bitmap;
            }
        }

        internal class InitialImageNoiseColour : IInitialImage
        {
            public string GetName()
            {
                return "Noise, Pixels, Colour";
            }

            public bool IsPossible()
            {
                return true;
            }

            public Bitmap GenerateImage(int width, int height, bool isPreview)
            {
                return Glitches.GenerateColourNoiseAtLocation(new Bitmap(width, height), new Rectangle(0, 0, width, height));
            }
        }

        internal class InitialImageNoiseMonochrome : IInitialImage
        {
            public string GetName()
            {
                return "Noise, Pixels, Monochrome";
            }

            public bool IsPossible()
            {
                return true;
            }

            public Bitmap GenerateImage(int width, int height, bool isPreview)
            {
                return Glitches.GenerateMonochromeNoiseAtLocation(new Bitmap(width, height), new Rectangle(0, 0, width, height));
            }
        }

        internal class InitialImageNoiseMonochromeSquares : IInitialImage
        {
            public string GetName()
            {
                return "Noise, Squares, Monochrome";
            }

            public bool IsPossible()
            {
                return true;
            }

            public Bitmap GenerateImage(int width, int height, bool isPreview)
            {
                var bitmap = new Bitmap(width, height);
                for (int y = 0; y < height;)
                {
                    var h = 16 * (isPreview ? RNG.Random.Next(2, 4) : RNG.Random.Next(2, 6));
                    Glitches.GenerateMonochromeSquareNoiseAtLocation(bitmap, new Rectangle(0, y, width, h));
                    y += h;
                }

                return bitmap;
            }
        }

        internal class InitialImageShapes : IInitialImage
        {
            public string GetName()
            {
                return "Shapes";
            }

            public bool IsPossible()
            {
                return true;
            }

            public Bitmap GenerateImage(int width, int height, bool isPreview)
            {
                var max = (width + height) / 4;
                var bitmap = new Bitmap(width, height);
                var graphics = Graphics.FromImage(bitmap);
                graphics.Clear(Color.White);
                graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                for (int i = 0; i < 2000; i++)
                {
                    var colour = Color.FromArgb(RNG.Random.Next(255), RNG.Random.Next(255), RNG.Random.Next(255), RNG.Random.Next(255));
                    int sizeX = RNG.Random.Next(25, max), sizeY = RNG.Random.Next(25, max);
                    int x = RNG.Random.Next(width), y = RNG.Random.Next(height);
                    switch (RNG.Random.Next(4))
                    {
                        case 0:
                            graphics.FillEllipse(new SolidBrush(colour), x, y, sizeX, sizeY);
                            break;

                        case 1:
                            graphics.FillRectangle(new SolidBrush(colour), x - sizeX / 2, y - sizeY / 2, sizeX / 2, sizeY / 2);
                            break;

                        case 2:
                            int nx = x + RNG.Random.Next(-max, max), ny = y + RNG.Random.Next(-max, max);
                            graphics.DrawLine(new Pen(colour, RNG.Random.Next(1, 30)), x, y, nx, ny);
                            break;

                        case 3:
                            var points = new List<Point>();
                            var amount = RNG.Random.Next(3, 6) * 2;
                            for (int p = 0; p < amount; p++)
                            {
                                points.Add(new Point(x + RNG.Random.Next(-max, max), y + RNG.Random.Next(-max, max)));
                            }

                            graphics.FillPolygon(new SolidBrush(colour), points.ToArray());
                            break;
                    }
                }

                return bitmap;
            }
        }
    }
}
