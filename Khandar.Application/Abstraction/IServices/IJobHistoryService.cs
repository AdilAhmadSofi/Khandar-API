using Khandar.Application.RRModels;
using Khandar.Application.Shared;

namespace Khandar.Application.Abstraction.IServices
{
    public interface IJobHistoryService
    {
        Task<APIResponse<JobHistoryResponse>> InsertAsync(JobHistoryRequest model);

        Task<APIResponse<IEnumerable<JobHistoryResponse>>> GetAllAsync();

        Task<APIResponse<JobHistoryResponse>> DeleteAsync(Guid id);

        Task<APIResponse<JobHistoryResponse>> GetByIdAsync(Guid id);
    }
}
