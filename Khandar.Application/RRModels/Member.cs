using Khandar.Domain.Enums;
using Microsoft.AspNetCore.Http;

namespace Khandar.Application.RRModels
{
    public class MemberRequest
    {
        public Guid? Id { get; set; }

        public string Name { get; set; }

        public string Parentage { get; set; } = string.Empty;

        public string? Email{ get; set; }= string.Empty;

        public string? ContactNo{ get; set; }= string.Empty;

        public Gender Gender { get; set; }

        public DateTime? DOB { get; set; }

        public string AadhaarNo { get; set; } = string.Empty;

        public MemberInvolvement? MemberInvolvement { get; set; }

        public string? Description { get; set; } = string.Empty;

        public IFormFile? File { get; set; } = null!;
    }

    public class MemberResponse: MemberRequest
    {
        public Guid TeamId { get; set; }

        public string FilePath { get; set; } = string.Empty;

        public string TeamName { get; set; } = string.Empty;
        public MemberType MemberType { get; set; }
    }

    public class MemberBasicDetailsResponse 
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;

        public string FilePath { get; set; } = string.Empty;

    }

}

