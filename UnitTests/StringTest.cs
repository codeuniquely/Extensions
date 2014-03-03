using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace UnitTests
{
    [TestClass]
    public class StringTest
    {
        private const string nullstring = null;

        [TestMethod]
        public void ToIntNumber()
        {
            Assert.AreEqual(10, "10".ToInt());
        }

        [TestMethod]
        public void ToIntNonNumber()
        {
            Assert.AreEqual(0, "Hello World".ToInt());
        }

        [TestMethod]
        public void IsEmptyNoContents()
        {
            Assert.AreEqual(true, "".IsEmpty());
        }

        [TestMethod]
        public void IsEmptyWithNull()
        {
            Assert.AreEqual(true, nullstring.IsEmpty());
        }

        [TestMethod]
        public void IsEmptyWithWhitespace()
        {
            Assert.AreEqual(true, "  ".IsEmpty());
        }

        [TestMethod]
        public void ContentsIsNotEmpty()
        {
            Assert.AreEqual(false, "Hello World".IsEmpty());
        }

        [TestMethod]
        public void IsNotEmpty()
        {
            Assert.AreEqual(true, "Hello World".IsNotEmpty());
        }

        [TestMethod]
        public void NoContentsIsNotNotEmpty()
        {
            Assert.AreEqual(false, "".IsNotEmpty());
        }

        [TestMethod]
        public void NullIsNotNotEmpty()
        {
            Assert.AreEqual(false, nullstring.IsNotEmpty());
        }

        [TestMethod]
        public void Compare()
        {
            Assert.AreEqual(true, "Hello World".Compare("Hello World"));
        }

        [TestMethod]
        public void CompareWithNull()
        {
            Assert.AreEqual(false, "Hello World".Compare(null));
        }

        [TestMethod]
        public void CompareNull()
        {
            string test = null;
            Assert.AreEqual(false, test.Compare("Hello World"));
        }

        [TestMethod]
        public void Extend()
        {
            Assert.AreEqual("Hello,World", "Hello".Extend("World"));
        }

        [TestMethod]
        public void Limit()
        {
            Assert.AreEqual("Hello", "Hello World".LimitTo(5));
        }

        [TestMethod]
        public void Left()
        {
            Assert.AreEqual("Hello", "Hello World".Left(5));
        }

        [TestMethod]
        public void Prefix()
        {
            Assert.AreEqual("Hello World", "World".Prefix("Hello "));
        }

        [TestMethod]
        public void TrimLeft()
        {
            Assert.AreEqual("World", "Hello World".TrimLeft(6));
        }

        [TestMethod]
        public void ReplaceAtStart()
        {
            Assert.AreEqual("Hello World", "Hekki World".ReplaceAtStart("Hekki", "Hello"));
        }

        [TestMethod]
        public void ReplaceAtStartNotStart()
        {
            Assert.AreEqual("Hekki World", "Hekki World".ReplaceAtStart("kki", "llo"));
        }

        [TestMethod]
        public void ReplaceStartWith()
        {
            Assert.AreEqual("Hello World", "Hekki World".ReplaceStartWith("Hello"));
        }

        [TestMethod]
        public void Right()
        {
            Assert.AreEqual("World", "Hello World".Right(5));
        }

        [TestMethod]
        public void Suffix()
        {
            Assert.AreEqual("Hello World", "Hello".Suffix(" World"));
        }

        [TestMethod]
        public void TrimRight()
        {
            Assert.AreEqual("Hello", "Hello World".TrimRight(6));
        }

        [TestMethod]
        public void ReplaceAtEnd()
        {
            Assert.AreEqual("Hello World", "Hello Woeks".ReplaceAtEnd("eks", "rld"));
        }

        [TestMethod]
        public void ReplaceEndWith()
        {
            Assert.AreEqual("Hello World", "Hello Woeks".ReplaceEndWith("World"));
        }

        [TestMethod]
        public void Between()
        {
            Assert.AreEqual("hidden", "Hello[hidden]World".Between("[", "]"));
        }
        [TestMethod]
        public void Splice()
        {
            Assert.AreEqual("Hello[hidden]World", "Hello World".Splice(5, 6, "[hidden]"));
        }
        [TestMethod]
        public void Before()
        {
            Assert.AreEqual("Hello", "Hello World".Before(" "));
        }

        [TestMethod]
        public void After()
        {
            Assert.AreEqual("World", "Hello World".After(" "));
        }

        [TestMethod]
        public void TrimBefore()
        {
            Assert.AreEqual("World", "Hello World".TrimBefore("World"));
        }

        [TestMethod]
        public void TrimAfter()
        {
            Assert.AreEqual("Hello", "Hello World".TrimAfter("Hello"));
        }

        [TestMethod]
        public void CompressSpaces()
        {
            Assert.AreEqual(" He l lo Wo rl d ", "  He  l  lo    Wo  rl d  ".CompressSpaces());
        }

        [TestMethod]
        public void CompressSpacesNull()
        {
            Assert.AreEqual("", nullstring.CompressSpaces());
        }

        [TestMethod]
        public void CompressSpacesTrimmed()
        {
            Assert.AreEqual("He l lo Wo rl d", "  He  l  lo    Wo  rl d  ".CompressSpacesTrimmed());
        }

        [TestMethod]
        public void RemoveWhitespace()
        {
            Assert.AreEqual("HelloWorld", "  He  l  lo    Wo  rl d  ".RemoveWhitespace());
        }

        [TestMethod]
        public void RemoveWhitespaceNull()
        {
            Assert.AreEqual("", nullstring.RemoveWhitespace());
        }

        [TestMethod]
        public void Count()
        {
            Assert.AreEqual(2, "Hello World".Count("o"));
        }

        [TestMethod]
        public void CountNotFound()
        {
            Assert.AreEqual(0, "Hello World".Count("z"));
        }

        [TestMethod]
        public void ToJson()
        {
            Assert.AreEqual("\"Hello World\"", "Hello World".ToJson());
        }
    }
}
