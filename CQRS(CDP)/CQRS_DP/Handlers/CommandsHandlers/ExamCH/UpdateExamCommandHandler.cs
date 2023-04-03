using CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.CertificateCR;
using CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.ExamCR;
using CQRS_CDP_.Data;
using MediatR;

namespace CQRS_CDP_.CQRS_DP.Handlers.CommandsHandlers.ExamCH
{
    public class UpdateExamCommandHandler : IRequestHandler<UpdateExamCommand,int>
    {
        private readonly AppDBContext _context;

        public UpdateExamCommandHandler(AppDBContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(UpdateExamCommand request, CancellationToken cancellationToken)
        {
            var exam = await _context.Exams.FindAsync(request.Id);

            if (exam == null)
            {
                Console.WriteLine("NOT FIND A EXAM WITH THIS ID");
            }

            exam.ExamTitle = request.ExamTitle;
            exam.ExamDate = request.ExamDate;

            await _context.SaveChangesAsync(cancellationToken);

            return exam.Id;
        }
    }
}
