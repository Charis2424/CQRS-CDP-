﻿using CQRS_CDP_.Models;
using MediatR;

namespace CQRS_CDP_.CQRS_DP.Requests.QueriesRequests.CandidateQR
{
    public class GetCandidateByIdQuery : IRequest<Candidate>
    {
        public int Id { get; set; }
    }
}
