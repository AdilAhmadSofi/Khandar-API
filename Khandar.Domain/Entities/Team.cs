using Khandar.Application;

namespace Khandar.Domain.Entities
{
    public class Team : BaseModel
    {
        public string Name { get; set; } = null!;

        public string? Description { get; set; } = string.Empty;

        /// <summary>
        /// Team Location
        /// </summary>
        public string Location { get; set; } = null!;

        public bool  IsDeleted { get; set; }

        public ICollection<TeamMember> TeamMembers { get; set; }= null!;

    }
}
