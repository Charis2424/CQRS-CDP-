using CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.ExamCR;
using CQRS_CDP_.Data;
using MediatR;

namespace CQRS_CDP_.CQRS_DP.Handlers.CommandsHandlers.ExamCH
{
    public class DeleteExamCommandHandler : IRequestHandler<DeleteExamCommand,int>
    {
        private readonly AppDBContext _context;

        public DeleteExamCommandHandler(AppDBContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(DeleteExamCommand request, CancellationToken cancellationToken)
        {
            var exam = await _context.Exams.FindAsync(request.Id);

            if (exam == null)
            {
                Console.WriteLine("No Exam Found");
            }

            _context.Exams.Remove(exam);

            await _context.SaveChangesAsync(cancellationToken);

            return exam.Id;
        }
    }
}
