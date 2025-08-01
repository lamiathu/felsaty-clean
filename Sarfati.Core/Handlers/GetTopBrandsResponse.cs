using System.Collections.Generic;

namespace Sarfati.Core.Handlers;

public class GetTopBrandsResponse
{
    public List<CategoryDto> Data { get; set; } = new();
}