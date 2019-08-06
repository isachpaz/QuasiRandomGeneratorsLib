using System.Linq;
using NUnit.Framework;

namespace QuasiRandomGeneratorsLib.Tests
{
    [TestFixture]
    public class RandomSequenceTests
    {
        [Test]
        public void ctor_Test()
        {
            RandomSequence rSeq = new RandomSequence(1000);
            var values = rSeq.GetDoubles().Take(100);

            Assert.AreEqual(values.Count(), 100);
        }
    }
}