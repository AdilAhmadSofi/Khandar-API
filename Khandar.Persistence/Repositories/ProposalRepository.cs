using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.RRModels;
using Khandar.Domain.Entities;
using Khandar.Domain.Enums;
using Khandar.Persistence.Data;

namespace Khandar.Persistence.Repositories
{
    public class ProposalRepository : BaseRepository<Proposal>, IProposalRepository
    {
        public ProposalRepository(KhandarDbContext context) : base(context)
        {
        }

       // private readonly string recievedProposalQuery = $@"SELECT PROP.Id AS ProposalId, PROP.RecieverId, U.[Name], DATEDIFF(YEAR, P.DOB,GETDATE()) AS Age, 
       //                     P.Caste, PROP.CreatedOn, PROP.VisibilityLevel, PROP.ProposalStatus, 
							//PROP.AllowChat
							//FROM Proposals PROP 
							//INNER JOIN PartnerSeekers P 
							//ON P.Id = PROP.SenderId
							//INNER JOIN Users U
							//ON U.Id = P.Id    ";

       // private readonly string sentProposalQuery = $@"SELECT PROP.Id AS ProposalId, PROP.RecieverId, U.[Name], DATEDIFF(YEAR, P.DOB,GETDATE()) AS Age, 
       //                     P.Caste, PROP.CreatedOn, PROP.VisibilityLevel, PROP.ProposalStatus, 
							//PROP.AllowChat
							//FROM Proposals PROP 
							//INNER JOIN PartnerSeekers P 
							//ON P.Id = PROP.RecieverId
							//INNER JOIN Users U
							//ON U.Id = P.Id    ";

        private readonly string sendProposalQuery = $@"SELECT PROP.Id AS ProposalId ,PROP.RecieverId, U.[Name], U.Gender, P.Caste, P.MaritalStatus, P.NativeLanguage, P.[Description],
                                                                DATEDIFF(year,P.DOB, GETDATE() )AS Age, U.CreatedOn, P.Religion, 
																P.Occupation, P.WorkingSector, A.City, 
																PROP.CreatedOn, PROP.VisibilityLevel, PROP.ProposalStatus, PROP.AllowChat,
																(CASE WHEN P.ProfilePictureVisibilty = 3 THEN  F.FilePath ELSE NULL END) AS FilePath
                                                                FROM Proposals PROP 
																INNER JOIN PartnerSeekers P 
																ON P.Id = PROP.RecieverId
																INNER JOIN Users U
																ON U.Id = P.Id 
																LEFT JOIN Addresses A
																ON P.Id =A.EntityId
																LEFT JOIN AppFiles F
																ON P.Id =F.EntityId  ";


		private readonly string recievedProposalQuery = $@"	SELECT PROP.Id AS ProposalId ,PROP.SenderId,  PROP.RecieverId, U.[Name], U.Gender, P.Caste, P.MaritalStatus, P.NativeLanguage, P.[Description],
                                                                DATEDIFF(year,P.DOB, GETDATE() )AS Age, U.CreatedOn, P.Religion, 
																P.Occupation, P.WorkingSector, A.City, 
																PROP.CreatedOn, PROP.VisibilityLevel, PROP.ProposalStatus, PROP.AllowChat,
																(CASE WHEN P.ProfilePictureVisibilty = 3 THEN  F.FilePath ELSE NULL END) AS FilePath
                                                                FROM Proposals PROP 
																INNER JOIN PartnerSeekers P 
																ON P.Id = PROP.SenderId
																INNER JOIN Users U
																ON U.Id = P.Id 
																LEFT JOIN Addresses A
																ON P.Id =A.EntityId
																LEFT JOIN AppFiles F
																ON P.Id =F.EntityId  ";

        public async Task<IEnumerable<ProposalInfoResponse>> GetSentProposals(Guid senderId)
        {
            return await QueryAsync<ProposalInfoResponse>(sendProposalQuery + " WHERE PROP.SenderId = @senderId", new { senderId });
        }

        public async Task<IEnumerable<ProposalInfoResponse>> GetRecievedProposals(Guid recieverId)
        {
            return await QueryAsync<ProposalInfoResponse>(recievedProposalQuery + $@" WHERE PROP.RecieverId = @recieverId  And PROP.ProposalStatus ={(int)ProposalStatus.Pending}", new { recieverId });
        }

        public async Task<IEnumerable<ProposalInfoResponse>> GetAcceptedProposals(Guid id)
        {

			string query1 = $@" WITH ProposalSenderCTE AS(
								SELECT ROW_NUMBER() OVER(partition by PROP.SenderId ORDER BY  PROP.SenderId ) AS RowNum,
								PROP.Id AS ProposalId ,PROP.SenderId,U.Id, PROP.RecieverId, U.[Name], U.Gender, 
								P.Caste, P.MaritalStatus, P.NativeLanguage, P.[Description],
								DATEDIFF(year,P.DOB, GETDATE() )AS Age, P.Religion, 
								P.Occupation, P.WorkingSector, A.City, 
								PROP.CreatedOn, PROP.VisibilityLevel, PROP.ProposalStatus, PROP.AllowChat,
								(CASE WHEN P.ProfilePictureVisibilty = 3 THEN  F.FilePath ELSE NULL END) AS FilePath
								FROM Proposals PROP 
								INNER JOIN PartnerSeekers P 
								ON P.Id = PROP.SenderId
								INNER JOIN Users U
								ON U.Id = P.Id 
								LEFT JOIN Addresses A
								ON P.Id =A.EntityId
								LEFT JOIN AppFiles F
								ON P.Id =F.EntityId
								WHERE PROP.RecieverId = @id AND  PROP.ProposalStatus={(int)ProposalStatus.Accepted} 
						)
						SELECT * FROM ProposalSenderCTE WHERE RowNum =1 ";


			string query2 = $@" WITH ProposalRecieverCTE AS (
								SELECT ROW_NUMBER() OVER(partition by PROP.RecieverId ORDER BY  PROP.RecieverId ) AS RowNum,
								PROP.Id AS ProposalId ,PROP.SenderId, PROP.RecieverId,U.Id, U.[Name], U.Gender, P.Caste,
								P.MaritalStatus, P.NativeLanguage, P.[Description],
								DATEDIFF(year,P.DOB, GETDATE() )AS Age, P.Religion, 
								P.Occupation, P.WorkingSector, A.City, 
								PROP.CreatedOn, PROP.VisibilityLevel, PROP.ProposalStatus, PROP.AllowChat,
								(CASE WHEN P.ProfilePictureVisibilty = 3 THEN  F.FilePath ELSE NULL END) AS FilePath
								FROM Proposals PROP 
								INNER JOIN PartnerSeekers P 
								ON P.Id = PROP.RecieverId
								INNER JOIN Users U
								ON U.Id = P.Id 
								LEFT JOIN Addresses A
								ON P.Id =A.EntityId
								LEFT JOIN AppFiles F
								ON P.Id =F.EntityId
								WHERE PROP.SenderId = @id AND  PROP.ProposalStatus={(int)ProposalStatus.Accepted} 
							)
								SELECT * FROM ProposalRecieverCTE WHERE RowNum =1 ";

            
            var res1= await QueryAsync<ProposalInfoResponse>(query1 , new { id });
            var res2= await QueryAsync<ProposalInfoResponse>(query2 , new { id });
			var res3=res1.ToList();
			res3.AddRange(res2);

			return res3;
        }
    }
}
