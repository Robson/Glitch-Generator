namespace GlitchGenerator
{
    using System;
    using System.Diagnostics.SymbolStore;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.IO;
    using System.Linq;
    using System.Threading;

    internal static class Glitches
    {
        private enum Blocks
        {
            Image,
            Monochrome,
            Random,
            SingleRandom,
        }

        internal static Bitmap BlocksImage(Bitmap bitmap)
        {
            return RandomBlocks(Blocks.Image, bitmap);
        }

        internal static Bitmap BlocksMonochrome(Bitmap bitmap)
        {
            return RandomBlocks(Blocks.Monochrome, bitmap);
        }

        internal static Bitmap BlocksRandom(Bitmap bitmap)
        {
            return RandomBlocks(Blocks.Random, bitmap);
        }

        internal static Bitmap BlocksSingleRandom(Bitmap bitmap)
        {
            return RandomBlocks(Blocks.SingleRandom, bitmap);
        }

        internal static Bitmap BlocksDisplacement(Bitmap bitmap)
        {
            var height = RNG.Random.Next(5, 100);
            var startY = RNG.Random.Next(bitmap.Height - height);
            var graphics = Graphics.FromImage(bitmap);
            var original = new Bitmap(bitmap);

            for (int i = 0; i < bitmap.Width + height; i += height)
            {
                // grab part of the image from somewhere else
                graphics.DrawImage(
                    original,
                    new Rectangle(
                        i,
                        startY,
                        height,
                        height),
                    new Rectangle(
                        RNG.Random.Next(0, bitmap.Width - height),
                        RNG.Random.Next(0, bitmap.Height - height),
                        height,
                        height),
                    GraphicsUnit.Pixel);
            }

            return bitmap;
        }

        internal static Bitmap Compress1(Bitmap bitmap)
        {
            return CompressToLevel(bitmap, 1);
        }

        internal static Bitmap Compress25(Bitmap bitmap)
        {
            return CompressToLevel(bitmap, 25);
        }

        internal static Bitmap Compress50(Bitmap bitmap)
        {
            return CompressToLevel(bitmap, 50);
        }

        internal static Bitmap Compress75(Bitmap bitmap)
        {
            return CompressToLevel(bitmap, 75);
        }

        internal static Bitmap CompressRandom(Bitmap bitmap)
        {
            return CompressToLevel(bitmap, RNG.Random.Next(1, 90));
        }

        internal static Bitmap CompressRepeat1(Bitmap bitmap)
        {
            return RepeatedCompressToLevel(bitmap, 1);
        }

        internal static Bitmap CompressRepeat25(Bitmap bitmap)
        {
            return RepeatedCompressToLevel(bitmap, 25);
        }

        internal static Bitmap CompressRepeat50(Bitmap bitmap)
        {
            return RepeatedCompressToLevel(bitmap, 50);
        }

        internal static Bitmap CompressRepeat75(Bitmap bitmap)
        {
            return RepeatedCompressToLevel(bitmap, 75);
        }

        internal static Bitmap CompressRepeatRandom(Bitmap bitmap)
        {
            return RepeatedCompressToLevel(bitmap, RNG.Random.Next(1, 90));
        }

        internal static Bitmap EndCorruptionFreeze(Bitmap bitmap)
        {
            var graphics = Graphics.FromImage(bitmap);
            var imageCopy = new Bitmap(bitmap);

            var amount = (int)((float)RNG.Random.Next(80, 95) / 100f * bitmap.Height);
            var offset = RNG.Random.Next(-5, 6);

            for (int y = amount; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var colour = imageCopy.GetPixel(x, amount - 1);
                    var xModified = (x + (offset * (y - amount)) + bitmap.Width) % bitmap.Width;
                    graphics.FillRectangle(new SolidBrush(colour), new Rectangle(xModified, y, 1, 1));
                }
            }

            return bitmap;
        }

        internal static Bitmap EndCorruptionRandomLines(Bitmap bitmap)
        {
            var graphics = Graphics.FromImage(bitmap);

            var amount = (int)((float)RNG.Random.Next(50, 95) / 100f * bitmap.Height);

            for (int y = amount; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width;)
                {
                    var amountX = RNG.Random.Next(10, 100);
                    var colour = Color.FromArgb(RNG.Random.Next(100, 200), RNG.Random.Next(255), RNG.Random.Next(255), RNG.Random.Next(255));
                    graphics.FillRectangle(new SolidBrush(colour), new Rectangle(x, y, amountX, 1));
                    x += amountX;
                }
            }

            return bitmap;
        }

        internal static Bitmap EndCorruptionStretch(Bitmap bitmap)
        {
            var graphics = Graphics.FromImage(bitmap);

            var amount = (int)((float)RNG.Random.Next(50, 95) / 100f * bitmap.Height);

            for (int y = amount; y < bitmap.Height;)
            {
                var amountY = RNG.Random.Next(1, 5);
                for (int x = 0; x < bitmap.Width;)
                {
                    var amountX = RNG.Random.Next(10, 100);
                    var colour = GetAverageColour(bitmap, new Rectangle(x, y, amountX, amountY));
                    graphics.FillRectangle(new SolidBrush(colour), new Rectangle(x, y, amountX, amountY));
                    x += amountX;
                }

                y += amountY;
            }

            return bitmap;
        }

        internal static Bitmap FileCorruptBlank(Bitmap bitmap)
        {            
            var duplicate = (Image)bitmap.Clone();
            var filename = CreateRandomTemporaryFilename();
            duplicate.Save(filename);
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite))
            {
                int blankLength = RNG.Random.Next(1, 10);
                long blankIndex = RNG.Random.Next((int)stream.Length - blankLength);

                for (int position = 0; position < blankLength; position++)
                {
                    stream.Position = blankIndex + position;
                    stream.WriteByte(0x00);
                }
            }
                        
            var input = (Bitmap)Image.FromFile(filename);
            var output = new Bitmap(bitmap.Width, bitmap.Height);
            var graphics = Graphics.FromImage(output);
            graphics.DrawImage(input, 0, 0, bitmap.Width, bitmap.Height);

            return output;
        }

        internal static Bitmap FileCorruptDelete(Bitmap bitmap)
        {            
            var duplicate = (Image)bitmap.Clone();
            var filename = CreateRandomTemporaryFilename();
            duplicate.Save(filename);
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite))
            {
                int skipLength = RNG.Random.Next(1, 10);
                long skipIndex = RNG.Random.Next((int)stream.Length - skipLength);

                int bufferSize;
                checked
                {
                    bufferSize = (int)(stream.Length - (skipLength + skipIndex));
                }

                byte[] buffer = new byte[bufferSize];

                // read all data after
                stream.Position = skipIndex + skipLength;
                stream.Read(buffer, 0, bufferSize);

                // write to displacement
                stream.Position = skipIndex;
                stream.Write(buffer, 0, bufferSize);
                stream.SetLength(stream.Position); // trim the file
            }

            var input = (Bitmap)Image.FromFile(filename);
            var output = new Bitmap(bitmap.Width, bitmap.Height);
            var graphics = Graphics.FromImage(output);
            graphics.DrawImage(input, 0, 0, bitmap.Width, bitmap.Height);

            return output;
        }

        internal static Bitmap FileCorruptNoise(Bitmap bitmap)
        {            
            var duplicate = (Image)bitmap.Clone();
            var filename = CreateRandomTemporaryFilename();
            duplicate.Save(filename);
            using (var stream = new FileStream(filename, FileMode.Open, FileAccess.ReadWrite))
            {
                int noiseLength = RNG.Random.Next(1, 10);
                long noiseIndex = RNG.Random.Next((int)stream.Length - noiseLength);

                var bytes = new byte[noiseLength];
                RNG.Random.NextBytes(bytes);

                for (int position = 0; position < noiseLength; position++)
                {
                    stream.Position = noiseIndex + position;
                    stream.WriteByte(bytes[position]);
                }
            }

            var input = (Bitmap)Image.FromFile(filename);
            var output = new Bitmap(bitmap.Width, bitmap.Height);
            var graphics = Graphics.FromImage(output);
            graphics.DrawImage(input, 0, 0, bitmap.Width, bitmap.Height);

            return output;
        }

        internal static Bitmap HorizontalMirror(Bitmap bitmap)
        {
            var graphics = Graphics.FromImage(bitmap);
            var height = RNG.Random.Next(5, 100);
            var startY = RNG.Random.Next(bitmap.Height - height);
            var imageCopy = new Bitmap(bitmap);

            for (int y = startY; y < startY + height; y++)
            {
                for (int x = 1; x <= bitmap.Width; x++)
                {
                    var colour = imageCopy.GetPixel(bitmap.Width - x, y);
                    graphics.FillRectangle(new SolidBrush(colour), new Rectangle(x, y, 1, 1));
                }
            }

            return bitmap;
        }

        internal static Bitmap HorizontalErrorBars(Bitmap bitmap)
        {
            var graphics = Graphics.FromImage(bitmap);
            var colour = RNG.Random.NextDouble() > 0.5 ? Brushes.Black : Brushes.White;

            for (int y = RNG.Random.Next(50, 150); y < bitmap.Height + 500; y+=RNG.Random.Next(100, 300))
            {
                var heightBlock = RNG.Random.Next(25, 75);
                var heightRandom = RNG.Random.Next(5, 15);
                var width = 25 * RNG.Random.Next(1, 5);
                var startY = y + (3 * heightRandom);

                graphics.FillRectangle(colour, new RectangleF(0, startY, bitmap.Width, heightBlock));
                if (RNG.Random.NextDouble() > 0.5)
                {
                    for (int x = 0; x < bitmap.Width + width; x += width)
                    {
                        var height = heightRandom * RNG.Random.Next(0, 3);
                        graphics.FillRectangle(colour, new RectangleF(x, startY - height, width, height));
                    }
                }

                if (RNG.Random.NextDouble() > 0.5)
                {
                    for (int x = 0; x < bitmap.Width + width; x += width)
                    {
                        var height = heightRandom * RNG.Random.Next(0, 3);
                        graphics.FillRectangle(colour, new RectangleF(x, startY + heightBlock, width, height));
                    }
                }
            }

            return bitmap;
        }

        internal static Bitmap HorizontalColourNoise(Bitmap bitmap)
        {
            var height = RNG.Random.Next(5, 100);
            var startY = RNG.Random.Next(bitmap.Height - height);
            return GenerateColourNoiseAtLocation(bitmap, new Rectangle(0, startY, bitmap.Width, height));
        }

        internal static Bitmap HorizontalMonochromeNoise(Bitmap bitmap)
        {
            var height = RNG.Random.Next(5, 100);
            var startY = RNG.Random.Next(bitmap.Height - height);
            return GenerateMonochromeNoiseAtLocation(bitmap, new Rectangle(0, startY, bitmap.Width, height));
        }

        internal static Bitmap HorizontalBinaryNoise(Bitmap bitmap)
        {
            var height = 16 * RNG.Random.Next(2, 6);
            var startY = RNG.Random.Next(bitmap.Height - height);
            return GenerateBinaryNoiseAtLocation(bitmap, new Rectangle(0, startY, bitmap.Width, height));
        }

        internal static Bitmap HorizontalOffsetSingle(Bitmap bitmap)
        {
            var graphics = Graphics.FromImage(bitmap);
            var height = RNG.Random.Next(5, 100);
            var startY = RNG.Random.Next(bitmap.Height - height);
            var imageCopy = new Bitmap(bitmap);
            var offsetAmount = RNG.Random.Next(-100, 100);

            for (int y = startY; y < startY + height; y++)
            {
                for (int x = 1; x <= bitmap.Width; x++)
                {
                    var colour = imageCopy.GetPixel((x + offsetAmount + imageCopy.Width) % imageCopy.Width, y);
                    graphics.FillRectangle(new SolidBrush(colour), new Rectangle(x, y, 1, 1));
                }
            }

            return bitmap;
        }

        internal static Bitmap HorizontalOffsetAllWavey(Bitmap bitmap)
        {
            var imageCopy = new Bitmap(bitmap);
            var pn = new PerlinNoise();
            var vertical = 1;

            var z = RNG.Random.NextDouble() * 1000;
            for (int y = 0; y < bitmap.Height; y += vertical)
            {                
                var p1 = bitmap.Height * pn.OctavePerlin((float)y / (float)bitmap.Height, 0, z, 1, 1);
                var p2 = bitmap.Height * pn.OctavePerlin((float)y / (float)bitmap.Height, 0, z, 10, 0.5);
                var offsetAmount = (int)((p1 + p2) - bitmap.Height);
                for (int y2 = y; y2 < y + vertical && y2 < bitmap.Height; y2++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        var colour = imageCopy.GetPixel((x + offsetAmount + bitmap.Width) % bitmap.Width, y2);
                        bitmap.SetPixel(x, y2, colour);
                    }
                }
            }

            return bitmap;
        }

        internal static Bitmap HorizontalOffsetAllRandom(Bitmap bitmap)
        {
            var imageCopy = new Bitmap(bitmap);
            var pn = new PerlinNoise();
            var vertical = RNG.Random.Next(1, 15);
            var bumpy = 0.25 + RNG.Random.NextDouble();

            var z = RNG.Random.NextDouble() * 1000;
            for (int y = 0; y < bitmap.Height; y += vertical)
            {
                var p1 = bitmap.Height * pn.OctavePerlin((float)y / (float)bitmap.Height, 0, z, 1, 1);
                var p2 = bitmap.Height * pn.OctavePerlin((float)y / (float)bitmap.Height, 0, z, 10, bumpy);
                var offsetAmount = (int)((p1 + p2) - bitmap.Height);
                for (int y2 = y; y2 < y + vertical && y2 < bitmap.Height; y2++)
                {
                    for (int x = 0; x < bitmap.Width; x++)
                    {
                        var colour = imageCopy.GetPixel((x + offsetAmount + bitmap.Width) % bitmap.Width, y2);
                        bitmap.SetPixel(x, y2, colour);
                    }
                }
            }

            return bitmap;
        }

        internal static Bitmap HorizontalFreezeRandom(Bitmap bitmap)
        {
            var graphics = Graphics.FromImage(bitmap);
            for (int y = 0; y < bitmap.Height; y++)
            {
                var x = RNG.Random.Next((int)(bitmap.Width * 0.9));
                var colour = bitmap.GetPixel(x, y);
                graphics.FillRectangle(new SolidBrush(colour), new Rectangle(x, y, bitmap.Width - x, 1));
            }

            return bitmap;
        }

        internal static Bitmap HorizontalFreezeFixed(Bitmap bitmap)
        {
            var x = (int)(bitmap.Width * 0.1) + RNG.Random.Next((int)(bitmap.Width * 0.8));
            var graphics = Graphics.FromImage(bitmap);
            for (int y = 0; y < bitmap.Height; y++)
            {
                var colour = bitmap.GetPixel(x, y);
                graphics.FillRectangle(new SolidBrush(colour), new Rectangle(x, y, bitmap.Width - x, 1));
            }

            return bitmap;
        }

        internal static Bitmap HorizontalFreezeWavesBumpy(Bitmap bitmap)
        {
            return HorizontalFrozenWaves(bitmap, isSmooth: false);
        }

        internal static Bitmap HorizontalFreezeWavesSmooth(Bitmap bitmap)
        {
            return HorizontalFrozenWaves(bitmap, isSmooth: true);
        }

        internal static Bitmap HueGradientRainbow(Bitmap bitmap)
        {
            var graphics = Graphics.FromImage(bitmap);
            var offset = RNG.Random.Next(360);
            var direction = RNG.Random.NextDouble() > 0.5 ? 1 : -1;
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var randomHue = (offset + (direction * (int)(360f * ((float)x / (float)bitmap.Width)))) % 360;

                    var colour = bitmap.GetPixel(x, y);
                    var hsb = ColourConverter.RGBtoHSB(new ColourConverter.RGB() { R = colour.R, G = colour.G, B = colour.B });
                    hsb.H = randomHue;
                    var rgb = ColourConverter.HSBtoRGB(hsb);
                    var newColour = Color.FromArgb(rgb.R, rgb.G, rgb.B);
                    graphics.FillRectangle(new SolidBrush(newColour), new Rectangle(x, y, 1, 1));
                }
            }

            return bitmap;
        }

        internal static Bitmap HueGradientRandom(Bitmap bitmap)
        {
            var graphics = Graphics.FromImage(bitmap);
            var start = RNG.Random.Next(360);
            var amount = RNG.Random.Next(360);
            var direction = RNG.Random.NextDouble() > 0.5 ? 1 : -1;
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var randomHue = (360 + start + (direction * (int)(amount * ((float)x / (float)bitmap.Width)))) % 360;

                    var colour = bitmap.GetPixel(x, y);
                    var hsb = ColourConverter.RGBtoHSB(new ColourConverter.RGB() { R = colour.R, G = colour.G, B = colour.B });
                    hsb.H = randomHue;
                    var rgb = ColourConverter.HSBtoRGB(hsb);
                    var newColour = Color.FromArgb(rgb.R, rgb.G, rgb.B);
                    graphics.FillRectangle(new SolidBrush(newColour), new Rectangle(x, y, 1, 1));
                }
            }

            return bitmap;
        }

        internal static Bitmap HueLuminosity(Bitmap bitmap)
        {
            var randomHueStart = RNG.Random.Next(360);
            var randomHueFinish = RNG.Random.Next(360);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var colour = bitmap.GetPixel(x, y);
                    var average = (colour.R + colour.G + colour.B) / 3;
                    var hue = Map(average, 0, 255, randomHueStart, randomHueFinish);
                    var hsb = new ColourConverter.HSB() { H = (int)hue, B = 100, S = 100 };
                    var rgb = ColourConverter.HSBtoRGB(hsb);
                    var newColour = Color.FromArgb(rgb.R, rgb.G, rgb.B);
                    bitmap.SetPixel(x, y, newColour);
                }
            }

            return bitmap;
        }

        internal static Bitmap HueShift(Bitmap bitmap)
        {
            var graphics = Graphics.FromImage(bitmap);
            var offset = RNG.Random.Next(10, 350);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var colour = bitmap.GetPixel(x, y);
                    var hsb = ColourConverter.RGBtoHSB(new ColourConverter.RGB() { R = colour.R, G = colour.G, B = colour.B });
                    hsb.H += offset;
                    hsb.H %= 360;
                    var rgb = ColourConverter.HSBtoRGB(hsb);
                    var newColour = Color.FromArgb(rgb.R, rgb.G, rgb.B);
                    graphics.FillRectangle(new SolidBrush(newColour), new Rectangle(x, y, 1, 1));
                }
            }

            return bitmap;
        }

        internal static Bitmap HueUnify(Bitmap bitmap)
        {
            var graphics = Graphics.FromImage(bitmap);
            var randomHue = RNG.Random.Next(360);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var colour = bitmap.GetPixel(x, y);
                    var hsb = ColourConverter.RGBtoHSB(new ColourConverter.RGB() { R = colour.R, G = colour.G, B = colour.B });
                    hsb.H = randomHue;
                    var rgb = ColourConverter.HSBtoRGB(hsb);
                    var newColour = Color.FromArgb(rgb.R, rgb.G, rgb.B);
                    graphics.FillRectangle(new SolidBrush(newColour), new Rectangle(x, y, 1, 1));
                }
            }

            return bitmap;
        }

        internal static Bitmap OffsetRed(Bitmap bitmap)
        {
            return OffsetImage(bitmap, RNG.Random.Next(-100, 100), RNG.Random.Next(-100, 100), isOffsettingRed: true, isOffsettingGreen: false, isOffsettingBlue: false);
        }

        internal static Bitmap OffsetGreen(Bitmap bitmap)
        {
            return OffsetImage(bitmap, RNG.Random.Next(-100, 100), RNG.Random.Next(-100, 100), isOffsettingRed: false, isOffsettingGreen: true, isOffsettingBlue: false);
        }

        internal static Bitmap OffsetBlue(Bitmap bitmap)
        {
            return OffsetImage(bitmap, RNG.Random.Next(-100, 100), RNG.Random.Next(-100, 100), isOffsettingRed: false, isOffsettingGreen: false, isOffsettingBlue: true);
        }

        internal static Bitmap OffsetEverything(Bitmap bitmap)
        {
            return OffsetImage(bitmap, RNG.Random.Next(-100, 100), RNG.Random.Next(-100, 100), isOffsettingRed: true, isOffsettingGreen: true, isOffsettingBlue: true);
        }

        internal static Bitmap OverallBorder(Bitmap bitmap)
        {
            var graphics = Graphics.FromImage(bitmap);
            var colour = Color.FromArgb(RNG.Random.Next(255), RNG.Random.Next(255), RNG.Random.Next(255));
            graphics.DrawRectangle(
                new Pen(colour, RNG.Random.Next(7)),
                new Rectangle(1, 1, bitmap.Width - 2, bitmap.Height - 2));
            return bitmap;
        }

        internal static Bitmap OverallDisplacement(Bitmap bitmap)
        {
            var graphics = Graphics.FromImage(bitmap);
            var original = new Bitmap(bitmap);

            for (int i = 0; i < 500; i++)
            {
                var destX = RNG.Random.Next(0, bitmap.Width) - (int)(bitmap.Width * 0.1);
                var destY = RNG.Random.Next(0, bitmap.Width) - (int)(bitmap.Height * 0.1);
                var sourceX = RNG.Random.Next(0, bitmap.Width) - (int)(bitmap.Width * 0.1);
                var sourceY = RNG.Random.Next(0, bitmap.Width) - (int)(bitmap.Height * 0.1);
                var width = RNG.Random.Next((int)(bitmap.Width * 0.1), (int)(bitmap.Width * 0.3));
                var height = RNG.Random.Next((int)(bitmap.Height * 0.1), (int)(bitmap.Height * 0.3));

                graphics.DrawImage(
                    original,
                    new Rectangle(destX, destY, width, height),
                    new Rectangle(sourceX, sourceY, width, height),
                    GraphicsUnit.Pixel);
            }

            return bitmap;
        }

        internal static Bitmap OverallInvertColours(Bitmap bitmap)
        {
            var graphics = Graphics.FromImage(bitmap);
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var colour = bitmap.GetPixel(x, y);
                    var inverted = Color.FromArgb(255 - colour.R, 255 - colour.G, 255 - colour.B);
                    graphics.FillRectangle(new SolidBrush(inverted), new Rectangle(x, y, 1, 1));
                }
            }

            return bitmap;
        }

        internal static Bitmap OverallNoise(Bitmap bitmap)
        {
            var graphics = Graphics.FromImage(bitmap);
            var totalPixels = bitmap.Width * bitmap.Height;
            var amount = (float)RNG.Random.Next(1, 3) / 100f * (float)totalPixels;

            for (int a = 0; a < amount; a++)
            {
                var x = RNG.Random.Next(bitmap.Width);
                var y = RNG.Random.Next(bitmap.Height);
                var colour = Color.FromArgb(128, RNG.Random.Next(255), RNG.Random.Next(255), RNG.Random.Next(255));
                graphics.FillRectangle(new SolidBrush(colour), new Rectangle(x, y, RNG.Random.Next(1, 3), RNG.Random.Next(1, 3)));
            }

            return bitmap;
        }

        internal static Bitmap OverallRgbSplit(Bitmap bitmap)
        {
            var imageCopy = new Bitmap(bitmap);

            int offsetAmountRedX = RNG.Random.Next(-30, 30);
            int offsetAmountGreenX = RNG.Random.Next(-30, 30);
            int offsetAmountBlueX = RNG.Random.Next(-30, 30);
            int offsetAmountRedY = RNG.Random.Next(-30, 30);
            int offsetAmountGreenY = RNG.Random.Next(-30, 30);
            int offsetAmountBlueY = RNG.Random.Next(-30, 30);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var offsetRedX = (x + offsetAmountRedX + bitmap.Width) % bitmap.Width;
                    var offsetRedY = (y + offsetAmountRedY + bitmap.Height) % bitmap.Height;
                    var offsetRedColour = imageCopy.GetPixel(offsetRedX, offsetRedY).R;

                    var offsetGreenX = (x + offsetAmountGreenX + bitmap.Width) % bitmap.Width;
                    var offsetGreenY = (y + offsetAmountGreenY + bitmap.Height) % bitmap.Height;
                    var offsetGreenColour = imageCopy.GetPixel(offsetGreenX, offsetGreenY).G;

                    var offsetBlueX = (x + offsetAmountBlueX + bitmap.Width) % bitmap.Width;
                    var offsetBlueY = (y + offsetAmountBlueY + bitmap.Height) % bitmap.Height;
                    var offsetBlueColour = imageCopy.GetPixel(offsetBlueX, offsetBlueY).B;

                    var rightColour = Color.FromArgb(offsetRedColour, offsetGreenColour, offsetBlueColour);
                    bitmap.SetPixel(x, y, rightColour);
                }
            }

            return bitmap;
        }

        internal static Bitmap OverallScanlines(Bitmap bitmap)
        {
            var graphics = Graphics.FromImage(bitmap);
            for (int y = 0; y < bitmap.Height; y += 2)
            {
                graphics.DrawLine(new Pen(Color.Black), new Point(0, y), new Point(bitmap.Width, y));
            }

            return bitmap;
        }

        internal static Bitmap OverallUniformColourChange(Bitmap bitmap)
        {
            var graphics = Graphics.FromImage(bitmap);
            var colour = Color.FromArgb(RNG.Random.Next(20, 80), RNG.Random.Next(255), RNG.Random.Next(255), RNG.Random.Next(255));
            graphics.FillRectangle(new SolidBrush(colour), new Rectangle(0, 0, bitmap.Width, bitmap.Height));
            return bitmap;
        }

        internal static Bitmap SaturateBright(Bitmap bitmap)
        {
            return SaturateImage(bitmap, 10);
        }

        internal static Bitmap SaturateGreyscale(Bitmap bitmap)
        {
            return SaturateImage(bitmap, 0);
        }

        internal static Bitmap SaturateRandom(Bitmap bitmap)
        {
            return SaturateImage(bitmap, RNG.Random.NextDouble() * 2);
        }

        internal static ImageCodecInfo GetEncoder(ImageFormat format)
        {
            var codecs = ImageCodecInfo.GetImageDecoders();

            foreach (var codec in codecs)
            {
                if (codec.FormatID == format.Guid)
                {
                    return codec;
                }
            }

            return null;
        }

        internal static string CreateRandomTemporaryFilename()
        {
            var folder = Path.GetTempPath() + Path.DirectorySeparatorChar;
            var chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var random = "gg_tmp_";
            do
            {
                random += string.Concat(chars.OrderBy(x => RNG.Random.NextDouble()).Take(8));
            }
            while (File.Exists(folder + random + ".png"));

            return folder + random + ".png";
        }

        internal static Bitmap GenerateColourNoiseAtLocation(Bitmap bitmap, Rectangle rect)
        {
            var graphics = Graphics.FromImage(bitmap);

            for (int y = rect.Y; y < rect.Y + rect.Height; y++)
            {
                for (int x = rect.X; x <= rect.X + rect.Width; x++)
                {
                    var colour = Color.FromArgb(RNG.Random.Next(255), RNG.Random.Next(255), RNG.Random.Next(255));
                    graphics.FillRectangle(new SolidBrush(colour), new Rectangle(x, y, 1, 1));
                }
            }

            return bitmap;
        }

        internal static Bitmap GenerateMonochromeNoiseAtLocation(Bitmap bitmap, Rectangle rect)
        {
            var graphics = Graphics.FromImage(bitmap);

            for (int y = rect.Y; y < rect.Y + rect.Height; y++)
            {
                for (int x = rect.X; x <= rect.X + rect.Width; x++)
                {
                    var colour = RNG.Random.NextDouble() > 0.5 ? Color.Black : Color.White;
                    graphics.FillRectangle(new SolidBrush(colour), new Rectangle(x, y, 1, 1));
                }
            }

            return bitmap;
        }

        internal static Bitmap GenerateBinaryNoiseAtLocation(Bitmap bitmap, Rectangle rect)
        {
            var graphics = Graphics.FromImage(bitmap);
            graphics.FillRectangle(Brushes.White, rect.X, rect.Y, rect.Width, rect.Height);
            for (int x = 0; x < bitmap.Width; x += 0)
            {
                var across = 32 * RNG.Random.Next(1, 3);
                var size = new[] { 4, 8, 16 }[RNG.Random.Next(3)];
                var isBlack = RNG.Random.NextDouble() > 0.5;
                var isStretched = RNG.Random.NextDouble() > 0.5;
                if (isStretched)
                {
                    for (int b = 0; b < rect.Height; b += size)
                    {
                        isBlack = !isBlack;
                        if (isBlack)
                        {
                            graphics.FillRectangle(Brushes.Black, x, rect.Y + b, across, size);
                        }
                    }
                }
                else
                {
                    for (int a = 0; a < across; a += size)
                    {
                        isBlack = !isBlack;
                        for (int b = 0; b < rect.Height; b += size)
                        {
                            isBlack = !isBlack;
                            if (isBlack)
                            {
                                graphics.FillRectangle(Brushes.Black, a + x, rect.Y + b, size, size);
                            }
                        }
                    }
                }

                x += across;
            }

            return bitmap;
        }

        internal static Bitmap GenerateMonochromeSquareNoiseAtLocation(Bitmap bitmap, Rectangle rect)
        {
            var graphics = Graphics.FromImage(bitmap);
            graphics.FillRectangle(Brushes.White, rect.X, rect.Y, rect.Width, rect.Height);
            for (int x = 0; x < bitmap.Width;)
            {
                var across = 32 * RNG.Random.Next(1, 3);
                var size = new[] { 4, 8, 16, 32 }[RNG.Random.Next(4)];
                for (int a = 0; a < across; a += size)
                {
                    for (int b = 0; b < rect.Height; b += size)
                    {
                        if (RNG.Random.NextDouble() > 0.5)
                        {
                            graphics.FillRectangle(Brushes.Black, a + x, rect.Y + b, size, size);
                        }
                    }
                }

                x += across;
            }

            return bitmap;
        }

        internal static Bitmap ReduceColourPalette(Bitmap bitmap)
        {
            var level = RNG.Random.Next(2, 17);
            var sectors = 255f / (float)level;

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var r = (int)(Math.Round(bitmap.GetPixel(x, y).R / sectors) * sectors);
                    var g = (int)(Math.Round(bitmap.GetPixel(x, y).G / sectors) * sectors);
                    var b = (int)(Math.Round(bitmap.GetPixel(x, y).B / sectors) * sectors);
                    bitmap.SetPixel(x, y, Color.FromArgb(255, r, g, b));
                }
            }

            return bitmap;
        }

        private static Bitmap HorizontalFrozenWaves(Bitmap bitmap, bool isSmooth)
        {
            var graphics = Graphics.FromImage(bitmap);
            var start = RNG.Random.NextDouble() * 100;
            var interval = RNG.Random.NextDouble() * 0.01;
            var now = start;

            for (int y = 0; y < bitmap.Height; y++)
            {
                now += interval;
                var x = (int)(bitmap.Width * 0.5) + (int)(((Math.Cos(now) + 1) / 2) * bitmap.Width * 0.4);
                if (!isSmooth)
                {
                    x += RNG.Random.Next((int)(-bitmap.Width * 0.05), (int)(bitmap.Width * 0.05));
                }

                var colour = bitmap.GetPixel(x, y);
                graphics.FillRectangle(new SolidBrush(colour), new Rectangle(x, y, bitmap.Width - x, 1));
            }

            return bitmap;
        }

        private static Bitmap RandomBlocks(Blocks blocks, Bitmap bitmap)
        {
            var graphics = Graphics.FromImage(bitmap);
            var height = RNG.Random.Next(5, 40);
            var startY = RNG.Random.Next(bitmap.Height - height);

            var isSwitch = RNG.Random.NextDouble() > 0.5;
            var isSameWidth = RNG.Random.NextDouble() > 0.5;
            var randomHue = RNG.Random.Next(360);
            var alpha = 255;

            if (RNG.Random.NextDouble() > 0.75)
            {
                alpha = RNG.Random.Next(50, 200);
            }

            var width = height;

            for (int x = 0; x < bitmap.Width + 500;)
            {
                if (!isSameWidth)
                {
                    width = RNG.Random.Next(5, 30);
                }

                var area = new Rectangle(x, startY, width, height);
                var colour = isSwitch ? Color.White : Color.Black;

                switch (blocks)
                {
                    case Blocks.Monochrome:
                        isSwitch = !isSwitch;
                        break;

                    case Blocks.Random:
                        colour = Color.FromArgb(RNG.Random.Next(255), RNG.Random.Next(255), RNG.Random.Next(255));
                        break;

                    case Blocks.SingleRandom:
                        var hsb = new ColourConverter.HSB
                        {
                            H = randomHue,
                            B = RNG.Random.Next(50, 100),
                            S = RNG.Random.Next(100)
                        };

                        var rgb = ColourConverter.HSBtoRGB(hsb);
                        colour = Color.FromArgb(rgb.R, rgb.G, rgb.B);
                        break;

                    case Blocks.Image:
                        colour = GetAverageColour(bitmap, area);
                        break;
                }

                colour = Color.FromArgb(alpha, colour.R, colour.G, colour.B);

                graphics.FillRectangle(new SolidBrush(colour), area);

                x += width;
            }

            return bitmap;
        }

        private static Bitmap OffsetImage(Bitmap bitmap, int offsetAmountX, int offsetAmountY, bool isOffsettingRed, bool isOffsettingGreen, bool isOffsettingBlue)
        {
            var graphics = Graphics.FromImage(bitmap);
            var imageCopy = new Bitmap(bitmap);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var originalColour = imageCopy.GetPixel(x, y);
                    var offsetX = (x + offsetAmountX + bitmap.Width) % bitmap.Width;
                    var offsetY = (y + offsetAmountY + bitmap.Height) % bitmap.Height;
                    var offsetColour = imageCopy.GetPixel(offsetX, offsetY);
                    var nextColour = Color.FromArgb(
                        isOffsettingRed ? originalColour.R : offsetColour.R,
                        isOffsettingGreen ? originalColour.G : offsetColour.G,
                        isOffsettingBlue ? originalColour.B : offsetColour.B);
                    graphics.FillRectangle(new SolidBrush(nextColour), new Rectangle(offsetX, offsetY, 1, 1));
                }
            }

            return bitmap;
        }

        private static Color GetAverageColour(Bitmap bitmap, Rectangle pixels)
        {
            var count = 0;
            int red = 0, green = 0, blue = 0;

            for (int x = 0; x < pixels.Width; x++)
            {
                for (int y = 0; y < pixels.Height; y++)
                {
                    if (pixels.X + x < bitmap.Width &&
                        pixels.Y + y < bitmap.Height)
                    {
                        count++;
                        red += bitmap.GetPixel(pixels.X + x, pixels.Y + y).R;
                        green += bitmap.GetPixel(pixels.X + x, pixels.Y + y).G;
                        blue += bitmap.GetPixel(pixels.X + x, pixels.Y + y).B;
                    }
                }
            }

            if (count > 0)
            {
                return Color.FromArgb(red / count, green / count, blue / count);
            }
            else
            {
                return Color.Transparent;
            }
        }

        private static Bitmap SaturateImage(Bitmap bitmap, double level)
        {
            var graphics = Graphics.FromImage(bitmap);

            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    var colour = bitmap.GetPixel(x, y);
                    var hsb = ColourConverter.RGBtoHSB(new ColourConverter.RGB() { R = colour.R, G = colour.G, B = colour.B });
                    if (hsb.S > 10)
                    {
                        hsb.S = (int)Math.Min(100, hsb.S * level);
                    }

                    var rgb = ColourConverter.HSBtoRGB(hsb);
                    var newColour = Color.FromArgb(rgb.R, rgb.G, rgb.B);
                    graphics.FillRectangle(new SolidBrush(newColour), new Rectangle(x, y, 1, 1));
                }
            }

            return bitmap;
        }

        private static Bitmap RepeatedCompressToLevel(Bitmap bitmap, int level)
        {
            var jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            var myEncoderParameters = new EncoderParameters(1);
            var folder = Path.GetTempPath() + Path.DirectorySeparatorChar.ToString();

            for (int i = 100; i > level; i--)
            {
                var filename = folder + "JpegCompress" + i.ToString() + ".jpg";
                myEncoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, i);
                bitmap.Save(filename, jpgEncoder, myEncoderParameters);
                var tempImage = new Bitmap(filename);
                bitmap = new Bitmap(tempImage);
                tempImage.Dispose();
                Thread.SpinWait(100);
                File.Delete(filename);
                Thread.SpinWait(100);
            }

            return bitmap;
        }

        private static Bitmap CompressToLevel(Bitmap bitmap, int level)
        {
            var jpgEncoder = GetEncoder(ImageFormat.Jpeg);
            var myEncoderParameters = new EncoderParameters(1);
            myEncoderParameters.Param[0] = new EncoderParameter(Encoder.Quality, level);
            var filename = Path.GetTempFileName();
            bitmap.Save(filename + ".jpg", jpgEncoder, myEncoderParameters);
            bitmap.Dispose();
            return new Bitmap(filename + ".jpg");
        }
        
        private static float Map(float s, float a1, float a2, float b1, float b2)
        {
            return b1 + ((s - a1) * (b2 - b1) / (a2 - a1));
        }
    }
}
