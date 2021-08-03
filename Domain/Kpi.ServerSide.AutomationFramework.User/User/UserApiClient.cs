using System.Reflection;
using System.Threading.Tasks;
using Kpi.ServerSide.AutomationFramework.Model.Domain;
using Kpi.ServerSide.AutomationFramework.Model.Domain.User;
using Kpi.ServerSide.AutomationFramework.Model.Platform.Communication;
using Kpi.ServerSide.AutomationFramework.Platform.Client;
using Kpi.ServerSide.AutomationFramework.Platform.Communication.Http;
using Kpi.ServerSide.AutomationFramework.Platform.Configuration.Environment;
using Serilog;

namespace Kpi.ServerSide.AutomationFramework.User.User
{
    public class UserApiClient : ApiClientBase, IUserApiClient
    {
        public UserApiClient(
            IClient client,
            ILogger logger,
            IEnvironmentConfiguration environmentConfiguration)
            : base(client, logger)
        {
            client.SetBaseUri(environmentConfiguration.EnvironmentUri);
        }

        public async Task<UserResponse> CreateUserAsync(
            UserRequest userRequest)
        {
            Logger.Information(
                "Start '{@Method}' with {@userRequest} as user credentials",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                userRequest);

            var restResponse = await ExecutePostAsync(
                "/user/register", userRequest);

            Logger.Information(
                "Finished '{@Method}' with {@restResponse}",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse);

            return restResponse.GetModel<UserResponse>();
        }

        public async Task<UserProfileResponse> GetUserByTokenAsync(
            string accessToken)
        {
            Logger.Information(
                "Start '{@Method}' with {@accessToken} as access token",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                accessToken);

            var restResponse = await ExecuteGetAsync(
                "/user/me", accessToken);

            Logger.Information(
                "Finished '{@Method}' with {@restResponse}",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse);

            return restResponse.GetModel<UserProfileResponse>();
        }

        public async Task<ResponseMessage> UpdateUserResponseAsync(
            UserUpdateRequest userUpdateRequest,
            string accessToken)
        {
            Logger.Information(
                "Start '{@Method}' with {@userUpdateRequest} as new user data, and {@accessToken} as access token",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                userUpdateRequest,
                accessToken);

            var restResponse = await ExecutePutAsync(
                "/user/me",
                userUpdateRequest,
                accessToken);

            Logger.Information(
                "Finished '{@Method}' with {@restResponse}",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse);

            return new ResponseMessage
            {
                Content = restResponse.Content,
                StatusCode = restResponse.StatusCode.ToString()
            };
        }

        public async Task<ResponseMessage> DeleteUserResponseAsync(
            string accessToken)
        {
            Logger.Information(
                "Start '{@Method}' with {@accessToken} as access token",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                accessToken);

            var restResponse = await ExecuteDeleteAsync(
                "/user/me",
                accessToken);

            Logger.Information(
                "Finished '{@Method}' with {@restResponse}",
                MethodBase.GetCurrentMethod().DeclaringType?.FullName,
                restResponse);

            return new ResponseMessage
            {
                Content = restResponse.Content,
                StatusCode = restResponse.StatusCode.ToString()
            };
        }
    }
}
