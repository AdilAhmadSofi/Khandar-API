using Khandar.Domain.Enums;

namespace Khandar.Application.RRModels
{
    public class QualificationRequest
    {

        public string Name { get; set; } = null!;

        public QualificationType QualificationType { get; set; }

        public string Institution { get; set; } = null!;

        public string YearOfPassing { get; set; } = null!;
    }
    public class QualificationResponse : QualificationRequest
    {
        public Guid Id { get; set; }
    }

}
