namespace System
{
    using System;

    public static class DecimalExt
    {
        public static bool InRange(this decimal d, decimal average, decimal percent)
        {
            var deviation = Math.Round(average * percent / 100.0M, 3);

            return (d < (average - deviation) || d > (average + deviation)) ? false : true;
        }
    }
}
