using AutoMapper;
using Faberge.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faberge.BL
{
    public class AutoMapperProfileBL : Profile
    {
        public AutoMapperProfileBL()
        {
            CreateMap<Product, ProductBL>().ReverseMap();
            CreateMap<Catalog, CatalogBL>().ReverseMap();
            CreateMap<Order, OrderBL>().ReverseMap();
        }
    }
}
