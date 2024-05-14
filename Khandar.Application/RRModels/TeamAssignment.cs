using Khandar.Domain.Entities;
using Khandar.Domain.Enums;

namespace Khandar.Application.RRModels
{
    public class TeamAssignmentRequest
    {
        public Guid AppealId { get; set; }

        public Guid TeamId { get; set; }

    }
    public class TeamAssignmentResponse : TeamAssignmentRequest
    {
        public Guid Id { get; set; }

        public TeamAssignStatus TeamAssignStatus { get; set; } = TeamAssignStatus.Pending;

        public DateTimeOffset CreatedOn { get; set; }

        public DateTimeOffset UpdatedOn { get; set; }
    }


    public class TeamAssignedAppealResponse : TeamAssignmentResponse
    {
        public Guid BeneficiaryId { get; set; }

        public Gender Gender { get; set; }

        public string BeneficiaryName { get; set; } = string.Empty;

        public string TeamName { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Amount { get; set; }

        public DonationAppealStatus DonationAppealStatus { get; set; }

    }

}