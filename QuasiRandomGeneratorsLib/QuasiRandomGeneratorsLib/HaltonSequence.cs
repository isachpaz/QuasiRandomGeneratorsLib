using System;
using System.Collections.Generic;
using System.Linq;

namespace QuasiRandomGeneratorsLib
{
    public class HaltonSequence
    {
        private int _dimension = 0;
        private Dictionary<int, VanDerCorputSequence> _bases;

        public HaltonSequence(int dimension)
        {
            _dimension = dimension;
        }

        public IEnumerable<List<double>> GetSequence()
        {
            InitializeBases();

            long iSequenceIndex = 0L;
            while (iSequenceIndex < long.MaxValue)
            {
                List<double> result = new List<double>();
                for (int i = 1; i <= _dimension; i++)
                {
                    var value = _bases[i].Compute(iSequenceIndex).ToDouble();
                    result.Add(value);
                }
                yield return result;
                iSequenceIndex++;
            }
        }

        private void InitializeBases()
        {
            _bases = new Dictionary<int, VanDerCorputSequence>();
            for (int dimensionIndex = 1; dimensionIndex <= _dimension; dimensionIndex++)
            {
                _bases.Add(dimensionIndex, new VanDerCorputSequence(dimensionIndex+1));
            }
        }
    }
}