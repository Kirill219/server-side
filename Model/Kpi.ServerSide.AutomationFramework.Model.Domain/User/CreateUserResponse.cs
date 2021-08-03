namespace Kpi.ServerSide.AutomationFramework.Model.Domain.User
{
    public class CreateUserResponse
    {
        public long Id { get; set; }

        public string[] PhotoUrls { get; set; }

        public Tag[] Tags { get; set; }
    }
}
