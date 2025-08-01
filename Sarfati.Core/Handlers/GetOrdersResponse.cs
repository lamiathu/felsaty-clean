using System;
using System.Collections.Generic;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Sarfati.Core.Enum;

namespace Sarfati.Core.Handlers
{
    public class GetOrdersResponse
    {
        public List<Order> Orders { get; set; }
    }

    public class Order
    {
        public Guid FK_OrderId { get; set; }
        public OrderStatus Status { get; set; }
        
        public DateTime CreatedAt { get; set; }
        public List<GifCard> GifCards { get; set; }
    }

    public class GifCard
    {
        public Guid FK_OrderId { get; set; }
        public long ProductOrderedId { get; set; }
        public string ProductId { get; set; }
        public string SerialCode { get; set; }
        public string ProductNameAr { get; set; }
        public string ProductNameEn { get; set; }
        public string ImageUrl { get; set; }
        public string VaildTo { get; set; }
        public GiftCardStatus Status { get; set; }
    }
}