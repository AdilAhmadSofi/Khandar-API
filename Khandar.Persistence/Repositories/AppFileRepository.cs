using Khandar.Application.Abstraction.IRepository;
using Khandar.Domain.Entities;
using Khandar.Persistence.Data;

namespace Khandar.Persistence.Repositories
{
    public class AppFileRepository:BaseRepository<AppFile>, IAppFileRepository
    {
        public AppFileRepository(KhandarDbContext context):base(context)
        {
            
        }
    }
}
