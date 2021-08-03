using Bogus;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;

namespace Kpi.ServerSide.AutomationFramework.TestsData.Storages.User
{
    public static class UserCategoriesStorage
    {
        public static Category DefaultCategory =>
            new Faker<Category>()
                .RuleFor(u => u.Id, 1);
    }
}
