using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ServiceModels
{
    public class MobilePhoneSearchModel
    {
        public int? MobileId { get; set; }
        public string MobileName { get; set; }
        public decimal? Price { get; set; }
        public decimal? PriceFrom { get; set; }
        public decimal? PriceTo { get; set; }
        public int ManufacturerId { get; set; }
        public string ImageUrl  { get; set; }
    }
}
