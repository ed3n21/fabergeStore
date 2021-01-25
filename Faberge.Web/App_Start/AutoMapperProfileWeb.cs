using AutoMapper;
using Faberge.BL.Models;
using Faberge.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Faberge.Web.App_Start
{
    public class AutoMapperProfileWeb : Profile
    {
        public AutoMapperProfileWeb()
        {
            CreateMap<ProductBL, ProductModel>().ReverseMap();
            CreateMap<OrderBL, OrderModel>().ReverseMap();
            CreateMap<CatalogBL, CatalogModel>().ReverseMap();
        }
    }
}