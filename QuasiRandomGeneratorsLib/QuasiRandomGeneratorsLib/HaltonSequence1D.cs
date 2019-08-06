using System;
using System.Collections.Generic;

namespace QuasiRandomGeneratorsLib
{
    public class HaltonSequence1D
    {
        private VanDerCorputSequence _sequenceX;
        public HaltonSequence1D()
        {
            _sequenceX = new VanDerCorputSequence(2);
        }

        public IEnumerable<double> GetSequence()
        {
            foreach (Tuple<long, long> tuple in _sequenceX)
            {
                yield return (double) tuple.Item1 / (double) tuple.Item2;
            }
        }
    }
}