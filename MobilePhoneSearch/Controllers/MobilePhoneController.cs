using AutoMapper;
using BusinessLayer;
using BusinessLayer.Models.Shared;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobilePhoneSearch.Helpers;
using MobilePhoneSearch.Models.MobilePhones;
using System.Collections.Generic;
using System.Linq;

namespace MobilePhoneSearch.Controllers
{
    public class MobilePhoneController : Controller
    {
        private IDataManager manager;
        private readonly IMapper _mapper;

        public MobilePhoneController(IDataManager manager, IMapper mapper)
        {
             this.manager = manager;
              _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Index(MobilePhoneListViewModel model, PagingInfo paging)
        {
            var mobilephones = manager.Mobilephones.Get(model.Filter).AsQueryable();
            var manufacturers = Get();
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
            if (id > 0)
            {
                var details = manager.Mobilephones.GetMobilehoneDetails(id);
                if (details != null)
                {
                    var model = _mapper.Map<MobilePhoneDetailViewModel>(details);
                    return View(model);
                }
            }
            return View(new MobilePhoneDetailViewModel());
        }
        [HttpGet]
        public List<SelectListItem> Get()
        {
            var result = new List<SelectListItem>();
            var manufacturers = manager.Manufacturers.Get();
            foreach (var item in manufacturers)
            {
                result.Add(new SelectListItem { Text = item.ManufacturerName.ToString(), Value = item.ManufacturerId.ToString() });
            }
            return result;
        }
    }
}