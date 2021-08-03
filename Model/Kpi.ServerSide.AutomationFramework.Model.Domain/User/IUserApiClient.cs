using System.Threading.Tasks;

namespace Kpi.ServerSide.AutomationFramework.Model.Domain.User
{
    public interface IUserApiClient
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
