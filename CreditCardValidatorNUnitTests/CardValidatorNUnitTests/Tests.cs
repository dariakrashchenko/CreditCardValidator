using NUnit.Framework;
using System;
using CreditCardValidatorLibrary;

namespace CardValidatorNUnitTests
{
    [TestFixture()]
    public class Test
    {
        LuhnMod10Algorithm lu;
        VerhoeffAlgorithm ver;
        [TestFixtureSetUp()]
        public void TestSetUp()
        {
            lu = new LuhnMod10Algorithm();
            ver = new VerhoeffAlgorithm();
        }

        [Test()]
        public void ShouldConvertStringToIntArray()
        {
            int[] ExpectedResult = new int[]{ 5, 1, 6, 7, 4, 9, 0, 0, 7, 8, 1, 8, 5, 0, 2, 3 };
            Assert.AreEqual(ExpectedResult,lu.StringToIntArray("5167490078185023"));
            Array.Reverse(ExpectedResult);
            Assert.AreEqual(ExpectedResult, ver.StringToIntArray("5167490078185023"));
		}

        [Test()]
        public void ShouldValidateNumber()
        {
            Assert.AreEqual(true,lu.ValidateNumber("5167490078185023"));
            Assert.AreEqual(false,ver.ValidateNumber("5167490078185029"));
        }

        [Test()]
		public void ShouldGenerateCheckDigit()
        {
            Assert.AreEqual(3,lu.GenerateCheckDigit("516749007818502"));
            Assert.AreEqual(1,ver.GenerateCheckDigit("516875593794042"));
        }

        [Test()]
		public void LuhnMod10AlgorithmIterationTest()
        {
            Assert.AreEqual(0,lu.LuhnMod10AlgorithmIteration(lu.StringToIntArray("5167490078185023")));
            Assert.AreEqual(0,lu.LuhnMod10AlgorithmIteration(lu.StringToIntArray("5168755937940423")));
        }
    }
}
