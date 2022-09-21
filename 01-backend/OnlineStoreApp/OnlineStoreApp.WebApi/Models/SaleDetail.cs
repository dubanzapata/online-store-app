using System;
using System.Collections.Generic;

namespace OnlineStoreApp.WebApi.Models
{
    public partial class SaleDetail
    {
        public int IdDetail { get; set; }
        public int IdProduct { get; set; }
        public int IdSale { get; set; }
        public int AmountSale { get; set; }
        public decimal TotalPrice { get; set; }

        public virtual Product IdProductNavigation { get; set; } = null!;
        public virtual Sale IdSaleNavigation { get; set; } = null!;
    }
}
