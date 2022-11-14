using ArdalisRating.Serializers;
using Xunit;

namespace ArdalisRating.Tests.PolicySerializerTests
{
    public class PolicySerializerTests
    {
        [Fact]
        public void ReturnsDefaultPolicyFromEmptyJsonString()
        {
            var inputJson = "{}";
            var serializer = new JsonPolicySerializer();
            var result = serializer.GetPolicyFromJsonString(inputJson);
            var policy = new Policy();
            Assert.Equal(result.Address, policy.Address);
        }
    }
}