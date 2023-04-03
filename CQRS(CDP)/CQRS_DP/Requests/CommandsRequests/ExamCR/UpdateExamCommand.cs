using MediatR;

namespace CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.ExamCR
{
    public class UpdateExamCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string ExamTitle { get; set; }
        public DateTime ExamDate { get; set; }
    }
}
