namespace System
{
    using System.ComponentModel;

    /// <summary>
    /// Extension wrapper class for <see cref="System.Enum"/> to provide methods to various Convenience formats.
    /// </summary>
    public static class EnumExt
    {
        /// <summary>
        /// Converts an ENUM value into it's equivalent Int value.
        /// </summary>
        /// <param name="enumValue">The enum to be checked</param>
        /// <returns>The Int32 value represented by the Enum</returns>
        public static int ToInt(this Enum enumValue)
        {
            return Convert.ToInt32(enumValue);
        }

        /// <summary>
        /// Parse and Enum into a given System.Type through coersion of the value.
        /// </summary>
        /// <typeparam name="T">Type to be converted to</typeparam>
        /// <param name="enumstring">string presentation of the enum - obtained from ToString() on the value</param>
        /// <returns>A typeof(T) value parsed from the enum.</returns>
        public static T ParseEnum<T>(this string enumstring)
        {
            return (T)Enum.Parse(typeof(T), enumstring);
        }

        /// <summary>
        /// Special Component Model extension to provide a 'Description' attribute on enum
        /// </summary>
        /// <param name="enumValue">Enumeration value to be described</param>
        /// <returns>A <see cref="System.String"/> representing the text of the description</returns>
        public static string Description(this Enum enumValue)
        {
            var enumType = enumValue.GetType();
            var field = enumType.GetField(enumValue.ToString());
            var attributes = field.GetCustomAttributes(typeof(DescriptionAttribute), false);

            return attributes.Length == 0 ? enumValue.ToString() : ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}