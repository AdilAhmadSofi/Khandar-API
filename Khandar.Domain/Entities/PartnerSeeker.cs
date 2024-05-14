using Khandar.Application;
using Khandar.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khandar.Domain.Entities
{
    public class PartnerSeeker : BaseModel
    {
        public string Parentage { get; set; } = string.Empty;

        public string AadhaarNo { get; set; } = string.Empty;

        public string Caste { get; set; } = string.Empty;

        public DateTime DOB { get; set; } = DateTime.Now;

        public Religion Religion { get; set; } 

        public Religious Religious { get; set; } 

        public bool? HasBeard { get; set; } = false;

        public bool? DoesHijab { get; set; } = false;

        public NativeLanguage NativeLanguage { get; set; } 

        public MaritalStatus MaritalStatus { get; set; }

        public string Occupation { get; set; }= string.Empty;
        
        public WorkingSector WorkingSector { get; set; }

        public AnnualIncome AnnualIncome { get; set; }

        public Disability Disability { get; set; }

        public Height Height { get; set; }

        public BodyType BodyType { get; set; }

        public Complexion Complexion { get; set; }

        //public ProfileFor ProfileFor { get; set; }

        public FamilyStatus FamilyStatus { get; set; }

        public ParentStatus FatherStatus { get; set; }

        public ParentStatus MotherStatus { get; set; }

        public int? Brothers { get; set; }

        public int? BrothersMarried { get; set; }

        public int? Sisters { get; set; }

        public int? SistersMarried { get; set; }

        public ProfilePictureVisibilty ProfilePictureVisibilty { get; set; } = ProfilePictureVisibilty.OnlyMe;

        public string? Description { get; set; } = string.Empty;

        public bool IsDeleted { get; set; }


        #region Navigation Properties
        [ForeignKey(nameof(Id))]
        public User User { get; set; } = null!;

        public ICollection<Qualification> Qualifications { get; set; } = null!;

        public ICollection<Hobby> Hobbies { get; set; } = null!;

        public ICollection<JobHistory> JobHistories { get; set; } = null!;

        public ICollection<SocialMedia> SocialMedias { get; set; } = null!;
        #endregion


    }
}
