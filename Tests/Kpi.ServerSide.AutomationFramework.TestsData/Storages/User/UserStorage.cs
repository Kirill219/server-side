using System;
using System.Collections.Generic;
using Bogus;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;
using Kpi.ServerSide.AutomationFramework.TestsData.Generators;

namespace Kpi.ServerSide.AutomationFramework.TestsData.Storages.User
{
    public static class UserStorage
    {
        public static Dictionary<string, UserRequest> UserRequests =>
            new Dictionary<string, UserRequest>
            {
                { "RandomUser", RandomUser }
            };

        public static Dictionary<string, UserUpdateRequest> UserUpdateRequests =>
            new Dictionary<string, UserUpdateRequest>
            {
                { "RandomUserName", RandomUserName }
            };

        private static UserUpdateRequest RandomUserName =>
            new Faker<UserUpdateRequest>()
                .RuleFor(u => u.Name, RandomGenerator.RandomString());

        private static UserRequest RandomUser =>
            new Faker<UserRequest>()
                .RuleFor(u => u.Email, RandomGenerator.NewEmail.ToLower())
                .RuleFor(u => u.Password, RandomGenerator.RandomString())
                .RuleFor(u => u.Name, RandomGenerator.RandomString())
                .RuleFor(u => u.Age, Convert.ToInt32(RandomGenerator.GetRandomPositiveNumber()));
    }
}
