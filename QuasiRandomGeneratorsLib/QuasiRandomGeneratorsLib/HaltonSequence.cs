using System;
using System.Collections.Generic;
using System.Linq;

namespace QuasiRandomGeneratorsLib
{
    public class HaltonSequence
    {
        private int _dimension = 0;
        private Lazy<Dictionary<int, VanDerCorputSequence>> _baseSequences;

        public HaltonSequence(int dimension)
        {
            _dimension = dimension;
            _baseSequences = new Lazy<Dictionary<int, VanDerCorputSequence>>( () => new Dictionary<int, VanDerCorputSequence>());
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
                    var value = _baseSequences.Value[i].Compute(iSequenceIndex).ToDouble();
                    result.Add(value);
                }
                yield return result;
                iSequenceIndex++;
            }
        }

        private void InitializeBases()
        {
            for (int dimensionIndex = 1; dimensionIndex <= _dimension; dimensionIndex++)
            {
                _baseSequences.Value.Add(dimensionIndex, new VanDerCorputSequence(dimensionIndex+1));
            }
        }
    }
}