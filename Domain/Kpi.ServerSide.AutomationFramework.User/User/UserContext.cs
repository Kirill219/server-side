using System.Threading.Tasks;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;

namespace Kpi.ServerSide.AutomationFramework.User.User
{
    public class UserContext : IUserContext
    {
        private readonly IUserApiClient _userApiClient;

        public UserContext(
            IUserApiClient userApiClient)
        {
            _userApiClient = userApiClient;
        }

        public async Task<UserResponse> CreateUserAsync(
            UserRequest userRequest)
        {
            return await _userApiClient.CreateUserAsync(
                userRequest);
        }

        public async Task<UserProfileResponse> GetUserByTokenAsync(
            string accessToken)
        {
            return await _userApiClient.GetUserByTokenAsync(
                Token.BearerTokenGenerator(accessToken));
        }

        public async Task<ResponseMessage> UpdateUserResponseAsync(
            UserUpdateRequest userUpdateRequest, 
            string accessToken)
        {
            return await _userApiClient.UpdateUserResponseAsync(
                userUpdateRequest, 
                Token.BearerTokenGenerator(accessToken));
        }

        public async Task<ResponseMessage> DeleteUserResponseAsync(
            string accessToken)
        {
            return await _userApiClient.DeleteUserResponseAsync(
                Token.BearerTokenGenerator(accessToken));
        }
    }
}
