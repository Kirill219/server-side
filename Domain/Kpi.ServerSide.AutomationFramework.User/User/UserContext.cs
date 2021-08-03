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

        public async Task<UserResponse> GetPetByIdAsync(
            int userId)
        {
            return await _userApiClient.GetPetByIdAsync(userId);
        }

        public async Task<ResponseMessage> GetPetByIdResponseAsync(
            string userId)
        {
            return await _userApiClient.GetPetByIdResponseAsync(userId);
        }

        public async Task<ResponseMessage> CreatePetResponseAsync(
            UserRequest userRequest)
        {
            return await _userApiClient.CreatePetResponseAsync(userRequest);
        }
        
        public async Task<CreateUserResponse> CreatePetAsync(
            UserRequest userRequest)
        {
            return await _userApiClient.CreatePetAsync(userRequest);
        }
    }
}
