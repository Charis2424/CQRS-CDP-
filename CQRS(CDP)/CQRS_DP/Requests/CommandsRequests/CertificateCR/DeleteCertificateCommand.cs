using MediatR;
using Microsoft.CodeAnalysis.FlowAnalysis.DataFlow;

namespace CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.CertificateCR
{
    public class DeleteCertificateCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteCertificateCommand(int id)
        {
            Id = id;
        }
    }
}
