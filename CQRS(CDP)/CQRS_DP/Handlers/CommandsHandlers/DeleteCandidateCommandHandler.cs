using CQRS_CDP_.CQRS_DP.Requests.CommandsRequests;
using CQRS_CDP_.Data;
using CQRS_CDP_.Models;
using MediatR;

namespace CQRS_CDP_.CQRS_DP.Handlers.CommandsHandlers
{
    public class DeleteCandidateCommandHandler : IRequestHandler<DeleteCandidateCommand,int>
    {
        private readonly AppDBContext _context;

        public DeleteCandidateCommandHandler(AppDBContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _context.Candidates.FindAsync(request.Id);

            if (candidate == null)
            {
                Console.WriteLine("No Candidate Found");
            }

            _context.Candidates.Remove(candidate);

            await _context.SaveChangesAsync(cancellationToken);

            return candidate.Id;
        }
    }
}
