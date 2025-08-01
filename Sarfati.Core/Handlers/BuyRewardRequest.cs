using System;
using System.Collections.Generic;
using MediatR;
using Newtonsoft.Json;

namespace Sarfati.Core.Handlers
{
    public class BuyRewardRequest : IRequest<BuyRewardResponse>
    {
        public long RewardId { get; set; }
        public string ChildId { get; set; }
    }

    
}