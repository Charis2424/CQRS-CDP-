using CQRS_CDP_.Models;
using CQRS_CDP_.Queries.Requests;
using MediatR;

namespace CQRS_CDP_.Queries.Handlers
{
    public class CreateCandidateQueryHandler : IRequestHandler<CreateCandidateQuery,int>
    {
        private readonly List<Candidate> _candidates;

        public CreateCandidateQueryHandler(List<Candidate> candidates)
        {
            _candidates = candidates;
        }

        public Task<int> Handle(CreateCandidateQuery request, CancellationToken cancellationToken)
        {
            var candidate = new Candidate
            {
                Id = _candidates.Count + 1,
                Name = request.Name,
                Certificates = new List<Certificate>()
            };

            _candidates.Add(candidate);

            return Task.FromResult(candidate.Id);
        }
    }
}
