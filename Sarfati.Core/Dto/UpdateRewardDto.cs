using System;
using System.Collections.Generic;
using MediatR;

namespace Sarfati.Core.Dto
{
    public class UpdateRewardDto : IRequest<bool>
    {
        public long RewardId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Points { get; set; } 
        public long RedeemOrderId { get; set; } 
        public List<Guid> RemoveChildIds { get; set; }
    }
}