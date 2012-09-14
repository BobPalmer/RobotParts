using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Invoicing.Model
{
    public class Part
    {
        public virtual int? PartId { get; set; }
        public virtual string PartName { get; set; }
        public virtual decimal UnitPrice { get; set; }
        public virtual decimal UpfrontPercent { get; set; }
    }
}
