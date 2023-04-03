using CQRS_CDP_.CQRS_DP.Requests.CommandsRequests;
using CQRS_CDP_.Data;
using CQRS_CDP_.Models;
using MediatR;

namespace CQRS_CDP_.CQRS_DP.Handlers.CommandsHandlers
{
    public class CreateCandidateQueryHandler : IRequestHandler<CreateCandidateCommand, int>
    {
        private readonly AppDBContext _context;

        public CreateCandidateQueryHandler(AppDBContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = new Candidate
            {
                Name = request.Name
            };

            _context.Candidates.Add(candidate);
            await _context.SaveChangesAsync(cancellationToken);

            return candidate.Id;
        }
    }
}
