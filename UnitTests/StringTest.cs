using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests
{
    [TestClass]
    public class StringTest
    {
        [TestMethod]
        public void TestToIntNumber()
        {
            Assert.AreEqual(10, "10".ToInt());
        }

        [TestMethod]
        public void TestToIntNonNumber()
        {
            Assert.AreEqual(0, "Hello World".ToInt());
        }
    }
}
