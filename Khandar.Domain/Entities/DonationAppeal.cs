using Khandar.Application;
using Khandar.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khandar.Domain.Entities
{
    public class DonationAppeal : BaseModel
    {
        public Guid BeneficiaryId { get; set; }

        public int Amount { get; set; }

        public string? Description { get; set; } = null!;
      
        public DonationAppealStatus DonationAppealStatus { get; set; }

        public bool IsPublic { get; set; }=false;

        public string CaseNo { get; set; } = null!;

        //public Guid? TeamId { get; set; }


        #region Navigation Properties

        [ForeignKey(nameof(BeneficiaryId))]
        public PartnerSeeker PartnerSeeker { get; set; } = null!;

        //[ForeignKey(nameof(TeamId))]
        //public Team Team { get; set; } = null!;


        // [ForeignKey(nameof(BeneficiaryId))]
        // public Member Member { get; set; } = null!;

        #endregion
    }
}
