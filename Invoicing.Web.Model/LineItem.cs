using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Invoicing.Model;

namespace Invoicing.Web.Models
{
    public class LineItem
    {
        public LineItem(Part source )
        {
            if (source.PartId == null) PartId = 0;
            else PartId = (int) source.PartId;
            Name = source.PartName;
            Upfront = source.UpfrontPercent;
            Price = source.UnitPrice;
            Discount = 0;
            Quantity = 1;
        }


        public int PartId { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public decimal Upfront { get; set; }
        public decimal Discount { get; set; }
        public int Quantity { get; set; }
    }
}
