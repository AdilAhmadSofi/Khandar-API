using AutoMapper;
using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.Abstraction.IServices;
using Khandar.Application.Abstractions.Identity;
using Khandar.Application.Abstractions.IEmailService;
using Khandar.Application.Abstractions.JWT;
using Khandar.Application.Abstractions.TemplateRenderer;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Application.Utils;
using Khandar.Domain.Entities;
using Khandar.Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.Text.RegularExpressions;

namespace Khandar.Application.Services;

public class UserService : IUserService
{
    private readonly IUserRepository repository;
    private readonly IEmailService emailService;
    private readonly IMapper mapper;
    private readonly IEmailTemplateRenderer emailTemplateRenderer;
    private readonly IContextService contextService;
    private readonly IJwtProvider jwtProvider;
    private readonly HttpContext httpContext;

    public UserService(IUserRepository repository, IEmailService emailService,
        IMapper mapper, IEmailTemplateRenderer emailTemplateRenderer, IHttpContextAccessor httpContextAccessor,
        IContextService contextService, IJwtProvider jwtProvider)
    {
        this.repository = repository;
        this.emailService = emailService;
        this.mapper = mapper;
        this.emailTemplateRenderer = emailTemplateRenderer;
        this.contextService = contextService;
        this.jwtProvider = jwtProvider;
        this.httpContext = httpContextAccessor.HttpContext;
    }


    public async Task<APIResponse<SignUpResponse>> SignUp(SignUpRequest model)
    {

        bool isUsernameTaken = await repository.FirstOrDefaultAsync(x => x.Username == model.Username) != null;

        if (isUsernameTaken)
            return APIResponse<SignUpResponse>.ErrorResponse(APIMessages.Auth.UsernameAlreadyTaken, APIStatusCodes.Conflict);

        bool isEmailRegistered = await repository.FirstOrDefaultAsync(x => x.Email == model.Email) != null;

        if (isEmailRegistered)
            return APIResponse<SignUpResponse>.ErrorResponse(APIMessages.Auth.EmailAlreadyRegistered, APIStatusCodes.Conflict);

        bool isPhoneNumberRegistered = await repository.FirstOrDefaultAsync(x => x.ContactNo == model.ContactNo) != null;

        if (isPhoneNumberRegistered)
            return APIResponse<SignUpResponse>.ErrorResponse(APIMessages.Auth.PhoneNumberAlreadyRegistered, APIStatusCodes.Conflict);

        var user = mapper.Map<SignUpRequest, User>(model);
        user.UserStatus = UserStatus.Active;
        user.IsEmailVerified = false;
        user.Salt = AppEncryption.GenerateSalt();
        user.Password = AppEncryption.HashPassword(user.Password, user.Salt);
        user.ConfirmationCode = DateTime.Now.Millisecond.ToString();
        user.CreatedBy = user.Id;
        user.UserRole = UserRole.PartnerSeeker;

        PartnerSeeker partnerSeeker = new();
        partnerSeeker.Id = user.Id;
        partnerSeeker.CreatedBy = user.Id;
        user.PartnerSeeker = partnerSeeker;

        int insertResult = await repository.InsertAsync(user);

        if (insertResult > 0)
        {
            var signupResponse = new SignUpResponse()
            {
                Username = user.Username,
                Email = user.Email,
                ContactNo = user.ContactNo,
                Gender = user.Gender,
                UserRole = Enum.GetName(typeof(UserRole), user.UserRole)!,
                UserStatus = Enum.GetName(typeof(UserStatus), user.UserStatus)!,
                IsEmailVerified = user.IsEmailVerified
            };

            var emailSetting = new MailSetting()
            {
                To = new List<string>() { user.Email },

                Subject = APIMessages.ConfirmEmailSubject,

                Body = await emailTemplateRenderer.RenderTemplateAsync(APIMessages.TemplateNames.EmailConfirmation, new
                {
                    Name = user.Name,
                    CompanyName = APIMessages.ProjectName,
                    ConfirmationCode = user.ConfirmationCode,
                    // Link = $"{contextService.HttpContextCurrentURL()}/{APIMessages.VerifyEmailLink}?token={user.ConfirmationCode}"
                    // Link = $"http://localhost:5115/{APIMessages.VerifyEmailLink}?token={user.ConfirmationCode}"
                    Link = $"{contextService.HttpContextClientURL()}/verifyemail",

                })
            };

            await emailService.SendEmailAsync(emailSetting);

            return APIResponse<SignUpResponse>.SuccessResponse(signupResponse, "User has been created successfully");
        }

        return APIResponse<SignUpResponse>.ErrorResponse(APIMessages.TechnicalError);
    }


