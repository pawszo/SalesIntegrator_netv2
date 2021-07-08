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



    }


}
