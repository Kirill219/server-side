using System.Collections.Generic;
using Bogus;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Pet;

namespace Kpi.ServerSide.AutomationFramework.TestsData.Storages.Pet
{
    public static class PetRequestStorage
    {
        public static Dictionary<string, PetRequest> PetRequest =>
            new Dictionary<string, PetRequest>
            {
                { "PetRequest", Default }
            };

        private static PetRequest Default =>
        new Faker<PetRequest>()
            .RuleFor(u => u.Id, 1)
            .RuleFor(u => u.Category, PetCategoriesStorage.DefaultCategory)
            .RuleFor(u => u.Name, "doggie")
            .RuleFor(u => u.Status, "available")
            .RuleFor(u => u.PhotoUrls, value: new[] { "yahoo" })
            .RuleFor(u => u.Tags, new[] { PetTagsStorage.Default });
    }
}
