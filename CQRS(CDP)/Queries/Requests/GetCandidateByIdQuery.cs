using CQRS_CDP_.Models;
using MediatR;

namespace CQRS_CDP_.Queries.Requests
{
    public class GetCandidateByIdQuery : IRequest<Candidate>
    {
        public int Id { get; set; }
    }
}
