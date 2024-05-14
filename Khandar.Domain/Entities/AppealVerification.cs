using Khandar.Application;
using Khandar.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khandar.Domain.Entities
{
    public class AppealVerification : BaseModel
    {
        public Guid MemberId  { get; set; }

        public Guid TeamAssignmentId { get; set; }

        public string? Feedback { get; set; } = null!;

        public Remarks? Remarks { get; set; }

        public DonationAppealStatus? DonationAppealStatus { get; set; }

        #region Navigation Properties

        [ForeignKey(nameof(TeamAssignmentId))]
        public TeamAssignment TeamAssignment { get; set; } = null!;


        [ForeignKey(nameof(MemberId))]
        public Member Member { get; set; } = null!; 
        #endregion
    }
}
