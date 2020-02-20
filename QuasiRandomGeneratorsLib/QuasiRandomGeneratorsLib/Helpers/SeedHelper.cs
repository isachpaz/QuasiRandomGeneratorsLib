using System;
using System.Diagnostics;
using System.Security.Cryptography;

namespace QuasiRandomGeneratorsLib.Helpers
{
    public static class SeedHelper
    {
        public static int GetRandomSeed(this RNGCryptoServiceProvider rnd, 
            int max = Int32.MaxValue)
        {
            if (max <= 0)
            {
                throw new ArgumentException("max value must be in range [1, Int.Max]");
            }
            byte[] r = new byte[4];
            int value;
            do
            {
                rnd.GetBytes(r);
                value = BitConverter.ToInt32(r, 0) & Int32.MaxValue;
            } while (value >= max * (Int32.MaxValue / max));
            return value % max;
        }

    }
}