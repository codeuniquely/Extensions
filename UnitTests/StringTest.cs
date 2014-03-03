using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace UnitTests
{
    [TestClass]
    public class StringTest
    {
        private const string nullstring = null;
        private const string emptystring = "";
        private const string shortstring = "a";

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
        public void ExtendEmpty()
        {
            Assert.AreEqual("World", "".Extend("World"));
        }

        [TestMethod]
        public void Limit()
        {
            Assert.AreEqual("Hello", "Hello World".LimitTo(5));
        }

        [TestMethod]
        public void LimitEmptyOrShort()
        {
            Assert.AreEqual("", emptystring.LimitTo(5));
        }

        [TestMethod]
        public void LimitNull()
        {
            Assert.AreEqual("", nullstring.LimitTo(5));
        }

        [TestMethod]
        public void Left()
        {
            Assert.AreEqual("Hello", "Hello World".Left(5));
        }

        [TestMethod]
        public void LeftEmptyOrShort()
        {
            Assert.AreEqual("", emptystring.Left(5));
        }

        [TestMethod]
        public void LeftNull()
        {
            Assert.AreEqual("", nullstring.Left(5));
        }

        [TestMethod]
        public void Prefix()
        {
            Assert.AreEqual("Hello World", "World".Prefix("Hello "));
        }

        [TestMethod]
        public void PrefixEmpty()
        {
            Assert.AreEqual("Hello ", emptystring.Prefix("Hello "));
        }

        [TestMethod]
        public void PrefixNull()
        {
            Assert.AreEqual("Hello ", nullstring.Prefix("Hello "));
        }

        [TestMethod]
        public void TrimLeft()
        {
            Assert.AreEqual("World", "Hello World".TrimLeft(6));
        }

        [TestMethod]
        public void TrimLeftEmpty()
        {
            Assert.AreEqual("", emptystring.TrimLeft(6));
        }

        [TestMethod]
        public void TrimLeftEmptyShort()
        {
            Assert.AreEqual("", shortstring.TrimLeft(6));
        }

        [TestMethod]
        public void TrimLeftNull()
        {
            Assert.AreEqual("", nullstring.TrimLeft(6));
        }

        [TestMethod]
        public void ReplaceAtStart()
        {
            Assert.AreEqual("Hello World", "Hekki World".ReplaceAtStart("Hekki", "Hello"));
        }

        [TestMethod]
        public void ReplaceAtStartFindNull()
        {
            Assert.AreEqual("Hekki World", "Hekki World".ReplaceAtStart(nullstring, "Hello"));
        }

        [TestMethod]
        public void ReplaceAtStartWithNull()
        {
            Assert.AreEqual(" World", "Hekki World".ReplaceAtStart("Hekki", nullstring));
        }

        [TestMethod]
        public void ReplaceAtStartEmpty()
        {
            Assert.AreEqual(emptystring, emptystring.ReplaceAtStart("Hekki", "Hello"));
        }
        [TestMethod]
        public void ReplaceAtStartNull()
        {
            Assert.AreEqual(emptystring, nullstring.ReplaceAtStart("Hekki", "Hello"));
        }

        [TestMethod]
        public void ReplaceAtStartNotFound()
        {
            Assert.AreEqual("Hello World", "Hello World".ReplaceAtStart("Hekki", "Hello"));
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
        public void RightEmpty()
        {
            Assert.AreEqual(emptystring, emptystring.Right(5));
        }

        [TestMethod]
        public void RightShort()
        {
            Assert.AreEqual(shortstring, shortstring.Right(6));
        }

        [TestMethod]
        public void RightNull()
        {
            Assert.AreEqual(emptystring, nullstring.Right(6));
        }

        [TestMethod]
        public void Suffix()
        {
            Assert.AreEqual("Hello World", "Hello".Suffix(" World"));
        }

        [TestMethod]
        public void SuffixAddEmpty()
        {
            Assert.AreEqual("Hello World", "Hello World".Suffix(emptystring));
        }

        [TestMethod]
        public void SuffixAddNull()
        {
            Assert.AreEqual("Hello World", "Hello World".Suffix(nullstring));
        }

        [TestMethod]
        public void SuffixEmpty()
        {
            Assert.AreEqual("World", emptystring.Suffix("World"));
        }

        [TestMethod]
        public void SuffixNull()
        {
            Assert.AreEqual("World", nullstring.Suffix("World"));
        }

        [TestMethod]
        public void SuffixNullAddNull()
        {
            Assert.AreEqual(emptystring, nullstring.Suffix(nullstring));
        }

        [TestMethod]
        public void TrimRight()
        {
            Assert.AreEqual("Hello", "Hello World".TrimRight(6));
        }

        [TestMethod]
        public void TrimRightEmpty()
        {
            Assert.AreEqual(emptystring, emptystring.TrimRight(6));
        }

        [TestMethod]
        public void TrimRightShort()
        {
            Assert.AreEqual(emptystring, shortstring.TrimRight(6));
        }

        [TestMethod]
        public void TrimRightNull()
        {
            Assert.AreEqual(emptystring, nullstring.TrimRight(6));
        }

        [TestMethod]
        public void ReplaceAtEnd()
        {
            Assert.AreEqual("Hello World", "Hello Woeks".ReplaceAtEnd("eks", "rld"));
        }

        [TestMethod]
        public void ReplaceAtEndFindNull()
        {
            Assert.AreEqual("Hello Woeks", "Hello Woeks".ReplaceAtEnd(nullstring, "rld"));
        }

        [TestMethod]
        public void ReplaceAtEndWithNull()
        {
            Assert.AreEqual("Hello Wo", "Hello Woeks".ReplaceAtEnd("eks", nullstring));
        }

        [TestMethod]
        public void ReplaceAtEndNull()
        {
            Assert.AreEqual(emptystring, nullstring.ReplaceAtEnd("eks", "rld"));
        }

        [TestMethod]
        public void ReplaceAtEndEmpty()
        {
            Assert.AreEqual(emptystring, emptystring.ReplaceAtEnd("eks", "rld"));
        }

        [TestMethod]
        public void ReplaceAtEndNotFound()
        {
            Assert.AreEqual("Hello World", "Hello World".ReplaceAtEnd("eks", "rld"));
        }

        [TestMethod]
        public void ReplaceAtEndNotEnd()
        {
            Assert.AreEqual("Hello World", "Hello World".ReplaceAtEnd("Wor", "Wal"));
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
        public void BetweenNotPresent()
        {
            Assert.AreEqual("Hello[hidden]World", "Hello[hidden]World".Between("<", ">"));
        }

        [TestMethod]
        public void Splice()
        {
            Assert.AreEqual("Hello[hidden]World", "Hello World".Splice(5, 6, "[hidden]"));
        }

        [TestMethod]
        public void SpliceZeroZero()
        {
            // Should splice as nothing in orginal string is being replaced
            Assert.AreEqual("Hello World", "Hello World".Splice(0, 0, "[hidden]"));
        }

        [TestMethod]
        public void SpliceWrongOrder()
        {
            Assert.AreEqual("Hello World", "Hello World".Splice(6, 1, "[hidden]"));
        }

        [TestMethod]
        public void SpliceSubZero()
        {
            Assert.AreEqual("Hello World", "Hello World".Splice(-1, -1, "[hidden]"));
        }

        [TestMethod]
        public void SpliceEmpty()
        {
            Assert.AreEqual("HelloWorld", "Hello World".Splice(5, 6, emptystring));
        }


        //if (pos1 > -1 && pos1 <= len && pos2 >= -1 && pos2 <= len && (pos2 > pos1))

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
        public void TrimBeforeEmpty()
        {
            Assert.AreEqual(emptystring, emptystring.TrimBefore("World"));
        }

        [TestMethod]
        public void TrimBeforeNull()
        {
            Assert.AreEqual(emptystring, nullstring.TrimBefore("World"));
        }

        [TestMethod]
        public void TrimBeforeMissing()
        {
            Assert.AreEqual(shortstring, shortstring.TrimBefore("World"));
        }

        [TestMethod]
        public void TrimAfter()
        {
            Assert.AreEqual("Hello", "Hello World".TrimAfter("Hello"));
        }

        [TestMethod]
        public void TrimAfterEmpty()
        {
            Assert.AreEqual(emptystring, emptystring.TrimAfter("Hello"));
        }

        [TestMethod]
        public void TrimAfterNull()
        {
            Assert.AreEqual(emptystring,  nullstring.TrimAfter("Hello"));
        }

        [TestMethod]
        public void TrimAfterMissing()
        {
            Assert.AreEqual(shortstring, shortstring.TrimAfter("Hello"));
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
        public void CompressSpacesTrimmedNull()
        {
            Assert.AreEqual("", nullstring.CompressSpacesTrimmed());
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
        public void CountAll()
        {
            Assert.AreEqual(10, "aaaaaaaaaa".Count("a"));
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

        [TestMethod]
        public void Bytes()
        {
            bool same = true;
            Byte[] array = new Byte[] { 0x48, 0x65, 0x6C, 0x6C, 0x6F, 0x20, 0x57, 0x6F, 0x72, 0x6C, 0x64 };

            var converted = "Hello World".ToUTF8Bytes();
            for(var i=0 ; i < converted.Length ; i++) {

                if (array[i] != converted[i])
                {
                    same = false;
                    break;
                }
            }

            Assert.IsTrue(same);
        }
    }
}
