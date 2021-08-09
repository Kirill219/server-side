namespace Kpi.ServerSide.AutomationFramework.User
{
    internal static class Token
    {
        internal static string BearerTokenGenerator(string accessToken)
        {
            return $"Bearer {accessToken}";
        }
    }
}
