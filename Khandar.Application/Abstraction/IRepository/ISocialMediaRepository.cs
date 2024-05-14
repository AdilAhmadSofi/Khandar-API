using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.RRModels;
using Khandar.Domain.Entities;

namespace Khandar.Application.Abstractions.IRepositories;

public interface ISocialMediaRepository : IBaseRepository<SocialMedia>
{
    Task<IEnumerable<SocialMediaResponse>> GetSocialMediasById(Guid id);
}