    public async Task<APIResponse<SignUpResponse>> SignUp(AdminSignUpRequest model)
    {
        bool isEmailRegistered = await repository.FirstOrDefaultAsync(x => x.Email == model.Email) != null;

        if (isEmailRegistered)
            return APIResponse<SignUpResponse>.ErrorResponse(APIMessages.Auth.EmailAlreadyRegistered, APIStatusCodes.Conflict);

        bool isPhoneNumberRegistered = await repository.FirstOrDefaultAsync(x => x.ContactNo == model.ContactNo) != null;

        if (isPhoneNumberRegistered)
            return APIResponse<SignUpResponse>.ErrorResponse(APIMessages.Auth.PhoneNumberAlreadyRegistered, APIStatusCodes.Conflict);

        var user = mapper.Map<AdminSignUpRequest, User>(model);
        user.Id = Guid.NewGuid();
        user.Username = await GenerateUsername(model.Email);
        user.Salt = AppEncryption.GenerateSalt();
        string password = user.Name + new Random().Next(1000, 9999);
        user.Password = AppEncryption.HashPassword(password, user.Salt);
        user.ConfirmationCode = new Random().Next(1000, 20000).ToString();
        user.CreatedBy = contextService.GetUserId();
        user.IsEmailVerified = true;
        user.UserStatus = UserStatus.Active;
        user.Gender= model.Gender; 

        if (model.UserRole == UserRole.PartnerSeeker)
        {
            PartnerSeeker partnerSeeker = new();
            partnerSeeker.Id = user.Id;
            partnerSeeker.CreatedBy = user.Id;
            user.PartnerSeeker = partnerSeeker;
        }
        else if (model.UserRole == UserRole.Member)
        {
            Member member = new();
            member.Id = user.Id;
            member.CreatedBy = user.Id;
            user.Member = member;
        }
      
        int insertResult = await repository.InsertAsync(user);
        if (insertResult > 0)
        {
            var signupResponse = new SignUpResponse()
            {
                Username = user.Username,
                Email = user.Email,
                Gender = user.Gender,
                UserRole = Enum.GetName(typeof(UserRole), user.UserRole)!,
                UserStatus = Enum.GetName(typeof(UserStatus), user.UserStatus)!,
                IsEmailVerified = user.IsEmailVerified
            };

            var emailSetting = new MailSetting()
            {
                To = new List<string>() { user.Email },

                Subject = APIMessages.WelomeEmailSubject,
                Body = await emailTemplateRenderer.RenderTemplateAsync(APIMessages.TemplateNames.WelcomeWithCredentials, new
                {
                    Name = model.Name,
                    CompanyName = APIMessages.ProjectName,
                    Username = user.Username,
                    Password = password,
                    Link = $"{contextService.HttpContextClientURL()}/{AppRoutes.loginRoute}",

                })
            };

            await emailService.SendEmailAsync(emailSetting);

            return APIResponse<SignUpResponse>.SuccessResponse(signupResponse,$@"{model.UserRole} created successfully");
        }

        return APIResponse<SignUpResponse>.ErrorResponse(APIMessages.TechnicalError);
    }


    public async Task<APIResponse<LoginResponse>> LogIn(LoginRequest model)
    {
        var user = await repository.FirstOrDefaultAsync(x => x.Username == model.Username || x.Email == model.Username);

        if (user is null)
            return APIResponse<LoginResponse>.ErrorResponse(APIMessages.Auth.UsernameOrPasswordIsIncorrect, APIStatusCodes.BadRequest);

        if (AppEncryption.HashPassword(model.Password, user.Salt) != user.Password)
            return APIResponse<LoginResponse>.ErrorResponse(APIMessages.Auth.UsernameOrPasswordIsIncorrect, APIStatusCodes.BadRequest);

        if (user.UserStatus == UserStatus.InActive)
            return APIResponse<LoginResponse>.ErrorResponse(APIMessages.Auth.InactiveUser, APIStatusCodes.BadRequest);

        var loginResponse = new LoginResponse()
        {
            Id = user.Id,
            Username = user.Username,
            Name = user?.Name ?? "",
            UserRole = user!.UserRole,
            Gender = (int)user.Gender,
            IsEmailVerified = user.IsEmailVerified,
            Token = jwtProvider.GenerateToken(user)
        };

        if (!user.IsEmailVerified)
            return APIResponse<LoginResponse>.SuccessResponse(loginResponse, APIMessages.Auth.VerifyEmailError);

        return APIResponse<LoginResponse>.SuccessResponse(loginResponse);
    }


