using Azure;
using Khandar.Application.Abstraction.IRepository;
using Khandar.Application.RRModels;
using Khandar.Application.Shared;
using Khandar.Domain.Entities;
using Khandar.Domain.Enums;
using Khandar.Persistence.Data;

namespace Khandar.Persistence.Repositories
{


    public class PartnerSeekerRepository : BaseRepository<PartnerSeeker>, IPartnerSeekerRepository
    {

        public PartnerSeekerRepository(KhandarDbContext dbContext) : base(dbContext)
        {
        }


        //private readonly string personalPublicInfoQuery = $@" SELECT U.Id, U.[Name], U.Gender, P.Caste, P.DOB, P.MaritalStatus, P.NativeLanguage, P.[Description],
        //                                                        DATEDIFF(year,P.DOB, GETDATE() )AS Age, U.CreatedOn, P.Religion, 
        //								P.Occupation, P.WorkingSector, A.City, 
        //								(CASE WHEN P.ProfilePictureVisibilty = {(int)ProfilePictureVisibilty.Everyone} THEN  F.FilePath ELSE NULL END) AS FilePath
        //                                                        FROM Users U
        //                                                        INNER JOIN PartnerSeekers P
        //                                                        ON U.Id = P.Id
        //								LEFT JOIN Addresses A
        //								ON P.Id =A.EntityId
        //								LEFT JOIN AppFiles F
        //								ON P.Id =F.EntityId ";


        private readonly string personalPublicInfoQuery = $@" WITH PartnerSeekerCTE AS
                                                            ( SELECT ROW_NUMBER()  over (partition by   A.EntityId order by A.EntityId) as RowNum,  
										                        U.Id, U.[Name], U.Gender, P.Caste, P.DOB, P.MaritalStatus, P.NativeLanguage, P.[Description],
                                                                DATEDIFF(year,P.DOB, GETDATE() )AS Age, U.CreatedOn, P.Religion, 
																P.Occupation, P.WorkingSector, A.City,
																(CASE WHEN P.ProfilePictureVisibilty = {(int)ProfilePictureVisibilty.Everyone} THEN  F.FilePath ELSE NULL END) AS FilePath
                                                                FROM Users U
                                                                Inner JOIN PartnerSeekers P
                                                                ON U.Id = P.Id
																Inner JOIN Addresses A
																ON P.Id =A.EntityId
																inner join Qualifications Q
																on q.PartnerSeekerId = P.Id
																LEFT JOIN AppFiles F
																ON P.Id =F.EntityId)
                                                                SELECT  * FROM PartnerSeekerCTE	WHERE RowNum = 1  ";

        public async Task<IEnumerable<PartnerSeekerPublicResponse>> GetAllAsync(Gender gender)
        {
            return await QueryAsync<PartnerSeekerPublicResponse>(personalPublicInfoQuery +
                                        $@" AND Gender != {(int)gender} ORDER BY  CreatedOn ");
        }

        public async Task<IEnumerable<PartnerSeekerPublicResponse>> GetAllPartnerseekersAsync()
        {
            return await QueryAsync<PartnerSeekerPublicResponse>(personalPublicInfoQuery +
                                        $@" ORDER BY  CreatedOn ");
        }

        public async Task<IEnumerable<PartnerSeekerPublicResponse>> SearchPartnerSeeker(string nameTerm)
        {
            //string whereClause = $@" AND Religion = {(int)searchModel.Religion}                                        
            //                            OR MaritalStatus = {(int)searchModel.MaritalStatus} OR WorkingSector = {(int)searchModel.WorkingSector} 
            //                           OR [Name] LIKE '{searchModel.nameTerm}%' ORDER BY  CreatedOn ";

            string whereClause = $@" AND  [Name] LIKE '{nameTerm}%' ORDER BY  CreatedOn ";
            return await QueryAsync<PartnerSeekerPublicResponse>(personalPublicInfoQuery + whereClause);
        }

        public async Task<PersonalInfoResponse> GetPersonalInfoById(Guid id)
        {
            string personalInfoQuery = $@"SELECT U.Id, U.[Name], U.Gender, U.Username, U.Email, U.ContactNo, P.Parentage, P.Caste, P.AadhaarNo, 
	                                        P.DOB,P.MaritalStatus, P.NativeLanguage, DATEDIFF(year,  P.DOB, GETDATE())AS Age,
	                                        (CASE WHEN P.ProfilePictureVisibilty = 1 THEN NULL ELSE F.FilePath  END) AS FilePath, 
	                                        U.CreatedOn
	                                        FROM Users U
	                                        INNER JOIN PartnerSeekers P
	                                        ON U.Id = P.Id
	                                        LEFT JOIN AppFiles F
	                                        ON U.Id = F.EntityId 
                                            WHERE P.Id = @id  ";

           return await FirstOrDefaultAsync<PersonalInfoResponse>(personalInfoQuery, new { id });
        }

