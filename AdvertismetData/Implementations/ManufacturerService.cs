using BusinessLayer.Interfaces;
using DataLayer;
using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BusinessLayer.Implementations
{
    public class ManufacturerService: IManufacturerService
    {
        readonly DataContext _context;
        public ManufacturerService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Manufacturer> Get()
        {
            return _context.Manufacturers.ToList();
        }
    }
}
