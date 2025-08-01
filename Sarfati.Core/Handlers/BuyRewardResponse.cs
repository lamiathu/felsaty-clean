using System;

namespace Sarfati.Core.Handlers;

public class BuyRewardResponse
{
    public GiftCard? GiftCard { get; set; }
}
public class GiftCard
{
    public long Id { get; set; }
    public long ProductId { get; set; }
    
    public string ProductNameAr { get; set; }
    
    public string ProductNameEn { get; set; }
    
    public string Image { get; set; }
    public string? CardCode { get; set; }
    public DateTime? ValidTo { get; set; }
}