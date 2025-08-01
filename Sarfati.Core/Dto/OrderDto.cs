using System;
using System.Collections.Generic;
using Sarfati.Core.Enum;

namespace Sarfati.Core.Handlers
{
    public class OrderDto
    {
        public Guid FK_OrderId { get; set; }
        public OrderStatus Status { get; set; }
        
        public DateTime CreatedAt { get; set; }

    }
    public class GiftCardOrderDto
    {
        public Guid FK_OrderId { get; set; }
        public OrderStatus Status { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public List<GiftCardDto> GiftCards { get; set; }
    }
    public class GiftCardDto
    {
        public Guid FK_OrderId { get; set; }
        public long ProductOrderedId { get; set; }
        public string ProductId { get; set; }
        public string SerialCode { get; set; } // Raw Serial Code (Will be encrypted)
        public string ProductNameAr { get; set; }
        public string ProductNameEn { get; set; }
        public string ImageUrl { get; set; }
        public string VaildTo { get; set; }
        public GiftCardStatus Status { get; set; }
    }
    
}
