using System;

namespace MyFirstPlugin.Utilities
{
    public class Numbers
    {
        // Returns 
        public static bool PercentageChange(float percent)
        {
            Random rand = new();
            return percent < rand.NextDouble() * 100;
        }

        public static int GetRandomInt(int lower, int upper)
        {
            Random rand = new();
            return rand.Next(lower, upper);
        }

    }
}

