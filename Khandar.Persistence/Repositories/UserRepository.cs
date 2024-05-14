using Khandar.Application.Abstraction.IRepository;
using Khandar.Domain.Entities;
using Khandar.Persistence.Data;

namespace Khandar.Persistence.Repositories
{

    
    public class UserRepository : BaseRepository<User>, IUserRepository
    {

        public UserRepository(KhandarDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<bool> CheckIfUserExistsAsync(User model)
        {

            if (await FindByAsync(user => user.Email == model.Email) is not null)
                return true;
            return false;
        }
    }
}
