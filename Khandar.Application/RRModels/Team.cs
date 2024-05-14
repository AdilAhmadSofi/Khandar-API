using Khandar.Domain.Enums;

namespace Khandar.Application.RRModels
{
    public class TeamRequest
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; } = string.Empty;

        public string Location { get; set; } = null!;
    }
    public class TeamResponse:TeamRequest
    {
        public Guid Id { get; set; }

        public Guid MemberId { get; set; }

        public MemberType MemberType { get; set; }

        public MemberInvolvement MemberInvolvement { get; set; }
    }
}
