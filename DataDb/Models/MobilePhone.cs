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
        //[MaxLength(50)]
        public string Name { get; set; }
        //[MaxLength(50)]
        public string Size { get; set; }
        public int? Weight { get; set; }
        //[Column(TypeName = "decimal(18,2)")]
        public decimal? ScreeenSize { get; set; }
        //[MaxLength(50)]
        public string Resolution { get; set; }
        //[MaxLength(50)]
        public string Processor { get; set; }
        //[MaxLength(50)]
        public string Memory { get; set; }
        //[MaxLength(50)]
        public string OperatingSystem { get; set; }
        public int? Price { get; set; }
        //[MaxLength(500)]
        public string Video { get; set; }
        public int ManufacturerId { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public ICollection<Image> Images { get; set; } = new HashSet<Image>();
    }
}
