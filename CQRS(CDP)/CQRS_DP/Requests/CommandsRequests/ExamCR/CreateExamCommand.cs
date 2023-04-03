using MediatR;

namespace CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.ExamCR
{
    public class CreateExamCommand : IRequest<int>
    {
        public string ExamTitle { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
