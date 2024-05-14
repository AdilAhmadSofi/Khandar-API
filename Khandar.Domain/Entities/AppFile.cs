using Khandar.Application;
using Khandar.Application.Interface;
using Khandar.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace Khandar.Domain.Entities
{
    public class AppFile : BaseModel, IBaseModel
    {
        public Module Module { get; set; }

        public string FilePath { get; set; } = string.Empty;

        public bool IsVideo { get; set; }

        public Guid? EntityId { get; set; }
    }
}
