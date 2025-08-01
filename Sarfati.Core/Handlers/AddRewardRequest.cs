using System;
using System.Collections.Generic;
using MediatR;
using Sarfati.Core.Enum;

namespace Sarfati.Core.Handlers
{
    public class AddRewardRequest : IRequest<bool>
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long Points { get; set; }
        public List<Guid> FK_ChildId { get; set; }
        public string FK_ParentId { get; set; }
        public string Avatar { get; set; }
        public string Color { get; set; }
        public DateTime? Duration { get; set; }
        public long? ImageId { get; set; }
        public string Image { get; set; }
        public long ProductId { get; set; } 
        public int RewardType { get; set; }
    }
}