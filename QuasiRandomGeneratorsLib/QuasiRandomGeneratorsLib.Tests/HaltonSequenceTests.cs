using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq.Extensions;
using MyUtilsLib;
using NUnit.Framework;


namespace QuasiRandomGeneratorsLib.Tests
{
    [TestFixture]
    public class HaltonSequenceTests
    {
        List<double> _seqBase2 = new List<double>();
        List<double> _seqBase3 = new List<double>();

        [SetUp]
        public void Init()
        {
            //base 2:  0  1/2  1/4  3/4  1/8  5/8  3/8  7/8  1/16  9/16
            _seqBase2 = new List<double>()
                {0.0, 1.0 / 2.0, 1.0 / 4, 3.0 / 4, 1.0 / 8, 5.0 / 8, 3.0 / 8, 7.0 / 8, 1.0 / 16, 9.0 / 16};

            //Base 3: 0     1/3   2/3   1/9   4/9   7/9   2/9   5/9   8/9   1/27  10/27 
            _seqBase3 = new List<double>()
                {0.0, 1.0 / 3, 2.0 / 3, 1.0 / 9, 4.0 / 9, 7.0 / 9, 2.0 / 9, 5.0 / 9, 8.0 / 9, 1.0 / 27, 10.0 / 27};
        }

        [Test]
        public void Halton1D_First_Numbers_Test()
        {
            var haltonSeq = new HaltonSequence1D();
            foreach (var tuple in haltonSeq.GetSequence().Zip(_seqBase2, Tuple.Create))
            {
                Assert.AreEqual(tuple.Item1[0], tuple.Item2);
            }
        }

        [Test]
        public void Halton1D_GetDoubles_Test()
        {
            var haltonSeq = new HaltonSequence1D();

            foreach (var tuple in haltonSeq.GetDoubles().Zip(_seqBase2, Tuple.Create))
            {
                Assert.AreEqual(tuple.Item1, tuple.Item2);
            }
        }

        [Test]
        public void Halton2D_X_First_Numbers_Test()
        {
            var haltonSeq = new HaltonSequence2D();
            foreach (var tuple in haltonSeq.GetSequence().Zip(_seqBase2, Tuple.Create))
            {
                Assert.AreEqual(tuple.Item1[0], tuple.Item2);
            }
        }


        [Test]
        public void Halton2D_Y_First_Numbers_Test()
        {
            var haltonSeq = new HaltonSequence2D();
            foreach (var tuple in haltonSeq.GetSequence().Zip(_seqBase3, Tuple.Create))
            {
                Assert.AreEqual(tuple.Item1[1], tuple.Item2);
            }
        }


        [Test]
        public void HaltonGeneric_Impl_1D_Test()
        {
            var halton = new HaltonSequence(1);

            var seq = halton.GetSequence();

            
            foreach (var item in seq.Zip(_seqBase2, Tuple.Create))
            {
                Assert.AreEqual(item.Item1[0], item.Item2);
            }
           
        }

        [Test]
        public void HaltonGeneric_Impl_2D_Test()
        {
            var halton = new HaltonSequence(2);

            var seq = halton.GetSequence();

            
            foreach (var item in seq.Zip(_seqBase3, Tuple.Create))
            {
                Assert.AreEqual(item.Item1[1], item.Item2);
            }
           
        }

        [Test]
        public void Halton2D_GetDoubles_Test()
        {
            var halton = new HaltonSequence2D();

            
            foreach (var item in MyUtils.ZipThreeEnumerable(halton.GetDoubles(), _seqBase2, _seqBase3))
            {
                Assert.AreEqual(item.Item1.Item1, item.Item2);
                Assert.AreEqual(item.Item1.Item2, item.Item3);
            }
        }

    }
}