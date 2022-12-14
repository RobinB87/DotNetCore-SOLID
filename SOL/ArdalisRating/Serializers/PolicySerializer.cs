using Newtonsoft.Json.Converters;
using Newtonsoft.Json;

namespace ArdalisRating.Serializers
{
    public class JsonPolicySerializer
    {
        public Policy GetPolicyFromJsonString(string policyJson)
        {
            return JsonConvert.DeserializeObject<Policy>(policyJson,
                new StringEnumConverter());
        }
    }
}