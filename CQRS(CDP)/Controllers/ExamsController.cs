using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CQRS_CDP_.Data;
using CQRS_CDP_.Models;
using CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.CertificateCR;
using CQRS_CDP_.CQRS_DP.Requests.QueriesRequests.CertificateQR;
using MediatR;
using CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.ExamCR;
using CQRS_CDP_.CQRS_DP.Requests.QueriesRequests.ExamQR;

namespace CQRS_CDP_.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExamsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ExamsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateExam([FromBody] CreateExamCommand command)
        {
            var examId = await _mediator.Send(command);
            return Ok(new { ExamId = examId });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetExamById(int id)
        {
            var query = new GetExamByIdQuery { Id = id };
            var exam = await _mediator.Send(query);
            if (exam == null)
            {
                return NotFound();
            }
            return Ok(exam);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateExam(int id, UpdateExamCommand command)
        {
            command.Id = id;
            await _mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExam(int id)
        {
            var command = new DeleteExamCommand(id);
            await _mediator.Send(command);

            return NoContent();
        }
    }
}
