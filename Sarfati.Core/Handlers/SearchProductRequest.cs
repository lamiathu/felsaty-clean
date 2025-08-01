using System.Collections.Generic;
using MediatR;

namespace Sarfati.Core.Handlers;

public class SearchProductRequest : IRequest<SearchProductResponse>
{
    public string Language { get; set; }
    public string ProductName { get; set; }
}