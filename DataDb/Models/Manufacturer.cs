using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.Models
{
    public class Manufacturer
    {
        public int ManufacturerId { get; set; }
        //[MaxLength(50)]
        public string ManufacturerName { get; set; }

        public ICollection<MobilePhone> MobilePhones { get; set; } = new HashSet<MobilePhone>();

        
        
    }
}
