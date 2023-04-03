using CQRS_CDP_.CQRS_DP.Requests.QueriesRequests.CandidateQR;
using CQRS_CDP_.CQRS_DP.Requests.QueriesRequests.CertificateQR;
using CQRS_CDP_.Data;
using CQRS_CDP_.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace CQRS_CDP_.CQRS_DP.Handlers.QueriesHandlers.CertificateQH
{
    public class GetCertificateByIdQueryHandler : IRequestHandler<GetCertificateByIdQuery, Certificate>
    {
        private readonly AppDBContext _context;

        public GetCertificateByIdQueryHandler(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Certificate> Handle(GetCertificateByIdQuery request, CancellationToken cancellationToken)
        {
            var certificate = await _context.Certificates.FindAsync(request.Id);

            return certificate;
        }
    }
}
