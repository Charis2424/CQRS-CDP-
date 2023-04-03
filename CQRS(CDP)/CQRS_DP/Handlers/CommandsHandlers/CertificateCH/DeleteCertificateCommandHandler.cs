using CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.CandidateCR;
using CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.CertificateCR;
using CQRS_CDP_.Data;
using CQRS_CDP_.Models;
using MediatR;

namespace CQRS_CDP_.CQRS_DP.Handlers.CommandsHandlers.CertificateCH
{
    public class DeleteCertificateCommandHandler : IRequestHandler<DeleteCertificateCommand, int>
    {
        private readonly AppDBContext _context;

        public DeleteCertificateCommandHandler(AppDBContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteCertificateCommand request, CancellationToken cancellationToken)
        {
            var certificate = await _context.Certificates.FindAsync(request.Id);

            if (certificate == null)
            {
                Console.WriteLine("No Candidate Found");
            }

            _context.Certificates.Remove(certificate);

            await _context.SaveChangesAsync(cancellationToken);

            return certificate.Id;
        }
    }
}
