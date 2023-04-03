
using Microsoft.AspNetCore.Mvc;
using MediatR;
using CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.CertificateCR;
using CQRS_CDP_.CQRS_DP.Requests.QueriesRequests.CertificateQR;

namespace CQRS_CDP_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CertificatesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CertificatesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCertificate([FromBody] CreateCertificateCommand command)
        {
            var certificateId = await _mediator.Send(command);
            return Ok(new { CertificateId = certificateId });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCertificateById(int id)
        {
            var query = new GetCertificateByIdQuery { Id = id };
            var certificate = await _mediator.Send(query);
            if (certificate == null)
            {
                return NotFound();
            }
            return Ok(certificate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCertificate(int id, UpdateCertificateCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCertificate(int id)
        {
            var command = new DeleteCertificateCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }

    }
}
