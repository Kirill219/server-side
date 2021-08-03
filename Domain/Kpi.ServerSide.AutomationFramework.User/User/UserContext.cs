using System.Threading.Tasks;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;

namespace Kpi.ServerSide.AutomationFramework.User.User
{
    public class UserContext : IUserContext
    {
        private readonly IUserApiClient _petApiClient;

        public UserContext(
            IUserApiClient petApiClient)
        {
            _petApiClient = petApiClient;
        }

        public async Task<UserResponse> GetPetByIdAsync(
            int petId)
        {
            return await _petApiClient.GetPetByIdAsync(petId);
        }

        public async Task<ResponseMessage> GetPetByIdResponseAsync(
            string petId)
        {
            return await _petApiClient.GetPetByIdResponseAsync(petId);
        }

        public async Task<ResponseMessage> CreatePetResponseAsync(
            UserRequest petRequest)
        {
            return await _petApiClient.CreatePetResponseAsync(petRequest);
        }
        
        public async Task<CreateUserResponse> CreatePetAsync(
            UserRequest petRequest)
        {
            return await _petApiClient.CreatePetAsync(petRequest);
        }
    }
}
