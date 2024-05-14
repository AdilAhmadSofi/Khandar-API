using Khandar.Api.Controllers.Common;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Application.Utils;
using Khandar.Domain.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace Khandar.Api.Controllers
{
      public class UsersController : ApiController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }


        [HttpPost("signup")]
        public async Task<IResult> SignUp([FromBody] SignUpRequest model)
        {
            if (!ModelState.IsValid) return Results.BadRequest(ModelState);

            var result = await userService.SignUp(model);

            return this.APIResult(result);
        }



        [HttpPost("login")]
        public async Task<IResult> LogIn([FromBody] LoginRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Results.BadRequest(ModelState);
            }

            var result = await userService.LogIn(model);

            return this.APIResult(result);
        }

        
        
        [HttpPost("admin-signup")]
        public async Task<IResult> AdminSignUp([FromBody] AdminSignUpRequest model)
        {
            if (!ModelState.IsValid) return Results.BadRequest(ModelState);

            if (!Enum.IsDefined(typeof(UserRole), model.UserRole!))
            {
                return Results.BadRequest("Invalid role provided.");
            }

            var result = await userService.SignUp(model);

            return this.APIResult(result);
        }

        [Authorize]
        [HttpPost("changePassword")]
        public async Task<IResult> ChangePassword([FromBody] ChangePasswordRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Results.BadRequest(ModelState);
            }

            var result = await userService.ChangePassword(model);

            return this.APIResult(result);
        }


        [HttpGet("verifyemail/{token}")]
        public async Task<IResult> VerifyEmail([FromRoute]string token)
        {
            if (token == string.Empty)
            {
                return Results.BadRequest("Link Expired");
            }
            var result = await userService.VerifyEmail(token);
             return this.APIResult(result);
        }


        [HttpPost("forgotPassword")]
        public async Task<IResult> ForgotPassword([FromBody] ForgotPasswordRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Results.BadRequest(ModelState);
            }

            var result = await userService.ForgotPassword(model);

            return this.APIResult(result);
        }


        [HttpPost("resetpassword")]
        public async Task<IResult> ResetPassword([FromBody] ResetPasswordRequest model)
        {
            if (!ModelState.IsValid)
            {
                return Results.BadRequest(ModelState);
            }

            var result = await userService.ResetPassword(model);

            return this.APIResult(result);
        }


        [HttpGet("check-username/{username}")]
        public async Task<IActionResult> CheckUsernameAvailability([FromRoute] string username)
        {
            bool isUnique = await userService.IsUsernameUnique(username);

            return Ok(new { isUniqueUserName = isUnique });
        }


        [HttpGet("check-email/{email}")]
        public async Task<IActionResult> CheckEmailAvailability([FromRoute] string email)
        {
            bool isUnique = await userService.IsEmailUnique(email);

            return Ok(new { isUniqueEmail = isUnique });
        }


        [HttpGet("check-phonenumber/{phonenumber}")]
        public async Task<IResult> CheckPhoneNumberAvailability([FromRoute] string phoneNumber)
        {
            bool isUnique = await userService.IsPhoneNumberUnique(phoneNumber);

            return Results.Ok(new { isUniquePhoneNumber = isUnique });
        }
    }
}