using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SalmonCookiesAPI.Models
{
    public class Store
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public int MinimumCustomers { get; set; }
        public int MaximumCustomers { get; set; }
        public double AverageCookiePerSale { get; set; }
        public string Owner { get; set; }
    }
}
