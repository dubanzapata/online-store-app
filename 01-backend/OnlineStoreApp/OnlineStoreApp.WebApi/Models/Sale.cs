using System;
using System.Collections.Generic;

namespace OnlineStoreApp.WebApi.Models
{
    public partial class Sale
    {
        public Sale()
        {
            SaleDetails = new HashSet<SaleDetail>();
        }

        public int IdSale { get; set; }
        public int IdCustomer { get; set; }
        public DateTime Date { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; } = null!;
        public virtual ICollection<SaleDetail> SaleDetails { get; set; }
    }
}
