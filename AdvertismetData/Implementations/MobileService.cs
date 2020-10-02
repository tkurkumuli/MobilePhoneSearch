using BusinessLayer.Interfaces;
using BusinessLayer.ServiceModels;
using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MobilePhoneSearch.Helpers;
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

        public IQueryable<MobilePhoneModel> GetMobilePhones(MobilePhoneListFilterViewModel filter, PagingInfo paging)
        {
           return _context.MobilePhones.Include(x => x.Images)
                       .Where(x =>
                             (String.IsNullOrEmpty(filter.SearchModel.MobileName) || x.Name.Contains(filter.SearchModel.MobileName))
                              && (!filter.SearchModel.PriceFrom.HasValue || x.Price >= filter.SearchModel.PriceFrom)
                              && (!filter.SearchModel.PriceTo.HasValue || x.Price <= filter.SearchModel.PriceTo)
                              && (filter.SearchModel.ManufacturerId == null || x.ManufacturerId == filter.SearchModel.ManufacturerId)
                               ).
                                   Select(x => new MobilePhoneModel
                                   {
                                       MobileId = x.Id,
                                       Price = x.Price,
                                       MobileName = x.Name,
                                       ImageUrl = x.Images.FirstOrDefault(m => m.IsMain == true).ImageUrl
                                   });

         
        }

        public MobilePhoneDetailsResponseModel GetMobilehoneDetails(int id)
        {
           var result = new MobilePhoneDetailsResponseModel();
            if (id > 0)
            {
                var mobilephone = _context.MobilePhones.Include(x => x.Manufacturer).Include(x => x.Images).FirstOrDefault(x => x.Id == id);
                if (mobilephone != null)
                {
                    result.Id = mobilephone.Id;
                    result.MObilePhoneName = mobilephone.Name;
                    result.Size = mobilephone.Size;
                    result.Weight = mobilephone.Weight;
                    result.ScreeenSize = mobilephone.ScreeenSize;
                    result.Resolution = mobilephone.Resolution;
                    result.Processor = mobilephone.Processor;
                    result.Memory = mobilephone.Memory;
                    result.OperatingSystem = mobilephone.OperatingSystem;
                    result.Price = mobilephone.Price;
                    result.Video = mobilephone.Video;
                    result.Manufacturer = mobilephone.Manufacturer.ManufacturerName;
                    result.Images = mobilephone.Images.Select(m => m.ImageUrl).ToList();
                }
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
