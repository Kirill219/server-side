using Bogus;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;

namespace Kpi.ServerSide.AutomationFramework.TestsData.Storages.User
{
    public static class UserTagsStorage
    {
        public static Tag Default =>
            new Faker<Tag>()
                .RuleFor(u => u.Name, "string")
                .RuleFor(u => u.Id, "1");
    }
}
