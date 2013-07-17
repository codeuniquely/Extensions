namespace System
{
    using Newtonsoft.Json;

    public static class ObjectExt
    {
        /// <summary>
        /// Provide a ToJson() method on all objects that serializes objects to their JSON equivalent using JSON.Net 
        /// </summary>
        /// <param name="o">object to be serialized</param>
        /// <returns>A Serialized string</returns>
        public static string ToJson(this object o)
        {
            return JsonConvert.SerializeObject(o, Formatting.None);
        }
    }
}