        public async Task<ReligiousInfoResponse> GetReligiousInfoById(Guid id)
        {
            string religiousInfoQuery = $@"SELECT P.Id, P.Religion, P.Religious, P.HasBeard, P.DoesHijab
                                                        FROM Users U
                                                        INNER JOIN PartnerSeekers P
                                                        ON U.Id = P.Id
                                                        WHERE P.Id = @id   ";
            return await FirstOrDefaultAsync<ReligiousInfoResponse>(religiousInfoQuery, new { id });
        }

        public async Task<FamilyInfoResponse> GetFamilyInfoById(Guid id)
        {
            string familyInfoQuery = $@"SELECT  P.Id, P.FatherStatus, P.MotherStatus, P.Brothers, P.Sisters,
                                                    P.BrothersMarried, P.SistersMarried, P.FamilyStatus 
		                                            FROM Users U
		                                            INNER JOIN PartnerSeekers P
		                                            ON U.Id = P.Id
		                                            WHERE P.Id = @id ";

            return await FirstOrDefaultAsync<FamilyInfoResponse>(familyInfoQuery, new { id });
        }

        public async Task<AppearanceInfoResponse> GetAppearanceInfoById(Guid id)
        {
            string appearanceInfoQuery = $@"SELECT P.Id,P.Height, P.BodyType, P.Complexion
                                                        FROM Users U
                                                        INNER JOIN PartnerSeekers P
                                                        ON U.Id = P.Id 
                                                        WHERE P.Id = @id ";


            return await FirstOrDefaultAsync<AppearanceInfoResponse>(appearanceInfoQuery, new { id });
        }

        public async Task<ProfessionalInfoResponse> GetProfessionalInfoById(Guid id)
        {
            string professionalInfoQuery = $@"SELECT P.Id, P.Occupation, P.WorkingSector, P.AnnualIncome
                                                            FROM Users U
                                                            INNER JOIN PartnerSeekers P
                                                            ON U.Id = P.Id
                                                            WHERE P.Id = @id ";
            return await FirstOrDefaultAsync<ProfessionalInfoResponse>(professionalInfoQuery, new { id });
        }

        public async Task<VisibilityLevel?> CheckVisibility(Guid senderId, Guid recieverId)
        {
            string query = $@"SELECT PROP.VisibilityLevel
							FROM Proposals PROP 
							INNER JOIN PartnerSeekers P 
							ON P.Id = PROP.RecieverId
                           
							WHERE PROP.ProposalStatus = {(int)ProposalStatus.Accepted} AND ((PROP.SenderId =@senderId AND PROP.RecieverId = @recieverId) OR
								  (PROP.SenderId =@senderId AND PROP.RecieverId = @recieverId)) ";
            return await FirstOrDefaultAsync<VisibilityLevel>(query, new { senderId,  recieverId });
        }

        public async Task<BasicProfileResponse> GetMyProfile(Guid id)
        {
            string query = $@"	
								WITH BasicInfoCTE AS
                                            (
												    SELECT ROW_NUMBER()  over (partition by   P.Id order by P.Id) as RowNum,  
													U.Id , U.[Name], P.AadhaarNo ,U.ContactNo, U.Email, F.FilePath, A.AddressLine, Q.[Name] AS Qualification 
													
													FROM Users U
													LEFT JOIN  PartnerSeekers P
													ON U.Id = P.Id
													LEFT JOIN Addresses A
													ON U.Id = A.EntityId
													LEFT JOIN Qualifications Q
													ON P.Id = Q.PartnerSeekerId
													LEFT JOIN AppFiles F
													ON U.Id = F.EntityId
                                                 
							                                          
                                            ) SELECT  * FROM BasicInfoCTE	WHERE RowNum = 1 
											AND Id = @id ";

            return await FirstOrDefaultAsync<BasicProfileResponse>(query, new { id });
        }

        public async Task<PartnerSeekerResponse> GetMyPartnerSeekerDetails(Guid id)
        {
            string query = $@"SELECT U.Id , U.[Name], U.Username,U.ContactNo, U.Email, U.Gender, 
								P.Parentage, P.AadhaarNo ,P.Caste , P.DOB , P.Religion, P.Religious, P.NativeLanguage,
								P.MaritalStatus, P.Occupation, P.WorkingSector, P.AnnualIncome, P.Disability, P.Height,
								P.BodyType, P.Complexion, P.HasBeard , P.DoesHijab, P.FamilyStatus, P.FatherStatus,
								P.MotherStatus, P.Brothers, P.Sisters, P.BrothersMarried, P.SistersMarried, P.ProfilePictureVisibilty,
								P.[Description], P.CreatedOn, F.FilePath 
									FROM Users U
                                INNER JOIN  PartnerSeekers P
                                ON U.Id = P.Id
                                LEFT JOIN Addresses A
                                ON U.Id = A.EntityId
                                LEFT JOIN Qualifications Q
                                ON P.Id = Q.PartnerSeekerId
                                LEFT JOIN AppFiles F
                                ON U.Id = F.EntityId
                                WHERE P.Id = @id  ";
            return await FirstOrDefaultAsync<PartnerSeekerResponse>(query, new { id });
        }

    }
}
