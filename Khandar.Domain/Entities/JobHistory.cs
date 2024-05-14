using Khandar.Application;
using Khandar.Application.Interface;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khandar.Domain.Entities
{
    public class JobHistory : BaseModel,IBaseModel
    {
        public string JobTitle { get; set; } = null!;

        public string Company { get; set; } = null!;

        public DateTime From { get; set; } 

        public DateTime To { get; set; } 

        public Guid? PartnerSeekerId { get; set; }



        #region Navigation Properties
        [ForeignKey(nameof(PartnerSeekerId))]
        public PartnerSeeker PartnerSeeker { get; set; } = null!;

        #endregion
    }
}
