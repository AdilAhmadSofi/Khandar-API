using Khandar.Application.RRModels;
using Khandar.Application.Shared;

namespace Khandar.Application.Abstraction.IServices
{
    public interface ISocialMediaService
    {
        Task<APIResponse<IEnumerable<SocialMediaResponse>>> GetAllAsync();

        Task<APIResponse<SocialMediaResponse>> InsertAsync(SocialMediaRequest model);

        Task<APIResponse<SocialMediaResponse>> UpdateAsync(SocialMediaUpdateRequest model);

        Task<APIResponse<SocialMediaResponse>> GetByIdAsync(Guid id);

        Task<APIResponse<SocialMediaResponse>> DeleteAsync(Guid id);

    }
}
