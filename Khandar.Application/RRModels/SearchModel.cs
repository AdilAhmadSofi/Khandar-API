using Khandar.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khandar.Application.RRModels
{
    public class SearchModel
    {
        public string? nameTerm { get; set; } = string.Empty;

        public Religion Religion { get; set; } = Religion.MuslimSunni;

        public MaritalStatus MaritalStatus { get; set; } = MaritalStatus.UnMarried;

        public WorkingSector WorkingSector { get; set; } = WorkingSector.Bussiness;
    }

}
