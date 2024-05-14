using Khandar.Application.RRModels;
using Khandar.Application.Shared;

namespace Khandar.Application.Abstraction.IServices
{
    public interface IPartnerPreferenceService 
    {
        Task<APIResponse<PartnerPreferenceResponse>> InsertAsync(PartnerPreferenceRequest model);
        Task<APIResponse<PartnerPreferenceResponse>> GetMyPreference();
        Task<APIResponse<PartnerPreferenceResponse>> GetByIdAsync(Guid id);
    }
}
