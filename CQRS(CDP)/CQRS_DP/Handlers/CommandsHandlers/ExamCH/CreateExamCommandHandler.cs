using CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.ExamCR;
using CQRS_CDP_.Data;
using CQRS_CDP_.Models;
using MediatR;

namespace CQRS_CDP_.CQRS_DP.Handlers.CommandsHandlers.ExamCH
{
    public class CreateExamCommandHandler : IRequestHandler<CreateExamCommand, int>
    {
        private readonly AppDBContext _context;

        public CreateExamCommandHandler(AppDBContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(CreateExamCommand request, CancellationToken cancellationToken)
        {
            var exam = new Exam
            {
                ExamTitle = request.ExamTitle,
                ExamDate = request.ExamDate
            };

            _context.Exams.Add(exam);
            await _context.SaveChangesAsync(cancellationToken);

            return exam.Id;
        }
    }
}
