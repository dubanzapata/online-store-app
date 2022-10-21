using System;
using System.Collections.Generic;

namespace OlineStore.Dto.Models
{
    public partial class Product
    {
        public Product()
        {
            DetailInvoices = new HashSet<DetailInvoice>();
        }

        public int IdProduct { get; set; }
        public int IdProvider { get; set; }
        public string? NameProduct { get; set; }
        public decimal? Price { get; set; }
        public int? Amount { get; set; }
        public DateTime? DateOfExpery { get; set; }

        public virtual Provider IdProviderNavigation { get; set; } = null!;
        public virtual ICollection<DetailInvoice> DetailInvoices { get; set; }
    }
}
