using BusinessLayer.Implementations;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLayer
{
    public class DataManager : IDataManager
    {
        private readonly DataContext context;
        public MobileService Mobilephones { get; private set; }
        public ManufacturerService Manufacturers { get; private set; }


        public DataManager (DataContext context)
        {
            this.context = context;
            this.Mobilephones = new MobileService(this.context);
            this.Manufacturers = new ManufacturerService(this.context);
        }
        public void Dispose() => this.context.Dispose();
    }
}
