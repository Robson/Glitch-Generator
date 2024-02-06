namespace GlitchGenerator
{
    using System;
    using System.Collections.Generic;

    internal static class RNG
    {
        public static Random Random { get; set; }

        public static void RandomizeList<T>(List<T> list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int randomIndex = Random.Next(0, i + 1);
                T temp = list[i];
                list[i] = list[randomIndex];
                list[randomIndex] = temp;
            }
        }
    }
}