    public async Task<APIResponse<string>> ChangePassword(ChangePasswordRequest model)
    {
        var user = await repository.FirstOrDefaultAsync(user => user.Id == contextService.GetUserId());

        if (user is null) return APIResponse<string>.ErrorResponse(APIMessages.TechnicalError);

        if (AppEncryption.HashPassword(model.OldPassword, user.Salt) != user.Password)
            return APIResponse<string>.ErrorResponse(APIMessages.Auth.UsernameOrPasswordIsIncorrect, APIStatusCodes.BadRequest);

        user.Salt = AppEncryption.GenerateSalt();
        user.Password = AppEncryption.HashPassword(model.NewPassword, user.Salt);
        user.UpdatedOn = DateTimeOffset.Now;
        user.UpdatedBy = contextService.GetUserId();


        int updateResult = await repository.UpdateAsync(user);

        if (updateResult > 0)
            return APIResponse<string>.SuccessResponse(APIMessages.Auth.PasswordChangedSuccess);


        return APIResponse<string>.ErrorResponse(APIMessages.TechnicalError, APIStatusCodes.InternalServerError);
    }

    public async Task<APIResponse<LoginResponse>> VerifyEmail(string token)
    {
        var user = await repository.FirstOrDefaultAsync(x => x.ConfirmationCode!.Trim() == token.Trim());

        if (user is null)
            return APIResponse<LoginResponse>.ErrorResponse("Link Expired Or Check Your Email Again", APIStatusCodes.NotFound);

        user.IsEmailVerified = true;
        user.ConfirmationCode = string.Empty;

        int updateResult = await repository.UpdateAsync(user);

        if (updateResult > 0)
        {
            var loginResponse = new LoginResponse()
            {
                Id = user.Id,
                Username = user.Username,
                Name = user?.Name ?? "",
                UserRole = user!.UserRole,
                Gender = (int)user.Gender,
                IsEmailVerified = user.IsEmailVerified,
                Token = jwtProvider.GenerateToken(user)
            };
            return APIResponse<LoginResponse>.SuccessResponse(loginResponse,APIMessages.Auth.EmailVerified);
        }

        return APIResponse<LoginResponse>.ErrorResponse(APIMessages.TechnicalError);
    }


    public async Task<APIResponse<string>> ForgotPassword(ForgotPasswordRequest model)
    {
        var user = await repository.FirstOrDefaultAsync(user => user.Email == model.Email);

        if (user is null) return APIResponse<string>.ErrorResponse(APIMessages.Auth.InVaildEmailAddress);

        user.ConfirmationCode = AppEncryption.GenerateSalt();

        int updateResult = await repository.UpdateAsync(user);

        if (updateResult > 0)
        {
            var emailSetting = new MailSetting()
            {
                To = new List<string>() { user.Email },

                Subject = APIMessages.PasswordResetEmailSubject,

                Body = await emailTemplateRenderer.RenderTemplateAsync(APIMessages.TemplateNames.PasswordReset, new
                {
                    Company = APIMessages.ProjectName,
                    Link = $"{contextService.HttpContextClientURL()}{AppRoutes.ClientResetPasswordRoute}?token={user.ConfirmationCode}"
                })
            };

            await emailService.SendEmailAsync(emailSetting);

            return APIResponse<string>.SuccessResponse(null,APIMessages.Auth.CheckEmailToResetPassword);
        }

        return APIResponse<string>.ErrorResponse(APIMessages.TechnicalError);
    }


    public async Task<APIResponse<string>> ResetPassword(ResetPasswordRequest model)
    {
        var user = await repository.FirstOrDefaultAsync(x => x.ConfirmationCode!.Trim() == model.Token.Trim());

        if (user is null)
            return APIResponse<string>.ErrorResponse(APIMessages.Auth.LinkExpired, APIStatusCodes.NotFound);

        user.Salt = AppEncryption.GenerateSalt();
        user.Password = AppEncryption.HashPassword(model.NewPassword, user.Salt);
        user.ConfirmationCode = string.Empty;

        int updateResult = await repository.UpdateAsync(user);

        if (updateResult > 0)
            return APIResponse<string>.SuccessResponse(APIMessages.Auth.PasswordResetSuccess);

        return APIResponse<string>.ErrorResponse(APIMessages.TechnicalError);
    }


