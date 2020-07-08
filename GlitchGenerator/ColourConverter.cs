namespace GlitchGenerator
{
    using System;
    using System.Drawing;

    internal static class ColourConverter
    {
        internal static HSB RGBtoHSB(RGB rgb)
        {
            decimal red = rgb.R / 255m, green = rgb.G / 255m, blue = rgb.B / 255m;
            decimal minValue = Math.Min(red, Math.Min(green, blue));
            decimal maxValue = Math.Max(red, Math.Max(green, blue));
            decimal s = 0, v = maxValue;
            decimal h = (int)Color.FromArgb(rgb.R, rgb.G, rgb.B).GetHue();

            if (maxValue != 0)
            {
                s = 1m - (minValue / maxValue);
            }

            return new HSB
            {
                H = Convert.ToInt32(Math.Round(h, MidpointRounding.AwayFromZero)),
                S = Convert.ToInt32(Math.Round(s * 100, MidpointRounding.AwayFromZero)),
                B = Convert.ToInt32(Math.Round(v * 100, MidpointRounding.AwayFromZero))
            };
        }

        internal static HSL RGBtoHSL(RGB rgb)
        {
            var color = Color.FromArgb(rgb.R, rgb.G, rgb.B);
            return new HSL
            {
                H = (int)color.GetHue(),
                S = (int)(color.GetSaturation() * 100),
                L = (int)(color.GetBrightness() * 100)
            };
        }

        internal static RGB HSBtoRGB(HSB hsb)
        {
            decimal hue = hsb.H, sat = hsb.S / 100m, val = hsb.B / 100m;

            decimal r = 0, g = 0, b = 0;

            if (sat == 0)
            {
                r = val;
                g = val;
                b = val;
            }
            else
            {
                decimal sectorPos = hue / 60m;
                int sectorNumber = Convert.ToInt32(Math.Floor(sectorPos));

                decimal fractionalSector = sectorPos - sectorNumber;

                decimal p = val * (1 - sat);
                decimal q = val * (1 - (sat * fractionalSector));
                decimal t = val * (1 - (sat * (1 - fractionalSector)));

                switch (sectorNumber)
                {
                    case 0:
                    case 6:
                        r = val;
                        g = t;
                        b = p;
                        break;
                    case 1:
                        r = q;
                        g = val;
                        b = p;
                        break;
                    case 2:
                        r = p;
                        g = val;
                        b = t;
                        break;
                    case 3:
                        r = p;
                        g = q;
                        b = val;
                        break;
                    case 4:
                        r = t;
                        g = p;
                        b = val;
                        break;
                    case 5:
                        r = val;
                        g = p;
                        b = q;
                        break;
                }
            }

            return new RGB
            {
                R = Convert.ToInt32(Math.Round(r * 255, MidpointRounding.AwayFromZero)),
                G = Convert.ToInt32(Math.Round(g * 255, MidpointRounding.AwayFromZero)),
                B = Convert.ToInt32(Math.Round(b * 255, MidpointRounding.AwayFromZero))
            };
        }

        internal struct HSB
        {
            public int H;
            public int S;
            public int B;
        }

        internal struct HSL
        {
            public int H;
            public int S;
            public int L;
        }

        internal struct RGB
        {
            public int R;
            public int G;
            public int B;
        }
    }
}
