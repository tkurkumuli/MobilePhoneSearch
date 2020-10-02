using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ServiceModels
{
    public class MobilePhoneDetailsResponseModel
    {
        public int Id { get; set; }
        public string MObilePhoneName { get; set; }
        public string Size { get; set; }
        public int? Weight { get; set; }
        public decimal? ScreeenSize { get; set; }
        public string Resolution { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string OperatingSystem { get; set; }
        public int? Price { get; set; }
        public string Video { get; set; }
        public string Manufacturer { get; set; }
        public List<string> Images { get; set; }
    }
}
