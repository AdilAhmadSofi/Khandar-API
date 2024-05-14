using Khandar.Application;
using Khandar.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khandar.Domain.Entities
{
    public class PartnerPreference : BaseModel
    {
        public string Caste { get; set; } = string.Empty;

        public AgeGroup AgeGroup { get; set; }

        public Religion Religion { get; set; }

        public Religious Religious { get; set; }

        public bool? HasBeard { get; set; } = false;

        public bool? DoesHijab { get; set; } = false;

        public NativeLanguage NativeLanguage { get; set; }

        public WorkingSector WorkingSector { get; set; }

        public AnnualIncome AnnualIncome { get; set; }

        public FamilyStatus FamilyStatus { get; set; }


        [ForeignKey(nameof(Id))]
        public PartnerSeeker PartnerSeeker { get; set; } = null;
    }
}
