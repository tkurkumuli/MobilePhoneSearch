using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using DataLayer;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace BusinessLayer.Implementations
{
    public class MobileService :  Repository<MobilePhone>
    {
        public MobileService(DbContext context) : base(context) { }


        public override IEnumerable<MobilePhone> Get(MobilePhoneListFilterModel filter) =>
         context.Set<MobilePhone>()
         .Include(x => x.Images)
        .Where(x => (String.IsNullOrEmpty(filter.MobileName) || x.Name.Trim().ToLower().Contains(filter.MobileName.Trim().ToLower()))
                               && (!filter.PriceFrom.HasValue || x.Price >= filter.PriceFrom)
                               && (!filter.PriceTo.HasValue || x.Price <= filter.PriceTo)
                               && (filter.ManufacturerId == 0 || x.ManufacturerId == filter.ManufacturerId));
        
        public MobilePhone GetMobilehoneDetails(int id)
        {
            var result = new MobilePhone();
            if (id > 0)
            {
                result = context.Set<MobilePhone>().Include(x => x.Manufacturer).Include(x => x.Images).FirstOrDefault(x => x.Id == id);
            }
            return result;
        }
    }
}
