using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class IntTest
    {
        private const int zero = 0;
        private const int positive = 1;
        private const int negative = -1;

        [TestMethod]
        public void TestIntZeroIsZero()
        {
            Assert.AreEqual(true, zero.Zero());
        }

        [TestMethod]
        public void TestIntZeroNotNonZero()
        {
            Assert.AreEqual(false, zero.NonZero());
        }

        [TestMethod]
        public void TestIntZeroNotNegative()
        {
            Assert.AreEqual(false, zero.Negative());
        }

        [TestMethod]
        public void TestIntZeroNotPositive()
        {
            Assert.AreEqual(false, zero.Positive());
        }

        [TestMethod]
        public void TestIntZeroIsFalse()
        {
            Assert.AreEqual(true, zero.False());
        }

        [TestMethod]
        public void TestIntPositiveIsNotZero()
        {
            Assert.AreEqual(false, positive.Zero());
        }

        [TestMethod]
        public void TestIntPositiveNonZero()
        {
            Assert.AreEqual(true, positive.NonZero());
        }

        [TestMethod]
        public void TestIntPositiveIsPositive()
        {
            Assert.AreEqual(true, positive.Positive());
        }

        [TestMethod]
        public void TestIntPositiveIsNotNegative()
        {
            Assert.AreEqual(false, positive.Negative());
        }

        [TestMethod]
        public void TestIntZeroIsTrue()
        {
            Assert.AreEqual(true, positive.True());
        }

        [TestMethod]
        public void TestIntNegativeIsNotZero()
        {
            Assert.AreEqual(false, negative.Zero());
        }

        [TestMethod]
        public void TestIntNegativeNonZero()
        {
            Assert.AreEqual(true, negative.NonZero());
        }

        [TestMethod]
        public void TestIntNegativeIsNotPositive()
        {
            Assert.AreEqual(false, negative.Positive());
        }

        [TestMethod]
        public void TestIntNegativeIsNotNegative()
        {
            Assert.AreEqual(true, negative.Negative());
        }

        [TestMethod]
        public void TestIntNegativeIsNotFalse()
        {
            Assert.AreEqual(false, negative.False());
        }

        [TestMethod]
        public void TestIntNegativeIsNotTrue()
        {
            Assert.AreEqual(false, negative.True());
        }

        [TestMethod]
        public void TestIntEvenIsEven()
        {
            Assert.AreEqual(true, 10.Even());
        }

        [TestMethod]
        public void TestIntEvenIsNotOdd()
        {
            Assert.AreEqual(false, 10.Odd());
        }

        [TestMethod]
        public void TestIntOddIsNotEven()
        {
            Assert.AreEqual(false, 7.Even());
        }

        [TestMethod]
        public void TestIntOddIsOdd()
        {
            Assert.AreEqual(true, 7.Odd());
        }

        [TestMethod]
        public void TestIntDivisibleBy()
        {
            Assert.AreEqual(true, 21.DivisibleBy(7));
        }

        [TestMethod]
        public void TestIntNotDivisibleBy()
        {
            Assert.AreEqual(false, 20.DivisibleBy(13));
        }

        // ==================
        // Flags Checking 
        // ==================

        private const int flags = 31;
        private const int flag2 = 4;
        private const int flag3 = 8;
        private const int flag4 = 16;
        private const int flag5 = 32;

        [TestMethod]
        public void TestIntFlagIsSet()
        {
            Assert.AreEqual(true, flags.FlagSet(flag2));
        }

        [TestMethod]
        public void TestIntFlagIsNotSet()
        {
            Assert.AreEqual(false, flags.FlagSet(flag5));
        }

        [TestMethod]
        public void TestIntFlagSetFlag()
        {
            Assert.AreEqual(63, flags.SetFlag(flag5));
        }

        [TestMethod]
        public void TestIntFlagRemoveFlag()
        {
            Assert.AreEqual(23, flags.RemoveFlag(flag3));
        }

        [TestMethod]
        public void TestIntFlagRemoveMultipleFlags()
        {
            Assert.AreEqual(7, flags.RemoveFlag(flag3 | flag4));
        }

        // ==================
        // Flags Checking 
        // ==================
        [TestMethod]
        public void TestIntFormatPositive()
        {
            Assert.AreEqual("000001", positive.FormatNumber(6));
        }

        [TestMethod]
        public void TestIntFormatZero()
        {
            Assert.AreEqual("000000", zero.FormatNumber(6));
        }

        [TestMethod]
        public void TestIntFormatNegative()
        {
            Assert.AreEqual("-00001", negative.FormatNumber(6));
        }
    }
}
