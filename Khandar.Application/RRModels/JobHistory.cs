namespace Khandar.Application.RRModels
{
    public class JobHistoryRequest
    {
        public string JobTitle { get; set; } = null!;

        public string Company { get; set; } = null!;

        public DateTime From { get; set; }

        public DateTime To { get; set; }

    }

    public class JobHistoryResponse:JobHistoryRequest
    {
        public Guid Id { get; set; }
    }
}
