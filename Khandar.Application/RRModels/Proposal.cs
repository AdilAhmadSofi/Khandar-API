using Khandar.Domain.Enums;

namespace Khandar.Application.RRModels
{
    public class ProposalUpdateRequest
    {
        public  Guid Id { get; set; }

        //public Guid RecieverId { get; set; }

        public ProposalStatus ProposalStatus { get; set; }

        public bool AllowChat { get; set; }

    }
    public  class ProposalResponse
    {
        public Guid Id { get; set; }

        public ProposalStatus ProposalStatus { get; set; }

        public VisibilityLevel VisibilityLevel { get; set; }

        public bool AllowChat { get; set; }
    }
}
