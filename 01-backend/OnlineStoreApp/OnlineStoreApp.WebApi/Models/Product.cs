using System;
using System.Collections.Generic;

namespace OnlineStoreApp.WebApi.Models
{
    public partial class Product
    {
        public Product()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }

        public int IdProduct { get; set; }
        public int IdProvider { get; set; }
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public decimal Price { get; set; }
        public int Amount { get; set; }

        public virtual Provider IdProviderNavigation { get; set; } = null!;
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
