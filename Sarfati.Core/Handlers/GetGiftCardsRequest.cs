using MediatR;

namespace Sarfati.Core.Handlers;

public class GetGiftCardsRequest : IRequest<GetGiftCardsResponse>
{
    public string UserId { get; set; }
}   