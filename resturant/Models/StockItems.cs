using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace resturant.Models
{
    public class StockItems
    {
        [Key]
        public int StockId { get; set; }
        public int stockNumber { get; set; }

        [MaxLength(100)]
        public string goodsName { get; set; }

        public int storage { get; set; }

        public int SupplyingId { get; set; }

        public Supplying Supplying { get; set; }
    }
}
