using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Implementations
{
    public class MobileService : IMobileService
    {
        readonly DataContext _context;
        public MobileService(DataContext context)
        {
            _context = context;
        }

        public IQueryable<MobilePhone> GetMobilePhones(MobilePhoneListFilterModel filter)
        {
            return _context.MobilePhones.Include(x => x.Images)
                        .Where(x =>
                              (String.IsNullOrEmpty(filter.MobileName) || x.Name.Trim().ToLower().Contains(filter.MobileName.Trim().ToLower()))
                               && (!filter.PriceFrom.HasValue || x.Price >= filter.PriceFrom)
                               && (!filter.PriceTo.HasValue || x.Price <= filter.PriceTo)
                               && (filter.ManufacturerId == 0 || x.ManufacturerId == filter.ManufacturerId)
                                );
        }

        public MobilePhone GetMobilehoneDetails(int id)
        {
           var result = new MobilePhone();
            if (id > 0)
            {
                result = _context.MobilePhones.Include(x => x.Manufacturer).Include(x => x.Images).FirstOrDefault(x => x.Id == id);
            }
            return result;
        }
        public List<SelectListItem> GetManufacturers()
        {
            var result = new List<SelectListItem>();
            var manufacturers = _context.Manufacturers.ToList();
            foreach (var item in manufacturers)
            {
                result.Add(new SelectListItem { Text = item.ManufacturerName.ToString(), Value = item.ManufacturerId.ToString() });
            }
            return result;
        }
    }
}
