using BusinessLayer.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public interface IDataManager : IDisposable
    {
        MobileService Mobilephones { get; }
        ManufacturerService Manufacturers { get; }
    }
}
