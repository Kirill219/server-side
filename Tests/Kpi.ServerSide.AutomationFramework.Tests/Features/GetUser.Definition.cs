using System.Threading.Tasks;
using FluentAssertions;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;
using Kpi.ServerSide.AutomationFramework.TestsData.Storages.User;
using TechTalk.SpecFlow;

namespace Kpi.ServerSide.AutomationFramework.Tests.Features
{
    [Binding, Scope(Feature = "Get User by Token")]
    public class GetUserDefinition
    {
        private readonly UserRequest _newUser;
        private readonly IUserContext _userContext;
        private UserProfileResponse _createdUser;
        private string _userToken;

        public GetUserDefinition(
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

        [When(@"I get User by providing token")]
        public async Task WhenIGetUserByProvidingToken()
        {
            _createdUser = await _userContext.GetUserByTokenAsync(
                _userToken);
        }

        [Then(@"I see returned Assignment details which are equal with created")]
        public void ThenISeeReturnedAssignmentDetailsWhichAreEqualWithCreated()
        {
            _createdUser.Email.Should().Be(
                _newUser.Email);
        }
    }
}
