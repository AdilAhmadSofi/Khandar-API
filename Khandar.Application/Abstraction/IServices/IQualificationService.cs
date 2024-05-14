using Khandar.Application.RRModels;
using Khandar.Application.Shared;

namespace Khandar.Application.Abstraction.IServices
{
    public interface IQualificationService
    {
        Task<APIResponse<QualificationResponse>> InsertAsync(QualificationRequest model);

        Task<APIResponse<IEnumerable<QualificationResponse>>> GetMyQualifications();

        Task<APIResponse<QualificationResponse>> DeleteAsync(Guid id);

        Task<APIResponse<QualificationResponse>> GetByIdAsync(Guid id);
    }
}
