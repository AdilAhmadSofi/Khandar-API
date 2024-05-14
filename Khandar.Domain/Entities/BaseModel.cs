using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Khandar.Application.Interface;

namespace Khandar.Application
{
    public class BaseModel : IBaseModel
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public Guid? CreatedBy { get; set; }

        public Guid? UpdatedBy { get; set; }

        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.Now;

        public DateTimeOffset? UpdatedOn { get; set; }
    }
}
