using System.Threading.Tasks;
using FluentAssertions;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.Pet;
using Kpi.ServerSide.AutomationFramework.TestsData.Storages.Pet;
using TechTalk.SpecFlow;

namespace Kpi.ServerSide.AutomationFramework.Tests.Features
{
    [Binding, Scope(Feature = "Get Pet by Id")]
    public class GetPetDefinition
    {
        private readonly IPetContext _petContext;
        private PetResponse _petResponse;
        private ResponseMessage _responseMessage;
        private PetResponse _createdPetResponse;

        public GetPetDefinition(
            IPetContext petContext)
        {
            _petContext = petContext;
        }

        [Given(@"I have free API with swagger")]
        public void GivenIHaveFreeApiWithSwagger()
        {
        }

        [When(@"I receive pet by valid posted id")]
        public async Task GivenIReceiveGetPetByIdResponse()
        {
            _createdPetResponse = await _petContext.PostPetAsync(PetRequestStorage.PetRequest["PetRequest"]);
            _petResponse = await _petContext.GetPetByIdAsync(_createdPetResponse.Id);
        }

        [When(@"I receive get pet by id response with (.*) wrong id")]
        public async Task WhenIReceiveGetPetByIdResponseWithWrongId(string value)
        {
            _responseMessage = await _petContext.GetPetByIdResponseAsync(value);
        }

        [Then(@"I see (.*) response status code")]
        public void ThenISeeResponseStatusCode(string expectedStatusCode)
        {
            _responseMessage.StatusCode.Should().Be(expectedStatusCode);
        }

        [Then(@"I see (.*) response")]
        public void ThenISeeResponse(string expectedErrorResponse)
        {
            _responseMessage.Content.Should().Be(expectedErrorResponse);
        }

        [Then(@"I see returned pet details")]
        public void ThenISeeReturnedPetDetails()
        {
            _petResponse.Should().BeEquivalentTo(_createdPetResponse);
        }
    }
}
