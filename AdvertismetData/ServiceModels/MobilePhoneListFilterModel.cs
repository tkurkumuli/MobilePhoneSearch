using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Models
{
    public class MobilePhoneListFilterModel
    {
        public string MobileName { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public int ManufacturerId { get; set; }
    }
}
