using MediatR;

namespace Sarfati.Core.Dto
{
    public class DeleteTaskDto : IRequest<bool>
    {
        public long TaskId { get; set; }
    }
}