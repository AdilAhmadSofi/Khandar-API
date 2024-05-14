using Khandar.Domain.Enums;

namespace Khandar.Application.RRModels
{
    public class SocialMediaRequest
    {
        public SocialMedia Name { get; set; }

        public string Url { get; set; } = null!;

    }

    public class SocialMediaResponse : SocialMediaRequest
    {
        public Guid Id { get; set; }
    }

    public class SocialMediaUpdateRequest : SocialMediaResponse
    {
    }
}
