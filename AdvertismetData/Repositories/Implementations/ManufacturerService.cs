using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace BusinessLayer.Repositories.Implementations
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
