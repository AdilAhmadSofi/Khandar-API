using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.RRModels;
using Khandar.Domain.Entities;
using Khandar.Persistence.Data;

namespace Khandar.Persistence.Repositories
{
    public class QualificationRepository : BaseRepository<Qualification>, IQualificationRepository
    {
        private readonly KhandarDbContext context;

        public QualificationRepository(KhandarDbContext context):base(context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<QualificationResponse>> GetQualificationById(Guid id)
        {
            string query = $@"SELECT Q.Id, Q.[Name], Q.QualificationType, Q.Institution, Q.YearOfPassing 
                                                FROM Qualifications Q
                                                INNER JOIN PartnerSeekers P
                                                ON P.Id=Q.PartnerSeekerId
                                                WHERE P.Id = @id";

            return await QueryAsync<QualificationResponse>(query, new { id });
        }
    }
}
