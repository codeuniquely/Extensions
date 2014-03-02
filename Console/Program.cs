namespace ExtensionsConsole
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Collections.Specialized;
    using System.Linq;

    class Program
    {
        private static int lineNumber;

        static void Main(string[] args)
        {
            StringExtension();
            IEnumerableExtension();

            Console.ReadKey();
        }
        
        private static void StringExtension()
        {
            lineNumber = 0;
            Console.WriteLine("\nString Extensions");

            //Write("10".ToInt());
            //Write("Hello World".ToInt());
            //Write("TRUE".ToBool());
            //Write("true".ToBool());
            //Write("True".ToBool());
            //Write("1".ToBool());
            //Write("FALSE".ToBool());
            //Write("false".ToBool());
            //Write("False".ToBool());
            //Write("0".ToBool());
            //Write("Hello World".IsEmpty());
            //Write("Hello World".IsNotEmpty());
            //Write("Hello World".Compare("Hello World"));
            //Write("Hello".Extend("World"));
            //Write("Hello World".LimitTo(6));
            //Write("Hello World".Left(5));
            //Write("World".Prefix("Hello "));
            //Write("Hello World".TrimLeft(5));
            //Write("Hekki World".ReplaceAtStart("kki", "llo"));
            //Write("Gwkki World".ReplaceStartWith("Hello"));
            //Write("Hello World".Right(5));
            //Write("Hello".Suffix(" World"));
            //Write("Hello World".TrimRight(5));
            //Write("Hello Woeks".ReplaceAtEnd("eks", "rld"));
            //Write("Hello Qieks".ReplaceEndWith("World"));
            //Write("Hello[hidden]World".Between("[", "]"));
            //Write("Hello World".Splice(5, 6, "[between]"));
            //Write("Hello World".Before(" "));
            //Write("Hello World".After(" "));
            //Write("Hello World".TrimBefore("World"));
            //Write("Hello World".TrimAfter("Hello"));
            //Write("  He  l  lo    Wo  rl d".CompressSpaces());
            //Write("  He  l  lo    Wo  rl d".RemoveWhitespace());
            //Write("Hello  World".Count("o").ToString());
            Write("Hello World".ToJson());
            Write("Hello World".PadLiterals());
            Write("Hello World".ToUTF8Bytes());
        }

        private static void IEnumerableExtension()
        {
            lineNumber = 0;
            Console.WriteLine("\nString Extensions");

            var strings = new string[] { "one", "two", "two", "three", "four", "five", "six", "six", "seven", "eight", "nine", "ten" };

            Write(strings.Find(x => x == "zero"));
            Write(strings.Find(x => x == "two"));
            Write(Concat(strings.Intersperse(",")));

            WriteMany(strings.DistinctBy(x => x));
            WriteMany(strings.WhereSelect(x => x.EndsWith("e")));
            WriteMany(strings.WhereSelect(x => x.StartsWith("f"), x => x.ToString()));
            WriteMany(strings.Append("eleven"));
            WriteMany(strings.Exclude("two"));
        }

        private static string Concat(IEnumerable<string> collection)
        {
            string line = string.Empty;

            foreach (var item in collection)
            {
                line = line + item;
            }
            
            return line;
        }

        private static void WriteMany(IEnumerable<string> collection)
        {
            string line = string.Empty;

            foreach(var item in collection)
            {
                line = line.Extend(item);
            }

            Write(line);
        }

        private static void Write(object o)
        {
            Write(o.ToString());
        }

        private static void Write(string line)
        {
            lineNumber++;

            Console.Write( lineNumber.ToString("00") );
            Console.Write( ": [" );
            Console.Write( line );
            Console.WriteLine("]");
        }
    }
}

