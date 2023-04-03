using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CQRS_CDP_.Data;
using CQRS_CDP_.Models;
using CQRS_CDP_.CQRS_DP.Requests.QueriesRequests;
using MediatR;
using CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.CandidateCR;
using CQRS_CDP_.CQRS_DP.Requests.QueriesRequests.CandidateQR;

namespace CQRS_CDP_.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CandidateController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CandidateController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCandidate([FromBody] CreateCandidateCommand command)
        {
            var candidateId = await _mediator.Send(command);
            return Ok(new { CandidateId = candidateId });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCandidateById(int id)
        {
            var query = new GetCandidateByIdQuery { Id = id };
            var candidate = await _mediator.Send(query);
            if (candidate == null)
            {
                return NotFound();
            }
            return Ok(candidate);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCandidate(int id, UpdateCandidateCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCandidate(int id)
        {
            var command = new DeleteCandidateCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }

        //[HttpPost("{candidateId}/certificates")]
        //public async Task<IActionResult> AddCertificateToCandidate(int candidateId, [FromBody] AddCertificateToCandidateCommand command)
        //{
        //    command.CandidateId = candidateId;
        //    await _mediator.Send(command);
        //    return Ok();
        //}
    }

}
