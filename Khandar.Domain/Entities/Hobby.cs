using Khandar.Application;
using Khandar.Application.Interface;
using Khandar.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khandar.Domain.Entities
{
    public class Hobby : BaseModel, IBaseModel
    {
        public Hobbies Name { get; set; }

        public Guid PartnerSeekerId { get; set; }

        
        [ForeignKey(nameof(PartnerSeekerId))]
        public PartnerSeeker PartnerSeeker { get; set; } = null!;
    }
}
