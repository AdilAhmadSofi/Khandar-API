using Khandar.Application.Abstractions.IRepositories;
using Khandar.Application.RRModels;
using Khandar.Domain.Entities;
using Khandar.Persistence.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Khandar.Persistence.Repositories
{
    public class SocialMediaRepository : BaseRepository<SocialMedia>, ISocialMediaRepository
    {
        private readonly KhandarDbContext context;

        public SocialMediaRepository(KhandarDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<SocialMediaResponse>> GetSocialMediasById(Guid id)
        {
            string query = $@"SELECT S.Id, S.[Name], S.[Url]
                                FROM SocialMedia S
                                INNER JOIN PartnerSeekers P
                                ON P.Id=S.PartnerSeekerId
                                WHERE P.Id = @id";

            return await QueryAsync<SocialMediaResponse>(query, new { id });

        }
    }
}
