using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using BusinessLayer.Models;
using BusinessLayer.Models.Shared;
using Microsoft.AspNetCore.Mvc;
using MobilePhoneSearch.Helpers;
using MobilePhoneSearch.Models.MobilePhones;
using AutoMapper;
using DataLayer.Models;

namespace MobilePhoneSearch.Controllers
{
    public class MobilePhoneController : Controller
    {
        private readonly IMobileService _mobileService;
        private readonly IMapper _mapper;

        public MobilePhoneController(IMobileService mobileService, IMapper mapper)
        {
            _mobileService = mobileService;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult Index(MobilePhoneListViewModel model, PagingInfo paging)
        {
            var mobilephones = _mobileService.GetMobilePhones(model.Filter);
            var manufacturers = _mobileService.GetManufacturers();
            ViewBag.Manufacturers = manufacturers;
            var paged = new PaginatedList<MobilePhone>(mobilephones, paging);
            paging.SearchModel = model;
            return View(new BaseSearchModel<MobilePhoneListViewModel, PaginatedList<MobilePhone>>()
            {
                Search = model,
                DataModel = paged,
            });
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            if (id > 0 )
            {
                var details = _mobileService.GetMobilehoneDetails(id);
                if (details != null)
                {
                    var model = _mapper.Map<MobilePhoneDetailViewModel>(details);
                    return View(model);
                }
            }
            return View(new MobilePhoneDetailViewModel());
        }
    }
}