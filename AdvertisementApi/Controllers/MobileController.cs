using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Repositories;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using MobilePhonesearchApi.Models;

namespace MobilePhonesearchApi.Controllers
{

    [Route("api/[controller]/")]
    [ApiController]
    public class MobileController : ControllerBase
    {
        private readonly IMobileRepository _mobileRepository;


        public MobileController(IMobileRepository mobileRepository)
        {
            _mobileRepository = mobileRepository;
        }

        [HttpGet]
        public IActionResult Index(MobilePhoneSearchModel search)
        {
           // IEnumerable<MobilePhone> mobilePhones = _mobileRepository.();

            return View();
        }
    }
}