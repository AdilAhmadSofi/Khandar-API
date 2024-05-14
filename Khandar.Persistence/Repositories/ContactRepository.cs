using Khandar.Application.Abstractions.IRepositories;
using Khandar.Domain.Entities;
using Khandar.Persistence.Data;
using Khandar.Persistence.Repositories;

namespace KashmirServices.Persistence.Repositories;

internal class ContactRepository:BaseRepository<Contact>, IContactRepository
{
    public ContactRepository(KhandarDbContext context) : base(context)
    {
            
    }
}
