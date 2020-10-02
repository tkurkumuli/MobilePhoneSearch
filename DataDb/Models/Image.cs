using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer.Models
{
    public class Image
    {
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }
        public bool IsMain { get; set; }
        public int? MobilePhoneId { get; set; }
        public MobilePhone MobilePhone { get; set; }

    }
}
