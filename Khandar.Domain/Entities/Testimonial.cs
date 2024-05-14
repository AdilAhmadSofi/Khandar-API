using Khandar.Application;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khandar.Domain.Entities
{
    public class Testimonial : BaseModel
    {

        public string Description { get; set; } = string.Empty;


        public bool IsActive { get; set; }

        public Guid CustomerId { get; set; }


        [ForeignKey(nameof(CustomerId))]
        public User User { get; set; } = null!;
    }
}
