using MediatR;

namespace CQRS_CDP_.CQRS_DP.Requests.CommandsRequests
{
    public class UpdateCandidateCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
