using Khandar.Application.Abstraction.IRepository;
using Khandar.Domain.Entities;
using Khandar.Persistence.Data;

namespace Khandar.Persistence.Repositories
{
    public class PartnerPrefereceRepository:BaseRepository<PartnerPreference>, IPartnerPrefereceRepository
    {
        public PartnerPrefereceRepository(KhandarDbContext context):base(context)
        {
            
        }
    }
}
