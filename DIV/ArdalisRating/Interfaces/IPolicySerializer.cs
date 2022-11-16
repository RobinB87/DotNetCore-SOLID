namespace ArdalisRating.Interfaces
{
    public interface IPolicySerializer
    {
        Policy GetPolicyFromString(string policyString);
    }
}