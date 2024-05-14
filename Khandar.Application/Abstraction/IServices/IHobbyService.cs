using Khandar.Application.RRModels;
using Khandar.Application.Shared;

namespace Khandar.Application.Abstraction.IServices
{
    public interface IHobbyService
    {
        Task<APIResponse<IEnumerable<HobbyResponse>>> GetAllAsync();

        Task<APIResponse<HobbyResponse>> Insert(HobbyRequest model);

        Task<APIResponse<HobbyResponse>> Delete(Guid id);
    }
}
