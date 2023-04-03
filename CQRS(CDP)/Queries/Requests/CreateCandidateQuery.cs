using MediatR;

namespace CQRS_CDP_.Queries.Requests
{
    public class CreateCandidateQuery : IRequest<int>
    {
        public string Name { get; set; }
    }
    
}
