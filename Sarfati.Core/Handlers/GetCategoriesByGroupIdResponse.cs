using System.Collections.Generic;

namespace Sarfati.Core.Handlers;

public class GetCategoriesByGroupIdResponse
{
    public List<CategoryDto> Data { get; set; } = new();
    public int PageNumber { get; set; }
}