using Khandar.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Khandar.Application.RRModels
{
    public class DonationAppealRequest
    {
        public int Amount { get; set; }

        public string? Description { get; set; } = null!;

        public IFormFile? File { get; set; } = null!;

        public bool IsPublic { get; set; } = false;
    }


    public class UpdateAppealRequest:DonationAppealRequest
    {
        public Guid AppealId { get; set; }
    }


    public class DonationAppealResponse : DonationAppealRequest
    {
        public Guid AppealId { get; set; }

        public Guid BeneficiaryId { get; set; }

        public DonationAppealStatus DonationAppealStatus { get; set; }

        public DateTimeOffset AppealDate { get; set; }

        public string FilePath { get; set; } = string.Empty;

        public bool IsVideo { get; set; }

        public string CaseNo { get; set; } = null!;
    }

    public class AppealResponse
    {

        public Guid AppealId { get; set; }

        public Guid BeneficiaryId { get; set; }

        public Guid? TeamAssignmentId { get; set; }

        public string Name { get; set; } = null!;

        public Gender Gender { get; set; }
        public string ContactNo { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int Amount { get; set; }

        public string Description { get; set; } = null!;

        public DonationAppealStatus DonationAppealStatus { get; set; }

        public string FilePath { get; set; } = null!;

        public bool IsVideo { get; set; }

        public DateTimeOffset AppealDate { get; set; }

        public string TeamName { get; set; } = string.Empty;

        public string Location { get; set; } = string.Empty;

        public string CaseNo { get; set; } = null!;
        public bool IsPublic { get; set; }

    }


    public class UpdateAppealStatusRequest
    {
        public Guid AppealId { get; set; }
        public DonationAppealStatus DonationAppealStatus { get; set; }
    }



    public class DonationAppealByTeamResponse
    {
        public Guid TeamId { get; set; }

        public Guid AppealId { get; set; }

        public Guid BeneficiaryId { get; set; }

        public string TeamName { get; set; } = null!;

        public string ContactNo { get; set; } = null!;

        public string BeneficiaryName { get; set; } = null!;

        public string Description { get; set; } = null!;

        public Gender Gender { get; set; }

        public int Amount { get; set; }

        public DonationAppealStatus DonationAppealStatus { get; set; }

        public string FilePath { get; set; } = null!;

        public DateTimeOffset AppealDate { get; set; }

        public string CaseNo { get; set; } =null!;
        public bool IsPublic { get; set; }
    }
}