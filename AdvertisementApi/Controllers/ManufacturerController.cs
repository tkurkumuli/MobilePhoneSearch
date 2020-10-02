using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Repositories;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;

namespace MobilePhonesearchApi.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class ManufacturerController : ControllerBase
    {
        private readonly IManufacturerRepository<Manufacturer> _manufacturerRepository;

        public ManufacturerController(IManufacturerRepository<Manufacturer> manufacturerRepository)
        {
            _manufacturerRepository = manufacturerRepository;
        }

        // GET api/Manufacturer
        [HttpGet]
        public ActionResult Get()
        {
            IEnumerable<Manufacturer> manufacturers = _manufacturerRepository.Get();

            return Ok(manufacturers);
        }
    }
}