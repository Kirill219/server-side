using System.Collections.Generic;
using Bogus;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;

namespace Kpi.ServerSide.AutomationFramework.TestsData.Storages.User
{
    public static class UserResponsesStorage
    {
        public static Dictionary<string, UserResponse> UserResponses =>
            new Dictionary<string, UserResponse>
            {
                { "Default", Default }
            };

        private static UserResponse Default =>
        new Faker<UserResponse>()
            .RuleFor(u => u.Id, 1)
            .RuleFor(u => u.Category, UserCategoriesStorage.DefaultCategory)
            .RuleFor(u => u.Name, "doggie")
            .RuleFor(u => u.Status, "available")
            .RuleFor(u => u.PhotoUrls, value: new[] { "yahoo" })
            .RuleFor(u => u.Tags, new[] { UserTagsStorage.Default });
    }
}
