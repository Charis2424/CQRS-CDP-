using MediatR;

namespace CQRS_CDP_.CQRS_DP.Requests.CommandsRequests.ExamCR
{
    public class DeleteExamCommand : IRequest<int>
    {
        public int Id { get; set; }
        public DeleteExamCommand(int id)
        {
            Id = id;
        }
    }
}
