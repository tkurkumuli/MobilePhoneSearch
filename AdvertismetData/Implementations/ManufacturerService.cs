using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Implementations
{
    public class ManufacturerService : Repository<Manufacturer>
    {
        public ManufacturerService(DbContext context) : base(context) { }
        public override IEnumerable<Manufacturer> Get()
        {
            return context.Set<Manufacturer>();
        }

    }
}
