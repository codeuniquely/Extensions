namespace System
{
    public static class DoubleExt
    {
        public static string ToCurrency(this double d)
        {
            return d.ToString("F");
        }
    }
}