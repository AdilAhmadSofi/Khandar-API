using Khandar.Application;
using Khandar.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khandar.Domain.Entities
{
    public class TeamMember : BaseModel
    {
        public Guid MemberId { get; set; }

        public MemberType MemberType { get; set; } = MemberType.Member;

        public MemberInvolvement MemberInvolvement { get; set; } = MemberInvolvement.Moderate;

        public Guid TeamId { get; set; }



        [ForeignKey(nameof(TeamId))]
        public Team Team { get; set; } = null!;

        [ForeignKey(nameof(MemberId))]
        public Member Member { get; set; } = null!;
    }
}
