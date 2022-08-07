using GNB.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GNB.Application.DTOs
{
    public class ProductDto
    {
        public decimal TotalAmount { get; set; }
        public List<Transaction> transactions { get; set; }
    }
}