    public async Task<bool> IsUsernameUnique(string username)
    {
        return await repository.FirstOrDefaultAsync(x => x.Username == username) == null;
    }


    public async Task<bool> IsEmailUnique(string email)
    {
        return await repository.FirstOrDefaultAsync(x => x.Email == email) == null;
    }


    public async Task<bool> IsPhoneNumberUnique(string phoneNumber)
    {
        return await repository.FirstOrDefaultAsync(x => x.ContactNo == phoneNumber) == null;
    }


    #region Private Methods


    private async Task<string> GenerateUsername(string email)
    {
        int rand = 0;
        string cleanedUsername = Regex.Replace(email.Substring(0, email.IndexOf('@')), @"[^a-zA-Z0-9]", "").ToLower();
        string finalUsername = $"{cleanedUsername}";

        while (await repository.FirstOrDefaultAsync(x => x.Username == finalUsername) != null)
        {
            finalUsername = $"{cleanedUsername}{++rand}";
        }

        return finalUsername;
    }


    #endregion
}






#region old

/*  public class UserService : IUserService
 {
     private readonly IUserRepository repository;
 private readonly IConfiguration configuration;

 public UserService(IUserRepository repository, IConfiguration configuration)
 {
     this.repository = repository;
     this.configuration = configuration;
 }
 public async Task<int> AddUserAsync(User userRequest)
 {
     if (await repository.CheckIfUserExistsAsync(userRequest))
     {
         return default;
     }

     var salt = BCrypt.Net.BCrypt.GenerateSalt();
     Users users = new()
     {
         Username = userRequest.Username,
         email = userRequest.email,
         contact = userRequest.contactNo,
         Password = AppEncryption.CreatePasswordHash(userRequest.Password, salt),
         ConfirmPassword = userRequest.ConfirmPassword,
         ResetCode = Guid.NewGuid().ToString(),
         UserRole = UserRole.Admin,
         UserStatus = UserStatus.Active,
         gender = Gender.Male



     };

     return await repository.CreateAsync<Users>(users);
 }

 public async Task<int> UpdateUserAsync(User userRequest)
 {
     var user = await repository.GetByIdAsync<Users>(userRequest.Id);

     if (user is not null)
     {
         user.Username = userRequest.Username;
         user.email = userRequest.email;
         user.contact = userRequest.contactNo;
         user.Password = userRequest.Password;

     }

     return await repository.UpdateAsync<Users>(user);
 }

 public async Task<IEnumerable<UserResponse>> GetByIdAsync(Guid id)
 {
     return await repository.FindByAsync<UserResponse>(x => x.Id == id);
 }
 public async Task<APIResponse<string>> DeleteUserAsync(Guid userId)
 {
     var user = await repository.DeleteAsync<Users>(userId);

     if (user > 0)
     {
         return APIResponse<string>.SucessReponse("User Deleted Sucessfully");
     }

     return APIResponse<string>.errorResponse("No User Found");

 }

 public async Task<APIResponse<IEnumerable<UserResponse>>> GetALlAsync()
 {
     var users = await repository.GetAllAsync<Users>();

     if (users is not null)
     {
         return APIResponse<IEnumerable<UserResponse>>.SucessReponse(users.Select(users => new UserResponse { Id = users.Id, Username = users.Username, email = users.email, contactNo = users.contact }));
     }

     return APIResponse<IEnumerable<UserResponse>>.errorResponse("Something Went Wront");

 }

 public async Task<APIResponse<LoginResponse>> LoginAsync(LoginRequest loginRequest)
 {
     var users = (await repository.FirstOrDefault<Users>
     (user => user.Username == loginRequest.Username &&
      user.Password == loginRequest.Password));

     if (users == null)
     {
         return APIResponse<LoginResponse>.errorResponse("User Does Not Exist");
     }

     return APIResponse<LoginResponse>.SucessReponse(
         new LoginResponse
         {
             Username = users.Username,
             Token = JWTHelper.GenerateToken(users, configuration)
         });
 }
}*/
#endregion



