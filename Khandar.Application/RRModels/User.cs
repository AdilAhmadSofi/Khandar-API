using Khandar.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Khandar.Application.RRModels;

#region SigninSignUp

public class BaseSignUp
{
    [Required(ErrorMessage = "Name is Required ")]
    public string Name { get; set; } = string.Empty;


    [Required(ErrorMessage = "Email is Required")]
    [RegularExpression($@"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{{2,}}$", ErrorMessage = "Enter Valid Email")]
    public string Email { get; set; } = null!;


    [Required(ErrorMessage = "Contact Number Is Required")]
    public string ContactNo { get; set; } = null!;

   
}


public class SignUpRequest : BaseSignUp 
{
    public string Username { get; set; } = null!;

    public Gender Gender { get; set; }


    [Required(ErrorMessage = "Please Enter Password")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;


    [Compare(nameof(Password), ErrorMessage = "Password Doesn't Match")]
    public string ConfirmPassword { get; set; } = string.Empty;
}

public class AdminSignUpRequest :BaseSignUp
{
    public UserRole UserRole { get; set; }

    public Gender Gender { get; set; }
}



public class SignUpResponse
{
    public Guid Id { get; set; }

    public string Username { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string ContactNo { get; set; } = null!;

    public Gender Gender { get; set; }

    public string UserRole { get; set; } = null!;

    public string UserStatus { get; set; } = null!;

    public bool IsEmailVerified { get; set; } = false;

}

#endregion


#region Login

public class LoginRequest
{
    [Required(ErrorMessage = "Please Enter Your Valid UserName")]
    public string Username { get; set; } = null!;


    [Required(ErrorMessage = "Please Enter Password"), DataType(DataType.Password)]
    public string Password { get; set; } = null!;

}

public class LoginResponse
{
    public Guid Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string Username { get; set; } = null!;

    public string Token { get; set; } = null!;

    public UserRole UserRole { get; set; }

    public int Gender { get; set; }
    public bool IsEmailVerified { get; internal set; }
}



#endregion


#region Password

public class ForgotPasswordRequest
{
    [Required(ErrorMessage = "Email is Required")]
    [RegularExpression("^[a-zA-Z0-9+_.-]+@[a-zA-Z0-9.-]+$", ErrorMessage = "Please Enter Valid Email")]
    public string Email { get; set; } = null!;
}




public class ChangePasswordRequest
{
    [Required(ErrorMessage = "Please Enter Password")]
    [DataType(DataType.Password)]
    public string OldPassword { get; set; } = string.Empty;

    [Required(ErrorMessage = "***")]
    [DataType(DataType.Password)]
    public string NewPassword { get; set; } = string.Empty;


    [DataType(DataType.Password)]
    [Compare(nameof(NewPassword), ErrorMessage = "Password Doesn't Match")]
    public string ConfirmPassword { get; set; } = string.Empty;
}




public class ResetPasswordRequest
{
    public string Token { get; set; } = null!;


    [Required]
    public string NewPassword { get; set; } = string.Empty;


    [Required]
    [Compare(nameof(NewPassword), ErrorMessage = "Password / Confirm password do not match.")]
    public string ConfrimPassword { get; set; } = string.Empty;

}


#endregion


public class EmailVerificationRequest
{
    public string ConfirmationCode { get; set; } = string.Empty;
}





















