namespace System
{
    /// <summary>
    /// Extension wrapper class for <see cref="System.Boolean"/> to provide methods to allow the return of various strings
    /// </summary>
    public static class BoolExt
    {
        /// <summary>
        /// Converts a bool to a numerical string of "1" or "0" rather than to "true" or "false"
        /// </summary>
        /// <param name="value">The bool to be checked</param>
        /// <returns>A <see cref="System.String"/> string of "1" if the value is true, otherwise "0"</returns>
        public static string AsString(this bool value)
        {
            return value ? "1" : "0";
        }
    }
}
