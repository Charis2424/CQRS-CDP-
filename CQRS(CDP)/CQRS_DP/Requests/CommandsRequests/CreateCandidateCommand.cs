using MediatR;

namespace CQRS_CDP_.CQRS_DP.Requests.CommandsRequests
{
    public class CreateCandidateCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

}
