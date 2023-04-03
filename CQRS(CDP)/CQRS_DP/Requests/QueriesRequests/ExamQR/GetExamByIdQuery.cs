using CQRS_CDP_.Models;
using MediatR;

namespace CQRS_CDP_.CQRS_DP.Requests.QueriesRequests.ExamQR
{
    public class GetExamByIdQuery: IRequest<Exam>
    {
        public int Id { get; set; }
    }
}
