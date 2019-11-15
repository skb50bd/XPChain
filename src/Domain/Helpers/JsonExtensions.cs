using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

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
            settings.Converters.Add(new ObjectIdConverter());

            return JsonConvert.SerializeObject(item, settings);
        }

        public static T FromJson<T>(this string json)
        {
            var settings =
                new JsonSerializerSettings();
            settings.Converters.Add(
                    new ObjectIdConverter());
            return JsonConvert.DeserializeObject<T>(json, settings);
        }

        public static string IndentJson(this string json) =>
            JToken.Parse(json).ToString(Formatting.Indented);

        public static string JsonToHtml(this string json)
        {
            return json.Replace("\n", "<br />")
                       .Replace(" ", "&nbsp;");
        }
    }
}
