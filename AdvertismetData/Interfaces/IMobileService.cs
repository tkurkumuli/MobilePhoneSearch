using BusinessLayer.ServiceModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobilePhoneSearch.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IMobileService
    {
        MobilePhoneDetailsResponseModel GetMobilehoneDetails(int id);
        IQueryable<MobilePhoneModel> GetMobilePhones(MobilePhoneListFilterViewModel filter, PagingInfo paging);
       // IQueryable<KeyValuePair<int, string>> GetManufacturers();
        List<SelectListItem> GetManufacturers();
    }
}
