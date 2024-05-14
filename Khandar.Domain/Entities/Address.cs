using Khandar.Application;
using Khandar.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khandar.Domain.Entities
{
    public  class Address  : BaseModel
    {
        public string State { get; set; } = null!;

        public string City { get; set; } = null!;
        
        public string AddressLine { get; set; } = null!;

        public string Landmark { get; set; } = null!;

        public string PinCode { get; set; } = null!;


        public bool IsNative { get; set; }


        public Guid? EntityId { get; set; }

        public bool IsDeleted { get; set; }

        public Module Module { get; set; }
    }
}
