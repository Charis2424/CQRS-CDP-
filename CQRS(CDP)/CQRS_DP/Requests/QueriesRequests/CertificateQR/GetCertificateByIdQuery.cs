using CQRS_CDP_.Models;
using MediatR;

namespace CQRS_CDP_.CQRS_DP.Requests.QueriesRequests.CertificateQR
{
    public class GetCertificateByIdQuery : IRequest<Certificate>
    {
        public int Id { get; set; }
    }
}
