using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.ServiceModels
{
    //public class MobilePhoneResponseModel
    //{
    //    public List<MobilePhoneModel> MobilePhones { get; set; } = new List<MobilePhoneModel>();
    //    public List<KeyValuePair<int, string>> Manufacturers { get; set; } = new List<KeyValuePair<int, string>>();
    //}
    public class MobilePhoneModel
    {
        public int MobileId { get; set; }
        public decimal? Price { get; set; }
        public string MobileName { get; set; }
        public List<KeyValuePair<int, string>> Manufacturers { get; set; }
        public string ImageUrl { get; set; }
    }

}
