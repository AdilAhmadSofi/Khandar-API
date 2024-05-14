using Khandar.Application;
using Khandar.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khandar.Domain.Entities
{
    public  class Member : BaseModel
    {
        public string Parentage { get; set; } = string.Empty;

        public DateTime DOB { get; set; }

        public string AadhaarNo { get; set; } = string.Empty;

        public MemberInvolvement MemberInvolvement { get; set; } = MemberInvolvement.Serious;

        public string? Description { get; set; } = string.Empty;

        //public Guid? TeamId { get; set; }

        public bool IsDeleted { get; set; }


        //[ForeignKey(nameof(TeamId))]
        //public Team? Team { get; set; }= null!;


        [ForeignKey(nameof(Id))]
        public User User { get; set; } = null!;

   
        //  public ICollection<Address> Addresses { get; set; } = null!;

       // public ICollection<AppFile> Files { get; set; } = null!;

    }
}
