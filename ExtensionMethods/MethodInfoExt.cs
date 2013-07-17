namespace System.Reflection
{
    using System.ComponentModel;

    public static class MethodInfoExt
    {
        /// <summary>
        /// Special Component Model extension to provide a 'Description' attribute on enum
        /// </summary>
        /// <param name="enumValue">Enumeration value to be described</param>
        /// <returns>A <see cref="System.String"/> representing the text of the description</returns>
        public static string Description(this MethodInfo info)
        {
            var attributes = info.GetCustomAttributes(typeof(DescriptionAttribute), false);
            return attributes.Length == 0 ? info.Name : ((DescriptionAttribute)attributes[0]).Description;
        }
    }
}
