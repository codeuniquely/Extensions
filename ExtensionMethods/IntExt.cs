namespace System
{
    /// <summary>
    /// Extension wrapper class for <see cref="System.Int32"/> to provide methods to allow the return of flags or status that can apply to int values.
    /// </summary>
    public static class IntExt
    {
        /// <summary>
        /// Convenience method to check if a int has a value representative of a selection of 'No'
        /// </summary>
        /// <param name="i">The integer to be checked</param>
        /// <returns><c>true</c> if the value is 0 (zero)</returns>
        public static bool ToBool(this int i)
        {
            return i == 1 ? true : false;
        }

        /// <summary>
        /// Convenience method to check if a int has a value representative of a selection of 'No'
        /// </summary>
        /// <param name="i">The integer to be checked</param>
        /// <returns><c>true</c> if the value is 0 (zero)</returns>
        public static bool False(this int i)
        {
            return i == 0;
        }

        /// <summary>
        /// Convenience method to check if a int has a value representative of a selection of 'Yes'
        /// </summary>
        /// <param name="i">The integer to be checked</param>
        /// <returns><c>true</c> if the value is 1 (one)</returns>
        public static bool True(this int i)
        {
            return i == 1;
        }

        /// <summary>
        /// Convenience method to check if a int has a value representative of a selection that is not 'No'
        /// </summary>
        /// <param name="i">The integer to be checked</param>
        /// <returns><c>true</c> if the value is not 0 (!=0)</returns>
        public static bool NonZero(this int i)
        {
            return i != 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="i">The integer to be checked</param>
        /// <returns></returns>
        public static bool Zero(this int i)
        {
            return i == 0;
        }

        /// <summary>
        /// Is the value less than Zero
        /// </summary>
        /// <param name="i">The integer to be checked</param>
        /// <returns></returns>
        public static bool Negative(this int i)
        {
            return i < 0;
        }

        /// <summary>
        /// Is the value greater than Zero
        /// </summary>
        /// <param name="i">The integer to be checked</param>
        /// <returns></returns>
        public static bool Positive(this int i)
        {
            return i > 0;
        }

        /// <summary>
        /// Is the value an even number
        /// </summary>
        /// <param name="i">The integer to be checked</param>
        /// <returns></returns>
        public static bool Even(this int i)
        {
            return i % 2 == 0;
        }

        /// <summary>
        /// Is the value an odd number
        /// </summary>
        /// <param name="i">The integer to be checked</param>
        /// <returns></returns>
        public static bool Odd(this int i)
        {
            return i % 2 != 0;
        }

        /// <summary>
        /// Can the value a multiple of the divisor
        /// </summary>
        /// <param name="i">The integer to be checked</param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        public static bool DivisibleBy(this int i, int divisor)
        {
            return i % divisor == 0;
        }

        /// <summary>
        /// Check if the bit indicated in 'set' in the integer
        /// </summary>
        /// <param name="i">The integer to be checked</param>
        /// <param name="flag">bit flag to check for the existance of</param>
        /// <returns><c>true</c> if the bit is switched on in the passed int value, otherwise false</returns>
        public static bool FlagSet(this int i, int flag)
        {
            return (i & flag) != 0;
        }

        /// <summary>
        /// Sets  the required bit in the integer passed in.
        /// </summary>
        /// <param name="i">The integer to be altered</param>
        /// <param name="flag">bit flag to set</param>
        /// <returns>The new value with the appropiate bit value set altered</returns>
        public static int SetFlag(this int i, int flag)
        {
            return i | flag;
        }

        /// <summary>
        /// clears the required bit in the integer passed in.
        /// </summary>
        /// <param name="i">The integer to be altered</param>
        /// <param name="flag">bit flag to set</param>
        /// <returns>The new value with the appropiate bit value set altered</returns>
        public static int RemoveFlag(this int i, int flag)
        {
            return (i & flag) != 0 ? i - flag : i;
        }

        public static string FormatNumber(this int i, int length)
        {
            // Check Length > 0 and < 10
            int tmp = Math.Abs(i);
            return (i < 0) ? string.Format("-{0}", tmp.ToString().PadLeft(length - 1, '0')) : string.Format("{0}", tmp.ToString().PadLeft(length, '0'));
        }
    }
}