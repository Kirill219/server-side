using System;
using System.Threading.Tasks;
using FluentAssertions;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;
using Kpi.ServerSide.AutomationFramework.TestsData.Storages.User;
using TechTalk.SpecFlow;

namespace Kpi.ServerSide.AutomationFramework.Tests.Features
{
    [Binding, Scope(Feature = "Update User by authorization token")]
    public class PutUserDefinition
    {
        private readonly IUserContext _userContext;
        private readonly UserRequest _newUser;
        private readonly UserUpdateRequest _newUserData;
        private ResponseMessage _responseMessage;

        private string _userToken;

        public PutUserDefinition(
            IUserContext userContext)
        {
            _userContext = userContext;
            _newUser = UserStorage.UserRequests["RandomUser"];
            _newUserData = UserStorage.UserUpdateRequests["RandomUserName"];
        }

        [Given(@"I have registered user")]
        public async Task GivenIHaveRegisteredUser()
        {
            _userToken = (await _userContext.CreateUserAsync(_newUser))
                .Token;
        }

        [When(@"I send update request with new user name")]
        public async Task WhenISendUpdateRequestWithNewUserName()
        {
            _responseMessage = 
                await _userContext.UpdateUserResponseAsync(
                    _newUserData, 
                    _userToken);
        }

        [Then(@"I see updated user in get request")]
        public async Task ThenISeeUpdatedUserInGetRequest()
        {
            var updatedUser = await _userContext.GetUserByTokenAsync(
                _userToken);
            updatedUser.Name.Should().Be(_newUserData.Name);
        }

        [Given(@"I have invalid authorization token")]
        public void GivenIHaveInvalidAuthorizationToken()
        {
            _userToken = Guid.NewGuid().ToString();
        }

        [When(@"I send update request with invalid token")]
        public async Task WhenISendUpdateRequestWithInvalidToken()
        {
            _responseMessage =
                await _userContext.UpdateUserResponseAsync(
                    _newUserData,
                    _userToken);
        }

        [Then(@"I see (.*) status code")]
        public void ThenISeeUnauthorizedStatusCode(string statusCode)
        {
            _responseMessage.StatusCode.Should().Be(statusCode);
        }
    }
}
