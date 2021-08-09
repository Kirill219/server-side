using System.Threading.Tasks;
using FluentAssertions;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;
using Kpi.ServerSide.AutomationFramework.TestsData.Storages.User;
using TechTalk.SpecFlow;

namespace Kpi.ServerSide.AutomationFramework.Tests.Features
{
    [Binding, Scope(Feature = "User Registration")]
    public class PostUserDefinition
    {
        private readonly IUserContext _userContext;
        private UserRequest _newUser;
        private UserResponse _createdUser;

        public PostUserDefinition(
            IUserContext userContext)
        {
            _userContext = userContext;
        }

        [Given(@"I have user credentials")]
        public void GivenIHaveUserCredentials()
        {
            _newUser = UserStorage.UserRequests["RandomUser"];
        }

        [When(@"I send register request with provided model")]
        public async Task WhenISendRegisterRequestWithProvidedModel()
        {
            _createdUser = await _userContext.CreateUserAsync(
                _newUser);
        }

        [Then(@"I see generated authorization token")]
        public void ThenISeeGeneratedAuthorizationToken()
        {
            _createdUser.Token.Should()
                .NotBeNullOrEmpty();
        }
    }
}
