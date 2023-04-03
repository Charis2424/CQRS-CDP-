using CQRS_CDP_.CQRS_DP.Requests.CommandsRequests;
using CQRS_CDP_.Data;
using CQRS_CDP_.Models;
using MediatR;

namespace CQRS_CDP_.CQRS_DP.Handlers.CommandsHandlers
{
    public class UpdateCandidateCommandHandler : IRequestHandler<UpdateCandidateCommand, int>
    {
        private readonly AppDBContext _context;

        public UpdateCandidateCommandHandler(AppDBContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateCandidateCommand request, CancellationToken cancellationToken)
        {
            var candidate = await _context.Candidates.FindAsync(request.Id);

            if (candidate == null)
            {
                Console.WriteLine("NOT FIND A CANDIDATE WITH THIS ID");
            }

            candidate.Name = request.Name;

            await _context.SaveChangesAsync(cancellationToken);

            return candidate.Id;
        }
    }
}
