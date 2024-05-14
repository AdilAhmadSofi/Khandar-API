using Khandar.Application.Abstractions.IRepositories;
using Khandar.Application.RRModels;
using Khandar.Domain.Entities;
using Khandar.Persistence.Data;

namespace Khandar.Persistence.Repositories
{
    public class HobbyRepository : BaseRepository<Hobby>, IHobbyRepository
    {
        private readonly KhandarDbContext context;

        public HobbyRepository(KhandarDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<HobbyResponse>> GetHobbiesById(Guid id)
        {
            string query = $@"SELECT H.Id, H.[Name]
                                FROM Hobbies H
                                INNER JOIN PartnerSeekers P
                                ON P.Id=H.PartnerSeekerId
                                WHERE P.Id = @id;";

            return await QueryAsync<HobbyResponse>(query, new { id });

        }
    }
}
