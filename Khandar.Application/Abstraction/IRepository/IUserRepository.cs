using Khandar.Domain.Entities;
using System.Threading.Tasks;

namespace Khandar.Application.Abstraction.IRepository
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<bool> CheckIfUserExistsAsync(User model);
    }
}
