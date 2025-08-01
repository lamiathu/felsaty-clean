using MediatR;

namespace Sarfati.Core.Dto
{
    public class DeleteRewardDto : IRequest<bool>
    {
        public long RewardId { get; set; }
    }
}