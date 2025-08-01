using System;
using System.Collections.Generic;
using Sarfati.Core.Enum;

namespace Sarfati.Core.Dto
{
    public class AddRewardDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public long Points { get; set; }
        public long ImageId { get; set; }
        
        public string Image { get; set; }
        public string Avatar { get; set; }  
        public string Color { get; set; }  
        public DateTime? Duration { get; set; }
        public List<Guid> FK_ChildId { get; set; }
        public long ProductId { get; set; } = 0;
        public int RewardType { get; set; } = 1;
    }
}