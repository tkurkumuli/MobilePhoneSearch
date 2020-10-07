using BusinessLayer.Repositories.Implementations;
using DataLayer;

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
            Mobilephones = new MobileService(this.context);
            Manufacturers = new ManufacturerService(this.context);
        }
        public void Dispose() => this.context.Dispose();

        public void Commit()
        {
            context.SaveChanges();
        }
    }
}
