using AutoMapper;
using BusinessLayer.Models;
using DataLayer.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using MobilePhoneSearch.Models.MobilePhones;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MobilePhoneSearch
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<MobilePhone, MobilePhoneDetailViewModel>().ReverseMap();
        }
    }
}
