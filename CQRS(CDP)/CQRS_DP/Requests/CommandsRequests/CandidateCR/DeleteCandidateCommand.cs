using MediatR;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.CandidateCR
{
    public class DeleteCandidateCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteCandidateCommand(int id)
        {
            Id = id;
        }
    }
}
