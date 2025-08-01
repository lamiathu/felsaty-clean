using MediatR;

namespace Sarfati.Core.Handlers;

public class GetCategoriesRequest : IRequest<GetCategoryResponse>
{
    public int pageNumber { get; set; }
    public int PageSize { get; set; } = 20;
}