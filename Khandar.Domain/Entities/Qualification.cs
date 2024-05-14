using Khandar.Application;
using Khandar.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khandar.Domain.Entities
{
    public class Qualification : BaseModel
    {
        public string Name { get; set; } = null!;

        public QualificationType QualificationType { get; set; }

        public string Institution { get; set; } = null!;

        public string YearOfPassing { get; set; } = null!;

        public Guid PartnerSeekerId { get; set; }



        [ForeignKey(nameof(PartnerSeekerId))]
        public PartnerSeeker PartnerSeeker { get; set; } = null!;
    }
}
