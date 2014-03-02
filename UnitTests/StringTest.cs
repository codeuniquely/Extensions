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

        [TestMethod]
        public void TestIsEmptyNoContents()
        {
            Assert.AreEqual(true, "".IsEmpty());
        }

        [TestMethod]
        public void TestIsEmptyWithNull()
        {
            string test = null;
            Assert.AreEqual(true, test.IsEmpty());
        }

        [TestMethod]
        public void TestIsEmptyWithWhitespace()
        {
            Assert.AreEqual(true, "  ".IsEmpty());
        }

        [TestMethod]
        public void TestContentsIsNotEmpty()
        {
            Assert.AreEqual(false, "Hello World".IsEmpty());
        }

        [TestMethod]
        public void TestIsNotEmpty()
        {
            Assert.AreEqual(true, "Hello World".IsNotEmpty());
        }

        [TestMethod]
        public void TestNoContentsIsNotNotEmpty()
        {
            Assert.AreEqual(false, "".IsNotEmpty());
        }

        [TestMethod]
        public void TestNullIsNotNotEmpty()
        {
            string test = null;
            Assert.AreEqual(false, test.IsNotEmpty());
        }

        [TestMethod]
        public void TestCompare()
        {
            Assert.AreEqual(true, "Hello World".Compare("Hello World"));
        }

        [TestMethod]
        public void TestCompareWithNull()
        {
            Assert.AreEqual(false, "Hello World".Compare(null));
        }

        [TestMethod]
        public void TestCompareNull()
        {
            string test = null;
            Assert.AreEqual(false, test.Compare("Hello World"));
        }

        [TestMethod]
        public void TestExtend()
        {
            Assert.AreEqual("Hello,World", "Hello".Extend("World"));
        }

        [TestMethod]
        public void TestLimit()
        {
            Assert.AreEqual("Hello", "Hello World".LimitTo(5));
        }

        [TestMethod]
        public void TestLeft()
        {
            Assert.AreEqual("Hello", "Hello World".Left(5));
        }

        [TestMethod]
        public void TestPrefix()
        {
            Assert.AreEqual("Hello World", "World".Prefix("Hello "));
        }

        [TestMethod]
        public void TestTrimLeft()
        {
            Assert.AreEqual("World", "Hello World".TrimLeft(6));
        }

        [TestMethod]
        public void TestReplaceAtStart()
        {
            Assert.AreEqual("Hello World", "Hekki World".ReplaceAtStart("Hekki", "Hello"));
        }

        [TestMethod]
        public void TestReplaceAtStartNotStart()
        {
            Assert.AreEqual("Hekki World", "Hekki World".ReplaceAtStart("kki", "llo"));
        }

        [TestMethod]
        public void TestReplaceStartWith()
        {
            Assert.AreEqual("Hello World", "Hekki World".ReplaceStartWith("Hello"));
        }

        [TestMethod]
        public void TestRight()
        {
            Assert.AreEqual("World", "Hello World".Right(5));
        }
    }
}
