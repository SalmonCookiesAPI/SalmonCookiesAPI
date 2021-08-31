using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalmonCookiesAPI.Models.DTOs
{
    public class StoreDTO
    {
        public string Location { get; set; }
        public string Description { get; set; }
        public int MinimumCustomers { get; set; }
        public int MaximumCustomers { get; set; }
        public double AverageCookiePerSale { get; set; }
        public string Owner { get; set; }
        public int[] HourlySales { get; set; }
    }
}
