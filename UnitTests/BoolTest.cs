using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class BoolTest
    {
        private const string nullstring = null;

        [TestMethod]
        public void ToBoolTrueUpper()
        {
            Assert.AreEqual(true, "TRUE".ToBool());
        }

        [TestMethod]
        public void ToBoolTrueLower()
        {
            Assert.AreEqual(true, "true".ToBool());
        }

        [TestMethod]
        public void ToBoolTrueMixed()
        {
            Assert.AreEqual(true, "True".ToBool());
        }

        [TestMethod]
        public void ToBoolTrueNonZero()
        {
            Assert.AreEqual(true, "1".ToBool());
        }

        [TestMethod]
        public void ToBoolTrueIntOne()
        {
            Assert.AreEqual(true, 1.ToBool());
        }

        [TestMethod]
        public void ToBoolFalseUpper()
        {
            Assert.AreEqual(false, "FALSE".ToBool());
        }

        [TestMethod]
        public void ToBoolFalseLower()
        {
            Assert.AreEqual(false, "false".ToBool());
        }

        [TestMethod]
        public void ToBoolFalseMixed()
        {
            Assert.AreEqual(false, "False".ToBool());
        }

        [TestMethod]
        public void ToBoolFalseZero()
        {
            Assert.AreEqual(false, "0".ToBool());
        }

        [TestMethod]
        public void ToBoolFalseIntZero()
        {
            Assert.AreEqual(false, 0.ToBool());
        }

        [TestMethod]
        public void FalseAsString()
        {
            Assert.AreEqual("0", false.AsString());
        }
        [TestMethod]
        public void TrueAsString()
        {
            Assert.AreEqual("1", true.AsString());
        }
        [TestMethod]
        public void FalseToString()
        {
            Assert.AreEqual("False", false.ToString());
        }
        [TestMethod]
        public void TrueTotring()
        {
            Assert.AreEqual("True", true.ToString());
        }

        [TestMethod]
        public void ToBoolNonNumber()
        {
            Assert.AreEqual(false, "Hello".ToBool());
        }

        [TestMethod]
        public void ToBoolNull()
        {
            Assert.AreEqual(false, nullstring.ToBool());
        }

        [TestMethod]
        public void ToBoolEmpty()
        {
            Assert.AreEqual(false, string.Empty.ToBool());
        }
    }
}
