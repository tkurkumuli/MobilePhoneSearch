using DataLayer.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataLayer
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<MobilePhone> MobilePhones { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Manufacturer>().HasData(
                new Manufacturer
                {
                    ManufacturerId = 1,
                    ManufacturerName = "Samsung",

                },
                new Manufacturer
                {
                    ManufacturerId = 2,
                    ManufacturerName = "Apple",

                },
                new Manufacturer
                {
                    ManufacturerId = 3,
                    ManufacturerName = "Huawei",

                },
                new Manufacturer
                {
                    ManufacturerId = 4,
                    ManufacturerName = "Xiaomi",
                }
                );
            modelBuilder.Entity<MobilePhone>().HasData(
                new MobilePhone
                {
                    Id = 1,
                    ManufacturerId = 1,
                    Memory = "16 GB",
                    Name = "Samsung Galaxy Edge",
                    OperatingSystem = "Android 10.0",
                    Price = 700,
                    Processor = "Octa-core",
                    Resolution = "720 x 1560 pixels",
                    ScreeenSize = 7,
                    Size = "146.3 x 70.9 x 8.3 mm",
                    Video = "https://www.youtube.com/watch?v=jZSDYEz6DYU",
                    //Image = "https://img.zoommer.ge/zoommer-images/thumbs/0110804_samsung-galaxy-a01-2gb-ram-16gb-lte-a015fd-black_550.png",
                    Weight = 120
                },
                new MobilePhone
                {
                    Id = 2,
                    ManufacturerId = 1,
                    Memory = "",
                    Name = "Samsung A",
                    OperatingSystem = "Android 10.0",
                    Price = 800,
                    Processor = "Octa-core",
                    Resolution = "720 x 1560 pixels",
                    ScreeenSize = 8,
                    Size = "146.3 x 70.9 x 8.3 mm",
                    Video = "https://www.youtube.com/watch?v=pQ8G57O6Ecc",
                   // Image = "https://img.zoommer.ge/zoommer-images/thumbs/0103604_huawei-p-smart-z-4gb-ram-64gb-lte-black_220.png",
                    Weight = 150
                },
                new MobilePhone
                {
                    Id = 3,
                    ManufacturerId = 2,
                    Memory = "",
                    Name = "Iphone 11",
                    OperatingSystem = "Android 10.0",
                    Price = 500,
                    Processor = "Octa-core",
                    Resolution = "720 x 1560 pixels",
                    ScreeenSize = 6,
                    Size = "146.3 x 70.9 x 8.3 mm",
                    Video = "https://www.youtube.com/watch?v=H4p6njjPV_o",
                   // Image = "https://img.zoommer.ge/zoommer-images/thumbs/0107238_apple-iphone-11-pro-single-sim-256gb-grey_220.png",
                    Weight = 200
                },
                new MobilePhone
                {
                    Id = 4,
                    ManufacturerId = 2,
                    Memory = "",
                    Name = "Iphone X",
                    OperatingSystem = "Android 10.0",
                    Price =900,
                    Processor = "Octa-core",
                    Resolution = "720 x 1560 pixels",
                    ScreeenSize = 5,
                    Size = "146.3 x 70.9 x 8.3 mm",
                    Video = "https://www.youtube.com/watch?v=6wvxyehsvFI",
                 //   Image = "https://img.zoommer.ge/zoommer-images/thumbs/0107688_xiaomi-redmi-note-8t-global-version-4gb-ram-64gb-lte-grey_220.png",
                    Weight = 180
                },
                new MobilePhone
                {
                    Id = 5,
                    ManufacturerId = 3,
                    Memory = "",
                    Name = "Huawei P9 lite",
                    OperatingSystem = "Android 10.0",
                    Price = 300,
                    Processor = "Octa-core",
                    Resolution = "720 x 1560 pixels",
                    ScreeenSize = 7,
                    Size = "146.3 x 70.9 x 8.3 mm",
                    Video = "https://www.youtube.com/watch?v=NqMk7eJlnxE",
                    //Image = "https://img.zoommer.ge/zoommer-images/thumbs/0107222_oneplus-7t-pro-dual-sim-8gb-ram-256gb-lte-haze-blue_220.png",
                    Weight = 170
                }
            );

        }

    }
}
