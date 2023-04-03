
using CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.CertificateCR;
using CQRS_CDP_.Data;
using CQRS_CDP_.Models;
using MediatR;

namespace CQRS_CDP_.CQRS_DP.Handlers.CommandsHandlers.CertificateCH
{
    public class CreateCertificateCommandHandler : IRequestHandler<CreateCertificateCommand, int>
    {
        private readonly AppDBContext _context;

        public CreateCertificateCommandHandler(AppDBContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateCertificateCommand request, CancellationToken cancellationToken)
        {
            var certificate = new Certificate
            {
                Title = request.Title
            };

            _context.Certificates.Add(certificate);
            await _context.SaveChangesAsync(cancellationToken);

            return certificate.Id;
        }
    }
}
