using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DataLayer.Models
{
    public class MobilePhone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Size { get; set; }
        public int? Weight { get; set; }
        public decimal? ScreeenSize { get; set; }
        public string Resolution { get; set; }
        public string Processor { get; set; }
        public string Memory { get; set; }
        public string OperatingSystem { get; set; }
        public int? Price { get; set; }
        public string Video { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public ICollection<Image> Images { get; set; } = new HashSet<Image>();
    }
}
