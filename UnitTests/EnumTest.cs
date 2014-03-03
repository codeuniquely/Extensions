using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    // Declare an ENUM for testsing
    [TestClass]
    public class EnumTest
    {
        [TestMethod]
        public void EnumToInt()
        {
            Assert.AreEqual(6, TestEnum.Six.ToInt());
        }

        [TestMethod]
        public void EnumToString()
        {
            Assert.AreEqual("Six", TestEnum.Six.ToString());
        }
        
        [TestMethod]
        public void ParseEnum()
        {
            Assert.AreEqual(TestEnum.Six, "Six".ParseEnum<TestEnum>());
        }

        [TestMethod]
        public void NoDescription()
        {
            Assert.AreEqual("Six", TestEnum.Six.Description());
        }

        [TestMethod]
        public void Description()
        {
            Assert.AreEqual("Sixth", TestEnumDescriptions.Six.Description());
        }

        [TestMethod]
        public void ToJson()
        {
            Assert.AreEqual("6", TestEnumDescriptions.Six.ToJson());
        }
    }
}
