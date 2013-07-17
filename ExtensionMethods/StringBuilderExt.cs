namespace System.Text
{
    /// <summary>
    /// Extension wrapper class for <see cref="System.Text.StringBuilder"/> to provides an alternate Format method for CSV creation
    /// </summary>
    public static class StringBuilderExt
    {
        /// <summary>
        /// Extends a StringBuilder with a value, adding comma if required
        /// </summary>
        /// <param name="head">The StringBuilder that will be extended</param>
        /// <param name="tail">The string extension to be applied</param>
        /// <returns>returns an extended StringBuilder</returns>
        public static StringBuilder Extend(this StringBuilder head, string tail)
        {
            return (head.Length > 0) ? head.AppendFormat(",{0}", tail) : head.Append(tail);
        }
    }
}
