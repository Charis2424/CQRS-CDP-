using MediatR;

namespace CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.CertificateCR

{
    public class CreateCertificateCommand : IRequest<int>
    {
        public string Title { get; set; }
    }

}
