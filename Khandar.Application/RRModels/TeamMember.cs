using Khandar.Domain.Entities;
using Khandar.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Khandar.Application.RRModels
{
    public class TeamMemberRequest
    {
        public Guid MemberId { get; set; }

        public MemberType MemberType { get; set; } = MemberType.Member;

        public MemberInvolvement MemberInvolvement { get; set; } = MemberInvolvement.Moderate;

        public Guid TeamId { get; set; }
    }

    public class TeamMemberResponse : TeamMemberRequest
    {
        public Guid Id { get; set; }

        [Display(Name = "DOJ")]
        public DateTimeOffset CreatedOn { get; set; }
    }

    public class TeamMemberInfoResponse : TeamMemberRequest
    {
        public Guid Id { get; set; }

        public DateTimeOffset DOJ { get; set; }

        public string TeamName { get; set; } = null!;

        public string Location { get; set; } = null!;

        public string Name { get; set; } = string.Empty;
                                                                                
        public string ContactNo { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public Gender Gender { get; set; }

        public string FilePath { get; set; } = string.Empty;
    }
}
