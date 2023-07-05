using System;
using Newtonsoft.Json;

namespace Store
{
    public static class JsonFileUtils
    {
        private static readonly JsonSerializerSettings _options = new() { NullValueHandling = NullValueHandling.Ignore };

        public static void writeToJson(object obj, string fileName)
        {
            var jsonString = JsonConvert.SerializeObject(obj, Formatting.Indented, _options);
            
            File.WriteAllText(fileName, jsonString);
        }
    }
}