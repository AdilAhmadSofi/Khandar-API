using Khandar.Application;
using Khandar.Domain.Enums;

namespace Khandar.Domain.Entities
{
    public class User : BaseModel
    {
        public string Name { get; set; } = null!;

        public Gender Gender { get; set; }

        public string Username { get; set; } = null!;

        public string Email { get; set; } = null!;

        public string ContactNo { get; set; } = null!;

        public string Password { get; set; } = null!;

        public string Salt { get; set; } = null!;

        public string ResetCode { get; set; } = string.Empty;

        public string ConfirmationCode { get; set; } = string.Empty;

        public bool IsEmailVerified { get; set; }

        public UserRole UserRole { get; set; }

        public UserStatus UserStatus { get; set; }




        #region Navigation Properties
        public PartnerSeeker PartnerSeeker { get; set; } = null!;

        public Member Member { get; set; } = null!;
        #endregion


    }
}
