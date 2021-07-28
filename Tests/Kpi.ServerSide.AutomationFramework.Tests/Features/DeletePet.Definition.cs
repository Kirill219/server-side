using System.Threading.Tasks;
using FluentAssertions;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Pet;
using Kpi.ServerSide.AutomationFramework.TestsData.Storages.Pet;
using TechTalk.SpecFlow;

namespace Kpi.ServerSide.AutomationFramework.Tests.Features
{
    [Binding, Scope(Feature = "Delete Pet")]
    public class DeleteDefinition
    {
        private readonly IPetContext _petContext;
        private PetResponse _createdPet;
        private PetResponse _petResponse;
        private PetResponse _petDeleteResponse;

        public DeleteDefinition(
            IPetContext petContext)
        {
            _petContext = petContext;
        }

        [Given(@"I create Pet")]
        public async Task GivenICreatePet()
        {
            _createdPet = await _petContext.PostPetAsync(PetRequestStorage.PetRequest["PetRequest"]);
        }

        [When(@"I send delete request")]
        public async Task GivenISendDeleteRequest()
        {
            await _petContext.DeletePetByIdAsync(_createdPet.Id);
        }

        [When(@"I send delete request to (.*) wrong Id")]
        public async Task GivenISendDeleteRequestToWrongId(int id)
        {
            _petDeleteResponse = await _petContext.DeletePetByIdAsync(id);
        }

        [Then(@"I see (.*) id in pet response")]
        public async Task GivenISeeIdInPetResponse(int id)
        {
            _petResponse = await _petContext.GetPetByIdAsync(_createdPet.Id);
            _petResponse.Id.Should().Be(id);
        }

        [Then(@"I see null in response")]
        public void GivenISeeNullInResponse()
        {
            _petDeleteResponse.Should().Be(null);
        }
    }
}
