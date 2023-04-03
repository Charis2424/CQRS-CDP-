using CQRS_CDP_.CQRS_DP.Requests.QueriesRequests.CertificateQR;
using CQRS_CDP_.CQRS_DP.Requests.QueriesRequests.ExamQR;
using CQRS_CDP_.Data;
using CQRS_CDP_.Models;
using MediatR;

namespace CQRS_CDP_.CQRS_DP.Handlers.QueriesHandlers.ExamQH
{
    public class GetExamByIdQueryHandler : IRequestHandler<GetExamByIdQuery, Exam>
    {
        private readonly AppDBContext _context;

        public GetExamByIdQueryHandler(AppDBContext context)
        {
            _context = context;
        }

        public async Task<Exam> Handle(GetExamByIdQuery request, CancellationToken cancellationToken)
        {
            var exam = await _context.Exams.FindAsync(request.Id);

            return exam;
        }
    }
}
