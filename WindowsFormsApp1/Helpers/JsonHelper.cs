using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace RunBatForm.Helpers
{
    public static class JsonHelper
    {
        public static string Serializer(object model)
        {
            var options = new JsonSerializerOptions
            {
                IgnoreReadOnlyProperties = true,
                WriteIndented = true
            };
            var jsonString = JsonSerializer.Serialize(model, options);
            return jsonString;
        }

        public static T Deserialize<T>(string jsonString)
        {
            var options = new JsonSerializerOptions
            {
                Converters =
                {
                    new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                }
            };
            return JsonSerializer.Deserialize<T>(jsonString, options)!;
        }
    }
}
