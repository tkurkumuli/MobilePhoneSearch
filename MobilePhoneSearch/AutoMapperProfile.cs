using AutoMapper;
using BusinessLayer.ServiceModels;
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
            CreateMap<MobilePhoneDetailsResponseModel, MobilePhoneDetailViewModel>().ReverseMap();
        }
    }
}
