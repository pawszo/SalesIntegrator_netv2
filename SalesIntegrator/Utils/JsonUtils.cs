using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;

namespace SalesIntegrator.Utils
{
    public static class JsonUtils
    {

        public static readonly JsonSerializerOptions JSON_OPTIONS = GetJsonOpts();

        private static JsonSerializerOptions GetJsonOpts()
        {
            var jsonOpts = new JsonSerializerOptions();
            jsonOpts.IgnoreNullValues = true;
            jsonOpts.PropertyNameCaseInsensitive = true;
            //jsonOpts.Encoder.EncodeUtf8()
            return jsonOpts;
        }

        public static List<string> GetPropertyKeysForDynamic(dynamic dynamicToGetPropertiesFor)
        {
            JObject attributesAsJObject = dynamicToGetPropertiesFor;
            Dictionary<string, object> values = attributesAsJObject.ToObject<Dictionary<string, object>>();
            List<string> toReturn = new List<string>();
            foreach (string key in values.Keys)
            {
                toReturn.Add(key);
            }
            return toReturn;
        }

        public static dynamic DeserializeToDynamic(string jsonString)
        {
            var converter = new ExpandoObjectConverter();
            dynamic message = JsonConvert.DeserializeObject<ExpandoObject>(jsonString, converter);
            return message;
        }

        public static string SerializeObject<T>(T model)
        {

            return JsonConvert.SerializeObject(model);
        }
    }



}
