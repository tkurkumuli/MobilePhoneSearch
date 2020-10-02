using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer.Interfaces;
using BusinessLayer.ServiceModels;
using BusinessLayer.ServiceModels.Shared;
using Microsoft.AspNetCore.Mvc;
using MobilePhoneSearch.Helpers;
using MobilePhoneSearch.Models.MobilePhones;
using AutoMapper;

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
        public IActionResult Index(MobilePhoneListFilterViewModel filter, PagingInfo paging)
        {
            MobilePhoneListViewModel result = new MobilePhoneListViewModel();
            var mobilephones = _mobileService.GetMobilePhones(filter, paging);
            var manufacturers = _mobileService.GetManufacturers();
            ViewBag.Manufacturers = manufacturers;
            var paged = new PaginatedList<MobilePhoneModel>(mobilephones, paging);
            paging.SearchModel = filter;

            return View(new BaseSearchModel<MobilePhoneListFilterViewModel, PaginatedList<MobilePhoneModel>>()
            {
                Search = filter,
                DataModel = paged,
            });
        }

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