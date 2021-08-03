using System.Threading.Tasks;

namespace Kpi.ServerSide.AutomationFramework.Model.Domain.User
{
    public interface IUserContext
    {
        Task<UserResponse> CreateUserAsync(
            UserRequest userRequest);

        Task<UserProfileResponse> GetUserByTokenAsync(
            string accessToken);

        Task<ResponseMessage> UpdateUserResponseAsync(
            UserUpdateRequest userUpdateRequest,
            string accessToken);

        Task<ResponseMessage> DeleteUserResponseAsync(
            string accessToken);
    }
}
