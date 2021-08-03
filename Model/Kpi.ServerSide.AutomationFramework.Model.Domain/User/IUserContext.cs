using System.Threading.Tasks;

namespace Kpi.ServerSide.AutomationFramework.Model.Domain.User
{
    public interface IUserContext
    {
        Task<UserResponse> GetPetByIdAsync(int userId);

        Task<ResponseMessage> GetPetByIdResponseAsync(string userId);

        Task<ResponseMessage> CreatePetResponseAsync(UserRequest userRequest);

        Task<CreateUserResponse> CreatePetAsync(UserRequest userRequest);
    }
}
