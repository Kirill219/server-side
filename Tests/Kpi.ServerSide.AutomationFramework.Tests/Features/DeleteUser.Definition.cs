using System.Threading.Tasks;
using FluentAssertions;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;
using Kpi.ServerSide.AutomationFramework.TestsData.Storages.User;
using TechTalk.SpecFlow;

namespace Kpi.ServerSide.AutomationFramework.Tests.Features
{
    [Binding, Scope(Feature = "Delete User by authorization token")]
    public class DeleteUserDefinition
    {
        private readonly UserRequest _newUser;
        private readonly IUserContext _userContext;
        private ResponseMessage _responseMessage;
        private string _userToken;

        public DeleteUserDefinition(
            IUserContext userContext)
        {
            _userContext = userContext;
            _newUser = UserStorage.UserRequests["RandomUser"];
        }

        [Given(@"I have registered user")]
        public async Task GivenIHaveRegisteredUser()
        {
            _userToken = (await _userContext.CreateUserAsync(_newUser))
                .Token;
        }

        [When(@"I send delete request with provided user authorization token")]
        public async Task WhenISendDeleteRequestWithProvidedUserAuthorizationToken()
        {
            _responseMessage = await _userContext.DeleteUserResponseAsync(_userToken);
        }

        [Then(@"I see (.*) status code")]
        public void ThenISeeOkStatusCode(string statusCode)
        {
            _responseMessage.StatusCode.Should().Be(
                statusCode);
        }
    }
}
