﻿using CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.CandidateCR;
using CQRS_CDP_.Data;
using CQRS_CDP_.Models;
using MediatR;

namespace CQRS_CDP_.CQRS_DP.Handlers.CommandsHandlers.CandidateCH
{
    public class CreateCandidateCommandHandler : IRequestHandler<CreateCandidateCommand, int>
    {
        private readonly AppDBContext _context;

        public CreateCandidateCommandHandler(AppDBContext context)
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
