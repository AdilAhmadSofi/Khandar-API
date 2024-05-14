using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.RRModels;
using Khandar.Domain.Entities;
using Khandar.Persistence.Data;

namespace Khandar.Persistence.Repositories
{
    public class TeamAssignmentRepository : BaseRepository<TeamAssignment>, ITeamAssignmentRepository
    {
        public TeamAssignmentRepository(KhandarDbContext context):base(context)
        {
            
        }

        private readonly string query = $@"SELECT D.ID AS DonationAppealId, D.Amount, D.[Description] ,D.DonationAppealStatus,D.BeneficiaryId,
                                                U.[Name] AS BeneficiaryName, U.Gender,
                                                TA.Id AS TeamAssignmentId, TA.TeamAssignStatus,
                                                T.Id AS TeamId, T.[Name] AS TeamName
                                                FROM DonationAppeals D
                                                INNER JOIN TeamAssignments TA
                                                ON TA.AppealId = D.Id
                                                INNER JOIN Teams T
                                                ON T.Id = TA.TeamId
                                                INNER JOIN Users U
                                                ON U.Id = D.BeneficiaryId";
        public async Task<IEnumerable<TeamAssignedAppealResponse>> GetTeamAssignedAppeals()
        {
            return await QueryAsync<TeamAssignedAppealResponse>(query);
        }
    }
}
