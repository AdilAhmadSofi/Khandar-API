using Khandar.Application.RRModels;
using Khandar.Domain.Entities;

namespace Khandar.Application.Abstraction.IRepository
{
    public interface IQualificationRepository:IBaseRepository<Qualification>
    {
        Task<IEnumerable<QualificationResponse>> GetQualificationById(Guid id);
    }
}
