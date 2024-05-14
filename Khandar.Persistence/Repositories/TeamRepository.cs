using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.RRModels;
using Khandar.Domain.Entities;
using Khandar.Persistence.Data;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Khandar.Persistence.Repositories
{
    public class TeamRepository:BaseRepository<Team>,ITeamRepository
    {
        public TeamRepository(KhandarDbContext context):base(context)
        {
            
        }

        public async Task<IEnumerable<TeamResponse>> GetMyTeamsAsync(Guid memberId)
        {
            string query = $@"   SELECT T.Id , T.[Name] ,T.[Location], T.[Description],TM.MemberId,TM.MemberType, TM.MemberInvolvement
                                            FROM Teams T
                                            INNER JOIN  TeamMembers TM 
                                            ON T.Id=TM.TeamId 
											WHERE TM.MemberId = @memberId ";
            return await QueryAsync<TeamResponse>(query , new { memberId });

        }

    }
}
