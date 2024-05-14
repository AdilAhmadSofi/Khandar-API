using Khandar.Application;
using Khandar.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khandar.Domain.Entities
{
    public class TeamAssignment : BaseModel
    {
        public Guid AppealId { get; set; }

        public Guid TeamId { get; set; }

        public TeamAssignStatus TeamAssignStatus { get; set; } = TeamAssignStatus.Pending;



        #region Navigation Properties

        [ForeignKey(nameof(AppealId))]
        public DonationAppeal DonationAppeal { get; set; } = null!;


        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; } = null!;

        #endregion
    }
}
