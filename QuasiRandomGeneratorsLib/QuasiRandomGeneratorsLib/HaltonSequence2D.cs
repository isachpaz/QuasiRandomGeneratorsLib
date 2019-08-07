using System;
using System.Collections.Generic;
using System.Linq;

namespace QuasiRandomGeneratorsLib
{
    public class HaltonSequence2D : HaltonSequence
    {
        public HaltonSequence2D() : base(dimension: 2)
        {
        }

        public IEnumerable<Tuple<double, double>> GetDoubles()
        {
            return base.GetSequence().Select(x => Tuple.Create(x[0], x[1]));
        }
    }
}