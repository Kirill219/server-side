﻿using System.Threading.Tasks;
using FluentAssertions;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Pet;
using Kpi.ServerSide.AutomationFramework.TestsData.Storages.Pet;
using TechTalk.SpecFlow;

namespace Kpi.ServerSide.AutomationFramework.Tests.Features
{
    [Binding, Scope(Feature = "Put Pet")]
    public class PutDefinition
    {
        private readonly IPetContext _petContext;
        private PetResponse _putPet;
        private PetResponse _petResponse;

        public PutDefinition(
            IPetContext petContext)
        {
            _petContext = petContext;
        }

        [Given(@"I have free API with swagger")]
        public void GivenIHaveFreeApiWithSwagger()
        {
        }

        [When(@"I send put request")]
        public async Task GivenISendPutRequest()
        {
            _putPet = await _petContext.PutPetAsync(PetRequestStorage.PetRequest["PetRequest"]);
        }

        [Then(@"I send get request")]

        public async Task GivenISendGetRequest()
        {
            _petResponse = await _petContext.GetPetByIdAsync(_putPet.Id);
        }

        [Then(@"I see Pet details")]

        public void GivenISeePetDetails()
        {
            _petResponse.Should().BeEquivalentTo(_putPet);
        }
    }
}
