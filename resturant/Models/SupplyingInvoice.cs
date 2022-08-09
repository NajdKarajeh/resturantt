using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.Models
{
    public class SupplyingInvoice
    {
        [Key]
        public int InvoiceId { get; set; }
        public DateTime invoiceDate { get; set; }

        [MaxLength(100)]
        public string goodsName { get; set; }

        [MaxLength(100)]
        public string supplierName { get; set; }

        public double discount { get; set; }
        public int goodsAmount { get; set; }

        public double price { get; set; }

        public double APDTotalCost { get; set; }

        public double TotalOfPurchase { get; set; }

        [MaxLength(50)]
        public string InvoiceStatus { get; set; }

        public int SupplyingId { get; set; }
        public Supplying Supplying { get; set; }

    }
}
