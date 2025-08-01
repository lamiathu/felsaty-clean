using System;
using System.Collections.Generic;

namespace Sarfati.Core.Handlers;

public class GetGiftCardsResponse
{
    public List<ProductGiftCards> ProductGiftCards { get; set; } = new List<ProductGiftCards>();
   
}
public class ProductGiftCards
{
    public int GiftCardsCount { get; set; }
    public long ProductId { get; set; }
    public string ProductNameAr { get; set; }
    public string ProductNameEn { get; set; }
}

public class ProductGiftCardsDto
{
    public long GiftCardId { get; set; }
    public long ProductId { get; set; }
    public string ProductNameAr { get; set; }
    public string ProductNameEn { get; set; }
}