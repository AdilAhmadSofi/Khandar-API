using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Application.Utils;
using System.Threading.Tasks;

namespace Khandar.Application.Abstraction.IServices
{
    public interface IUserService
    {
        Task<APIResponse<SignUpResponse>> SignUp(SignUpRequest model);


        Task<APIResponse<SignUpResponse>> SignUp(AdminSignUpRequest model);


        Task<APIResponse<LoginResponse>> LogIn(LoginRequest model);


        Task<APIResponse<string>> ForgotPassword(ForgotPasswordRequest model);


        Task<APIResponse<string>> ChangePassword(ChangePasswordRequest model);


        Task<APIResponse<LoginResponse>> VerifyEmail(string token);


        Task<APIResponse<string>> ResetPassword(ResetPasswordRequest model);


        Task<bool> IsUsernameUnique(string username);

        Task<bool> IsEmailUnique(string email);

        Task<bool> IsPhoneNumberUnique(string phoneNumber);

    }
}
