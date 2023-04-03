using CQRS_CDP_.CQRS_DP.Requests.QueriesRequests.CandidateQR;
using CQRS_CDP_.Data;
using CQRS_CDP_.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_CDP_.CQRS_DP.Handlers.QueriesHandlers.CandidateQR
{
    public class GetCandidateByIdQueryHandler : IRequestHandler<GetCandidateByIdQuery, Candidate>
    {
        private readonly AppDBContext _context;

        public GetCandidateByIdQueryHandler(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Candidate> Handle(GetCandidateByIdQuery request, CancellationToken cancellationToken)
        {
            var candidate = await _context.Candidates.FindAsync(request.Id);

            return candidate;
        }
    }
}
