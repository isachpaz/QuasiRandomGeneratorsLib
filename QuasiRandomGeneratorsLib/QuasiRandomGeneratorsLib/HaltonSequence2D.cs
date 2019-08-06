using System;
using System.Collections.Generic;
using System.Linq;

namespace QuasiRandomGeneratorsLib
{
    public class HaltonSequence2D : HaltonSequence1D
    {
        private VanDerCorputSequence _sequenceY;

        public HaltonSequence2D() : base()
        {
            _sequenceY = new VanDerCorputSequence(3);
        }

        private IEnumerable<double> GetSequenceY()
        {
            foreach (Tuple<long, long> tuple in _sequenceY)
            {
                yield return (double)tuple.Item1 / (double)tuple.Item2;
            }
        }

        public IEnumerable<Tuple<double, double>> GetSequence()
        {
            foreach (var tuple in base.GetSequence().Zip(GetSequenceY(), Tuple.Create))
            {
                yield return tuple;
            }
        }
    }
}