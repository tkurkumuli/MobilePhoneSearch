using BusinessLayer.Models;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilePhoneSearch.Models.MobilePhones
{
    public class MobilePhoneListViewModel
    {
        public MobilePhoneListFilterModel Filter { get; set; } = new MobilePhoneListFilterModel();
    }
}
