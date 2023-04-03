using CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.CertificateCR;
using CQRS_CDP_.Data;
using CQRS_CDP_.Models;
using MediatR;

namespace CQRS_CDP_.CQRS_DP.Handlers.CommandsHandlers.CertificateCH
{
    public class UpdateCertificateCommandHandler : IRequestHandler<UpdateCertificateCommand, int>
    {
        private readonly AppDBContext _context;

        public UpdateCertificateCommandHandler(AppDBContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateCertificateCommand request, CancellationToken cancellationToken)
        {
            var certificate = await _context.Certificates.FindAsync(request.Id);

            if (certificate == null)
            {
                Console.WriteLine("NOT FIND A CERTIFICATE WITH THIS ID");
            }

            certificate.Title = request.Title;

            await _context.SaveChangesAsync(cancellationToken);

            return certificate.Id;
        }
    }
}
