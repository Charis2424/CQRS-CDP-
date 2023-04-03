using CQRS_CDP_.Models;
using CQRS_CDP_.Queries.Requests;
using MediatR;

namespace CQRS_CDP_.Queries.Handlers
{
    public class GetCandidateByIdQueryHandler : IRequestHandler<GetCandidateByIdQuery, Candidate>
    {
        public Task<Candidate> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
