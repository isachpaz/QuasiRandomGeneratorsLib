using System;
using System.Collections.Generic;

namespace QuasiRandomGeneratorsLib
{
    public static class MyUtils
    {
        public static IEnumerable<double> ToDouble(this IEnumerable<Tuple<long, long>> input)
        {
            foreach (Tuple<long, long> tuple in input)
            {
               yield return (double)tuple.Item1 / (double)tuple.Item2;
            }
            
        }

        public static double ToDouble(this Tuple<long, long> input)
        {
            return (double) input.Item1 / (double) input.Item2;
        }
    }
}