using Khandar.Domain.Entities;
using Khandar.Domain.Enums;

namespace Khandar.Application.RRModels
{
    public class AppealVerificationRequest
    {
        public Guid TeamAssignmentId { get; set; }

        public string? Feedback { get; set; } = null!;

        public Remarks Remarks { get; set; }
    }

    public class AppealVerificationResponse : AppealVerificationRequest
    {
        public Guid Id { get; set; }
    }

    public class AppealMemberVerificationResponse
    {
        public Guid BeneficiaryId { get; set; }

        public Guid VerificationId { get; set; }

        public DonationAppealStatus DonationAppealStatus { get; set; }

        public Remarks Remarks { get; set; }

        public string Feedback { get; set; } = string.Empty;

        public Guid MemberId { get; set; }

        public string MemberName { get; set; } = string.Empty;

        public MemberType MemberType { get; set; } 

        public string MemberContactNo { get; set; } = string.Empty;

        public DateTimeOffset VerificationDate { get; set; } 

        public DateTimeOffset AppealDate { get; set; } 

        public Guid TeamAssignmentId { get; set; }
    }

    public class ApproveAppealLeaderRequest
    {
        public Guid TeamAssignmentId { get; set; }

        public string? Feedback { get; set; } = null!;

        public DonationAppealStatus DonationAppealStatus { get; set; }
    }

    


}
