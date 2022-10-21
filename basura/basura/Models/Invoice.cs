using System;
using System.Collections.Generic;

namespace basura.Models
{
    public partial class Invoice
    {
        public Invoice()
        {
            DetailInvoices = new HashSet<DetailInvoice>();
        }

        public int IdInvoice { get; set; }
        public int IdCustomer { get; set; }
        public DateTime Date { get; set; }
        public decimal? Price { get; set; }
        public int? Amount { get; set; }
        public decimal? SubTotal { get; set; }

        public virtual Customer IdCustomerNavigation { get; set; } = null!;
        public virtual ICollection<DetailInvoice> DetailInvoices { get; set; }
    }
}
