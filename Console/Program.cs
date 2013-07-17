namespace ExtensionsConsole
{
    using System;
    //using ExtensionMethods;

    class Program
    {
        private static int lineNumber;

        static void Main(string[] args)
        {
            BoolExtension();
            IntExtension();
            StringExtension();

            Console.ReadKey();
        }
        
        private static void BoolExtension()
        {
            lineNumber = 0;
            Console.WriteLine("Bool Extensions");
            Write(true.AsString());
            Write(false.AsString());
            Write(true.ToJson());
        }

        private static void IntExtension()
        {
            lineNumber = 0;
            Console.WriteLine("\nInt Extensions");

            int value = 10;

            Write(value.NonZero());
            Write(value.Positive());
            Write(value.Zero());
            Write(value.Negative());
            Write(value.FlagSet(2));
            Write(value.SetFlag(1));
            Write(value.RemoveFlag(8));
            Write(value.FormatNumber(6));
            Write(value.ToJson());
        }

        private static void StringExtension()
        {
            lineNumber = 0;
            Console.WriteLine("\nString Extensions");

            Write("10".ToInt());
            Write("Hello World".ToInt());
            Write("TRUE".ToBool());
            Write("true".ToBool());
            Write("True".ToBool());
            Write("1".ToBool());
            Write("FALSE".ToBool());
            Write("false".ToBool());
            Write("False".ToBool());
            Write("0".ToBool());
            Write("Hello World".ToUTF8Bytes());
            Write("Hello World".IsEmpty());
            Write("Hello World".IsNotEmpty());
            Write("Hello World".Compare("Hello World"));
            Write("Hello".Extend("World"));
            Write("Hello World".LimitTo(6));
            Write("Hello World".Left(5));
            Write("World".Prefix("Hello "));
            Write("Hello World".TrimLeft(5));
            Write("Hekki World".ReplaceAtStart("kki", "llo"));
            Write("Gwkki World".ReplaceStartWith("Hello"));
            Write("Hello World".Right(5));
            Write("Hello".Suffix(" World"));
            Write("Hello World".TrimRight(5));
            Write("Hello Woeks".ReplaceAtEnd("eks", "rld"));
            Write("Hello Qieks".ReplaceEndWith("World"));
            Write("Hello[hidden]World".Between("[", "]"));
            Write("Hello World".Splice(5, 6, "[between]"));
            Write("Hello World".Before(" "));
            Write("Hello World".After(" "));
            Write("Hello World".TrimBefore("World"));
            Write("Hello World".TrimAfter("Hell"));
            Write("  He  l  lo    Wo  rl d".CompressSpaces());
            Write("  He  l  lo    Wo  rl d".RemoveWhitespace());
            Write("Hello  World".PadLiterals());
            Write("Hello  World".Count("o").ToString());
            Write("Hello  World".ToJson());
        }

        private static void Write(object o)
        {
            Write(o.ToString());
        }

        //private static void Write(int i)
        //{
        //    Write( i.ToString() );
        //}

        //private static void Write(bool b)
        //{
        //    Write(b.ToString());
        //}

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
