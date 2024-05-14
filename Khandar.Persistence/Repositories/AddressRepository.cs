using Khandar.Application.Abstractions.IRepositories;
using Khandar.Application.RRModels;
using Khandar.Domain.Entities;
using Khandar.Persistence.Data;
using static Khandar.Application.Shared.APIMessages;

namespace Khandar.Persistence.Repositories;

public class AddressRepository : BaseRepository<Address>, IAddressRepository
{

    public AddressRepository(KhandarDbContext context) : base(context)
    {

    }

    public async Task<IEnumerable<AddressResponse>> GetAddressesById(Guid id)
    {
        string query = $@"SELECT A.Id, A.AddressLine, A.Landmark, A.PinCode, A.[State], A.City
                            FROM Addresses A
                            INNER JOIN PartnerSeekers P
                            ON P.Id= A.EntityId
                            WHERE P.Id = @id;";

        return await QueryAsync<AddressResponse>(query, new { id });
    }
}
