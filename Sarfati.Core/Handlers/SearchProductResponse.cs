using System;
using System.Collections.Generic;
using MediatR;

namespace Sarfati.Core.Handlers;

public class SearchProductResponse
{
    public List<SearchProductDto> Products { get; set; }
}
public class SearchProductDto
{
    public long ProductId { get; set; }
    public long CategoryId { get; set; }
    public string ProductNameAr { get; set; }
    public string ProductNameEn { get; set; }
    public decimal ProductPrice { get; set; }
    public decimal SellPrice { get; set; }
    public bool Available { get; set; }
    public DateTime LastUpdated { get; set; }
    public string ImageUrl { get; set; }
}