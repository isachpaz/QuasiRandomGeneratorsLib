using System;
using System.Linq;
using System.Security.Cryptography;
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
            var values = rSeq.GetDoubles().Take(100).ToList();

            Assert.AreEqual(values.Count(), 100);
        }

        [TestCase(10)]
        [TestCase(100000)]
        [TestCase(12342345)]
        [TestCase(Int16.MaxValue)]
        public void Random_with_Seed_Test(int seedMax)
        {
            Func<int> randomSeed = 
                () => Helpers.SeedHelper.GetRandomSeed(
                    new RNGCryptoServiceProvider(), seedMax);

            RandomSequence  seq = new RandomSequence(seed: randomSeed);
            var values = seq.GetDoubles().Take(100).ToList();
            Assert.AreEqual(values.Count(), 100);
            Assert.LessOrEqual(seq.Seed, seedMax);
        }

        [TestCase(-100)]
        [TestCase(0)]
        public void Random_with_Seed_Exception_Test(int seedMax)
        {
            Assert.Throws(typeof(ArgumentException), () =>
            {
                Func<int> randomSeed =
                    () => Helpers.SeedHelper.GetRandomSeed(
                        new RNGCryptoServiceProvider(),
                        seedMax);

                RandomSequence seq = new RandomSequence(seed: randomSeed);
                //var values = seq.GetDoubles().Take(100).ToList();
            });
        }
    }
}