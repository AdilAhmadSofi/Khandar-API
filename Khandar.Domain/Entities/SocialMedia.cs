using Khandar.Application;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khandar.Domain.Entities
{
    public class SocialMedia : BaseModel
    {
        public Enums.SocialMedia Name { get; set; }

        public string Url { get; set; } = null!;

        public Guid PartnerSeekerId { get; set; }


        [ForeignKey(nameof(PartnerSeekerId))]
        public PartnerSeeker PartnerSeeker { get; set; } = null!;
    }
}
