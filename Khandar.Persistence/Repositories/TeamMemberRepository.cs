using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.RRModels;
using Khandar.Domain.Entities;
using Khandar.Persistence.Data;

namespace Khandar.Persistence.Repositories
{
    public class TeamMemberRepository : BaseRepository<TeamMember>, ITeamMemberRepository
    {
        public TeamMemberRepository(KhandarDbContext context) : base(context)
        {

        }

        private string query = $@"  SELECT TM.Id, TM.MemberType, TM.MemberInvolvement,T.Id AS TeamId, T.[Name] AS TeamName, T.[Location], TM.CreatedOn AS DOJ,
                                    U.[Name], U.ContactNo, U.Email, U.Gender, F.FilePath, TM.MemberId
                                            FROM TeamMembers TM
                                            INNER JOIN Teams T
                                            ON T.Id=TM.TeamId 
											INNER JOIN Users U
											ON U.ID=TM.MemberId
											Left JOIN AppFiles F
											ON F.EntityId = U.Id  ";

        public async Task<TeamMemberInfoResponse> GetByMemberIdAsync(Guid id)
        {
            return await FirstOrDefaultAsync<TeamMemberInfoResponse>(query + "  WHERE TM.MemberId = @id", new { id });
        }

        public async Task<IEnumerable<TeamMemberInfoResponse>> GetAllTeamMembersByTeamId(Guid teamId)
        {
            return await QueryAsync<TeamMemberInfoResponse>(query+ " WHERE T.Id = @teamId", new { teamId });
        }
    }
}
