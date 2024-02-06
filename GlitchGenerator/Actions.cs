namespace GlitchGenerator
{
    using System.Collections.Generic;

    internal static class Actions
    {
        internal static List<Glitch> GetAllGlitches()
        {
            return new List<Glitch>()
            {
                new Glitch("Blocks", "Average Colour", Glitches.BlocksImage),
                new Glitch("Blocks", "Displacement", Glitches.BlocksDisplacement),
                new Glitch("Blocks", "Monochrome", Glitches.BlocksMonochrome),
                new Glitch("Blocks", "Random, Multiple Colours", Glitches.BlocksRandom),
                new Glitch("Blocks", "Random, Single Colour", Glitches.BlocksSingleRandom),
                new Glitch("Compress Once", "1", Glitches.Compress1),
                new Glitch("Compress Once", "25", Glitches.Compress25),
                new Glitch("Compress Once", "50", Glitches.Compress50),
                new Glitch("Compress Once", "75", Glitches.Compress75),
                new Glitch("Compress Once", "Random", Glitches.CompressRandom),
                new Glitch("Compress Repeated", "1", Glitches.CompressRepeat1),
                new Glitch("Compress Repeated", "25", Glitches.CompressRepeat25),
                new Glitch("Compress Repeated", "50", Glitches.CompressRepeat50),
                new Glitch("Compress Repeated", "75", Glitches.CompressRepeat75),
                new Glitch("Compress Repeated", "Random", Glitches.CompressRepeatRandom),
                new Glitch("End Corrupt", "Freeze", Glitches.EndCorruptionFreeze),
                new Glitch("End Corrupt", "Random Lines", Glitches.EndCorruptionRandomLines),
                new Glitch("End Corrupt", "Stretch", Glitches.EndCorruptionStretch),
                new Glitch("File Corrupt", "Blank", Glitches.FileCorruptBlank),
                new Glitch("File Corrupt", "Delete", Glitches.FileCorruptDelete),
                new Glitch("File Corrupt", "Noise", Glitches.FileCorruptNoise),
                new Glitch("Horizontal", "Mirror", Glitches.HorizontalMirror),
                new Glitch("Horizontal", "Error Bars", Glitches.HorizontalErrorBars),
                new Glitch("Horizontal", "Noise, Binary", Glitches.HorizontalBinaryNoise),
                new Glitch("Horizontal", "Noise, Colour", Glitches.HorizontalColourNoise),
                new Glitch("Horizontal", "Noise, Monochrome", Glitches.HorizontalMonochromeNoise),                
                new Glitch("Horizontal", "Offset, All, Random", Glitches.HorizontalOffsetAllRandom),
                new Glitch("Horizontal", "Offset, All, Wavey", Glitches.HorizontalOffsetAllWavey),
                new Glitch("Horizontal", "Offset, Partial", Glitches.HorizontalOffsetSingle),                
                new Glitch("Horizontal Freeze", "Fixed", Glitches.HorizontalFreezeFixed),
                new Glitch("Horizontal Freeze", "Random", Glitches.HorizontalFreezeRandom),
                new Glitch("Horizontal Freeze", "Waves Bumpy", Glitches.HorizontalFreezeWavesBumpy),
                new Glitch("Horizontal Freeze", "Waves Smooth", Glitches.HorizontalFreezeWavesSmooth),                
                new Glitch("Hue", "Gradient Rainbow", Glitches.HueGradientRainbow),
                new Glitch("Hue", "Gradient Random", Glitches.HueGradientRandom),
                new Glitch("Hue", "Luminosity", Glitches.HueLuminosity),
                new Glitch("Hue", "Shift", Glitches.HueShift),
                new Glitch("Hue", "Unify", Glitches.HueUnify),
                new Glitch("Offset Colours", "All", Glitches.OffsetEverything),
                new Glitch("Offset Colours", "Red", Glitches.OffsetRed),
                new Glitch("Offset Colours", "Green", Glitches.OffsetGreen),
                new Glitch("Offset Colours", "Blue", Glitches.OffsetBlue),
                new Glitch("Overall", "Border", Glitches.OverallBorder),
                new Glitch("Overall", "Displacement", Glitches.OverallDisplacement),
                new Glitch("Overall", "Invert Colours", Glitches.OverallInvertColours),
                new Glitch("Overall", "Noise", Glitches.OverallNoise),
                new Glitch("Overall", "Reduce Colour Palette", Glitches.ReduceColourPalette),
                new Glitch("Overall", "RGB Split", Glitches.OverallRgbSplit),
                new Glitch("Overall", "Scanlines", Glitches.OverallScanlines),
                new Glitch("Overall", "Uniform Colour Change", Glitches.OverallUniformColourChange),
                new Glitch("Saturate", "Bright", Glitches.SaturateBright),
                new Glitch("Saturate", "Greyscale", Glitches.SaturateGreyscale),
                new Glitch("Saturate", "Random", Glitches.SaturateRandom),                
            };
        }
    }
}