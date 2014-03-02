using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class BoolTest
    {
        [TestMethod]
        public void TestToBoolTrueUpper()
        {
            Assert.AreEqual(true, "TRUE".ToBool());
        }

        [TestMethod]
        public void TestToBoolTrueLower()
        {
            Assert.AreEqual(true, "true".ToBool());
        }

        [TestMethod]
        public void TestToBoolTrueMixed()
        {
            Assert.AreEqual(true, "True".ToBool());
        }

        [TestMethod]
        public void TestToBoolTrueNonZero()
        {
            Assert.AreEqual(true, "1".ToBool());
        }

        [TestMethod]
        public void TestToBoolTrueIntOne()
        {
            Assert.AreEqual(true, 1.ToBool());
        }

        [TestMethod]
        public void TestToBoolFalseUpper()
        {
            Assert.AreEqual(false, "FALSE".ToBool());
        }

        [TestMethod]
        public void TestToBoolFalseLower()
        {
            Assert.AreEqual(false, "false".ToBool());
        }

        [TestMethod]
        public void TestToBoolFalseMixed()
        {
            Assert.AreEqual(false, "False".ToBool());
        }

        [TestMethod]
        public void TestToBoolFalseZero()
        {
            Assert.AreEqual(false, "0".ToBool());
        }
        public void TestToBoolFalseIntZero()
        {
            Assert.AreEqual(false, 0.ToBool());
        }
    }
}
