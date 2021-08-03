using System.Threading.Tasks;

namespace Kpi.ServerSide.AutomationFramework.Model.Domain.User
{
    public interface IUserApiClient
    {
        Task<UserResponse> GetPetByIdAsync(int petId);

        Task<ResponseMessage> GetPetByIdResponseAsync(string petId);

        Task<ResponseMessage> CreatePetResponseAsync(UserRequest petRequest);

        Task<CreateUserResponse> CreatePetAsync(UserRequest petRequest);
    }
}
