using System;
using System.ComponentModel;

namespace UnitTests
{
    public enum TestEnum
    {
        One = 1,
        Two,
        Three,
        Four,
        Five,
        Six
    }

    public enum TestEnumDescriptions
    {
        [Description("First")]
        One = 1,

        [Description("Second")]
        Two = 2,
        
        [Description("Third")]
        Three = 3,

        [Description("Forth")]
        Four = 4,

        [Description("Fifth")]
        Five = 5,

        [Description("Sixth")]
        Six = 6
    }
}
