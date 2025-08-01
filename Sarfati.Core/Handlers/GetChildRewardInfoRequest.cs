using System;
using MediatR;

namespace Sarfati.Core.Handlers
{
    public class GetChildRewardInfoRequest : IRequest<GetChildRewardInfoResponse>
    {
        public long RewardId { get; set; }
        public string UserId { get; set; }
        
    }
}