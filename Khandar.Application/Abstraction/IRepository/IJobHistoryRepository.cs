using Khandar.Application.RRModels;
using Khandar.Domain.Entities;

namespace Khandar.Application.Abstraction.IRepository
{
    public  interface IJobHistoryRepository:IBaseRepository<JobHistory>
    {
        Task<IEnumerable<JobHistoryResponse>> GetJobHistoriesById(Guid id);
    }
}
