using System;
using Sarfati.Core.Enum;

namespace Sarfati.Core.Handlers
{
    public class GetChildRewardInfoResponse
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public long Points { get; set; }
        public GiftCard GiftCard { get; set; }
        public string Avatar { get; set; }
        public string Color { get; set; }
        public string Image { get; set; }
        public int RewardType { get; set; } = 1;
        public RewardStatus Status { get; set; }
    }
    
   
}