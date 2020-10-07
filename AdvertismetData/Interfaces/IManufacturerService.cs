using DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer.Interfaces
{
    public interface IManufacturerService
    {
        IEnumerable<Manufacturer> GetManufacturers();
    }
}
