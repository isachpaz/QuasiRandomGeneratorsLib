using System;
using System.Collections.Generic;
using System.Linq;

namespace QuasiRandomGeneratorsLib
{
    public class HaltonSequence3D : HaltonSequence
    {
        public HaltonSequence3D() : base(dimension: 3)
        {
        }

        public IEnumerable<Tuple<double, double, double>> GetDoubles()
        {
            return base.GetSequence().Select(x => Tuple.Create(x[0], x[1], x[2]));
        }
    }
}