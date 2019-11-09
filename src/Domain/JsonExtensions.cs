using Newtonsoft.Json;

namespace Domain
{
    public static class JsonExtensions
    {
        public static string ToJson(this object item, bool indent = false)
        {
            var settings = new JsonSerializerSettings
            {
                Formatting = indent ? Formatting.Indented : Formatting.None
            };

            return JsonConvert.SerializeObject(item, settings);
        }

        public static T FromJson<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
