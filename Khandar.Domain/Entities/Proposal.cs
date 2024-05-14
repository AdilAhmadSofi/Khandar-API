using Khandar.Application;
using Khandar.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khandar.Domain.Entities
{
    public class Proposal : BaseModel
    {
        public Guid? SenderId { get; set; }


        [ForeignKey(nameof(SenderId))]
        public PartnerSeeker? ProposalSender { get; set; }

        public Guid? RecieverId { get; set; }


        [ForeignKey(nameof(RecieverId))]
        public PartnerSeeker? ProposalReciever { get; set; }

        public ProposalStatus ProposalStatus { get; set; } = ProposalStatus.Pending;

        public VisibilityLevel VisibilityLevel { get; set; } = VisibilityLevel.Level1;

        public bool AllowChat { get; set; }

        public bool IsDeleted { get; set; }
    }
}
