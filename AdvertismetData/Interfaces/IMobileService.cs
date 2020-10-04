using BusinessLayer.Models;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IMobileService
    {
        IQueryable<MobilePhone> GetMobilePhones(MobilePhoneListFilterModel filter);
        MobilePhone GetMobilehoneDetails(int id);
        List<SelectListItem> GetManufacturers();
    }
}
