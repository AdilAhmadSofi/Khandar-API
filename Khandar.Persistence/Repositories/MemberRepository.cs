using Khandar.Application.Abstraction.IRepository;
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
    public class MemberRepository : BaseRepository<Member>, IMemberRepository
    {
        public MemberRepository(KhandarDbContext context):base(context)
        {
            
        }


        string query = $@" 	SELECT U.Id , U.[Name], M.Parentage, U.ContactNo, U.Email, U.Gender,
					            M.DOB, M.AadhaarNo, M.[Description], A.FilePath,TM.MemberType,
					             M.MemberInvolvement, T.Id AS TeamId, T.[Name] AS TeamName
					            FROM Users U
					            INNER JOIN Members M
					            ON U.Id = M.Id
					            LEFT JOIN TeamMembers TM
					            ON TM.MemberId = M.Id
					            LEFT JOIN Teams T
					            ON T.Id=TM.TeamId
					            LEFT JOIN AppFiles A
					            ON M.ID = A.EntityId 
                                WHERE M.IsDeleted =0  ";


        //string query = $@" 		SELECT U.Id , U.[Name], M.Parentage, U.ContactNo, U.Email, U.Gender,
        //         M.DOB, M.AadhaarNo, M.[Description], A.FilePath
        //         FROM Users U
        //         INNER JOIN Members M
        //         ON U.Id = M.Id
        //         LEFT JOIN AppFiles A
        //         ON M.ID = A.EntityId 
        //                        WHERE M.IsDeleted =0 ";
        public async Task<IEnumerable<MemberResponse>> GetAllMembers()
        {
			
            return await QueryAsync<MemberResponse>(query );
        }


        public async Task<IEnumerable<MemberBasicDetailsResponse>> GetAllMembersBasicDetails()
        {
            string query = $@"	SELECT U.Id , U.[Name], A.FilePath
					            FROM Users U
					            INNER JOIN Members M
					            ON U.Id = M.Id
					            LEFT JOIN AppFiles A
					            ON M.ID = A.EntityId 
                                WHERE M.IsDeleted =0  ";
            return await QueryAsync<MemberBasicDetailsResponse>(query);
        }

        public async Task<MemberResponse> GetMemberById(Guid id)
        {
            return await FirstOrDefaultAsync<MemberResponse>(query+$@"   And M.Id=@id ", new {id});
        }
    }
}
