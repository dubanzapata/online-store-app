using System;
using System.Collections.Generic;

namespace OlineStore.Dto.Models
{
    public partial class DetailInvoice
    {
        public int IdDetail { get; set; }
        public int IdProduct { get; set; }
        public int IdInvoice { get; set; }
        public decimal? Total { get; set; }

        public virtual Invoice IdInvoiceNavigation { get; set; } = null!;
        public virtual Product IdProductNavigation { get; set; } = null!;
    }
}
