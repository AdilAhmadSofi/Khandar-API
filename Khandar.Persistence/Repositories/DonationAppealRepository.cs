using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.RRModels;
using Khandar.Domain.Entities;
using Khandar.Domain.Enums;
using Khandar.Persistence.Data;

namespace Khandar.Persistence.Repositories
{
    public class DonationAppealRepository : BaseRepository<DonationAppeal>, IDonationAppealRepository
    {
        public DonationAppealRepository(KhandarDbContext context) : base(context)
        {

        }
        private readonly string appealQuery = $@" SELECT D.Id As AppealId, D.BeneficiaryId, U.[Name], U.Gender, U.Email, U.ContactNo,
		                                             D.Amount , D.[Description],D.DonationAppealStatus, D.CreatedOn AS AppealDate, F.FilePath,
		                                             F.IsVideo, T.[Name] AS TeamName, T.[Location], TM.Id AS TeamAssignmentId, D.CaseNo , D.IsPublic
                                               
			                                            FROM DonationAppeals D
                                                        INNER JOIN PartnerSeekers P
                                                        ON D.BeneficiaryId = P.Id
                                                        INNER JOIN	Users U
                                                        ON U.Id = P.Id
                                                        LEFT JOIN AppFiles F
                                                        ON F.EntityId = D.Id 
			                                            LEFT JOIN TeamAssignments TM
			                                            ON TM.AppealId = D.Id
			                                            LEFT JOIN Teams T
			                                            ON T.Id = TM.TeamId	 ";



        private readonly string baseQuery = $@"SELECT T.Id AS TeamId, T.[Name] AS TeamName, TA.Id AS TeamAssignmentId, DA.Id AS AppealId,
                                    DA.BeneficiaryId, U.[Name] AS BeneficiaryName, U.ContactNo, U.Gender, DA.Amount,
                                    DA.[Description], DA.CreatedOn AS AppealDate, F.FilePath, DA.DonationAppealStatus, DA.CaseNo, DA.IsPublic
                                    FROM Teams T
                                    INNER JOIN TeamAssignments TA
                                    ON T.Id = TA.TeamId
                                    INNER JOIN DonationAppeals DA
                                    ON DA.ID = TA.AppealId
                                    INNER JOIN Users U
                                    ON U.Id=DA.BeneficiaryId
                                    LEFT JOIN AppFiles F
                                    ON F.EntityId = DA.Id  ";

        public async Task<IEnumerable<DonationAppealByTeamResponse>> GetTeamAppeals(Guid teamId)
        {
            return await QueryAsync<DonationAppealByTeamResponse>(baseQuery + @$"   WHERE T.Id = @teamId AND TA.TeamAssignStatus = {(int)TeamAssignStatus.Assigned} ", new { teamId });
        }

        //public async Task<IEnumerable<DonationAppealByTeamResponse>> GetAppealsForTeamLeader(Guid teamId)
        //{
        //    return await QueryAsync<DonationAppealByTeamResponse>(baseQuery + "   WHERE T.Id = @teamId ", new { teamId });
        //}

        public async Task<IEnumerable<AppealResponse>> GetAllAppeals()
        {
            return await QueryAsync<AppealResponse>(appealQuery);
        }

        public async Task<AppealResponse> GetAppealById(Guid id)
        {
            return await FirstOrDefaultAsync<AppealResponse>(appealQuery + "  WHERE D.Id= @id", new {id});
        }


        public async Task <IEnumerable<DonationAppealResponse>> GetMyAppeal(Guid id)
        {
            string query = $@" SELECT D.Id As AppealId, D.BeneficiaryId,  D.Amount , D.[Description],
                                 D.DonationAppealStatus, D.CreatedOn AS AppealDate, F.FilePath, F.IsVideo, D.CaseNo, D.IsPublic
                                 FROM DonationAppeals D
                                 INNER JOIN PartnerSeekers P
                                 ON D.BeneficiaryId = P.Id                                                
                                LEFT JOIN AppFiles F
                                ON F.EntityId = D.Id
                                WHERE D.BeneficiaryId = @id";
            return await QueryAsync<DonationAppealResponse>(query, new { id });
        }

        public async Task<BeneficiaryDetailsResponse> GetBeneficiaryDetails(Guid id)
        {
            string query = $@"WITH BeneficiaryDetailsCTE AS
                                (
				                    SELECT ROW_NUMBER()  over (partition by   A.EntityId order by A.EntityId) as RowNum,  
								                    U.Id , U.[Name], U.Username,U.ContactNo, U.Email, U.Gender, 
								                    P.Parentage, P.AadhaarNo ,P.Caste , P.DOB , P.Religion, P.Religious,
								                    P.MaritalStatus, P.Occupation, P.WorkingSector, P.AnnualIncome, P.Disability, 
								                     P.FamilyStatus, P.FatherStatus,P.MotherStatus, P.Brothers, P.Sisters, P.BrothersMarried, P.SistersMarried, 
								                    P.[Description],  F.FilePath, A.AddressLine, A.City, A.Landmark, 
								                    A.PinCode, A.[State]
									                    FROM Users U
                                                    INNER JOIN  PartnerSeekers P
                                                    ON U.Id = P.Id
                                                    LEFT JOIN Addresses A
                                                    ON U.Id = A.EntityId
                                                    LEFT JOIN AppFiles F
                                                    ON U.Id = F.EntityId
								                    LEFT JOIN Qualifications Q
                                                    ON P.Id = Q.PartnerSeekerId

								                    ) SELECT  * FROM BeneficiaryDetailsCTE	WHERE RowNum = 1 AND Id = @id  ";

            return await FirstOrDefaultAsync<BeneficiaryDetailsResponse>(query , new { id });
        }

        public async Task<IEnumerable<AppealResponse>> GetAllTeamAppeals(Guid teamId)
        {
            return await QueryAsync<AppealResponse>(appealQuery +$@" WHERE T.Id =@teamId ", new { teamId });
        }

        public async Task<IEnumerable<AppealResponse>> GetAllApprovedAppeals()
        {
            return await QueryAsync<AppealResponse>(appealQuery+$@"  WHERE D.DonationAppealStatus = {(int)DonationAppealStatus.Approved} ");
        }

        public async Task<IEnumerable<AppealResponse>> GetAllAppealsByStatus(DonationAppealStatus appealStatus)
        {
            return await QueryAsync<AppealResponse>(appealQuery + $@"  WHERE D.DonationAppealStatus = {(int)appealStatus} ");
        }

        public async Task<IEnumerable<AppealResponse>> GetAllTeamAppealsByStatus(Guid teamId, DonationAppealStatus appealStatus)
        {
            return await QueryAsync<AppealResponse>(appealQuery + $@" WHERE T.Id =@teamId  AND D.DonationAppealStatus = {(int)appealStatus} ", new { teamId });

        }
    }
}
