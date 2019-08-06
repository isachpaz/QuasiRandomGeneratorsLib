using System;
using System.Collections.Generic;

namespace QuasiRandomGeneratorsLib
{
    public class RandomSequence
    {
        public int Seed { get; }
        private Lazy<Random> _rnd;
        public RandomSequence(int seed)
        {
            Seed = seed;
            _rnd = new Lazy<Random>(() => new Random(seed));
        }

        public IEnumerable<double> GetDoubles()
        {
            while (true)
            {
                yield return _rnd.Value.NextDouble();
            }
        }
    }
}