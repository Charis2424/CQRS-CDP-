using MediatR;

namespace CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.CertificateCR
{
    public class UpdateCertificateCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Title { get; set; }
    }
}
