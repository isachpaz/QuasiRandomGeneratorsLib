using System;
using System.Collections.Generic;
using System.Linq;

namespace QuasiRandomGeneratorsLib
{
    public class HaltonSequence1D : HaltonSequence
    {
        public HaltonSequence1D() : base(dimension: 1)
        {
        }

        public IEnumerable<double> GetDoubles()
        {
            return base.GetSequence().Select(x => x[0]);
        }
    }
}