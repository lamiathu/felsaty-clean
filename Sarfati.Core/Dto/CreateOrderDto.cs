using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sarfati.Core.Dto
{
    public class CreateOrderDto
    {
        public Dictionary<long, int> Products { get; set; }
        public decimal TotalAmount { get; set; }
        public string IdempotencyId { get; set; }
    }
}