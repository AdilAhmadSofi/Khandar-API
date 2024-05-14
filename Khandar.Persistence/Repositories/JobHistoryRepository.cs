using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.RRModels;
using Khandar.Domain.Entities;
using Khandar.Persistence.Data;

namespace Khandar.Persistence.Repositories
{
    public class JobHistoryRepository : BaseRepository<JobHistory>, IJobHistoryRepository
    {
        private readonly KhandarDbContext context;

        public JobHistoryRepository(KhandarDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<JobHistoryResponse>> GetJobHistoriesById(Guid id)
        {
            string query = $@"SELECT J.Id, J.JobTitle, J.Company, J.[From], J.[To]
                                FROM JobHistories J
                                INNER JOIN PartnerSeekers P
                                ON P.Id=J.PartnerSeekerId
                                WHERE P.Id = @id;";

            return await QueryAsync<JobHistoryResponse>(query, new{ id });

        }
    }
}
