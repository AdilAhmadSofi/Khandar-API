using Khandar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khandar.Application.RRModels
{
    public  class HobbyRequest
    {
        public Hobbies Name { get; set; }
    }

    public class HobbyResponse : HobbyRequest
    {
        public Guid Id{ get; set; }
    }

    public class HobbyUpdateRequest : HobbyResponse
    {
    }
}
