using System;
using MediatR;

namespace Sarfati.Core.Handlers
{
    public class DeleteRewardRequest : IRequest<bool>
    {
        public long RewardId { get; set; }
        public string ParentId { get; set; }
    }
}