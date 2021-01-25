using System.Collections.Generic;
//using System.ComponentModel.Design;
using System.Reflection;
using AutoMapper;
using Faberge.BL;
using Faberge.BL.Services;
using LightInject;

namespace Faberge.Web.App_Start
{
    public static class LightInjectConfig
    {
        public static void Configurate()
        {
            var container = new ServiceContainer();
            container.RegisterControllers(Assembly.GetExecutingAssembly());

            container.EnablePerWebRequestScope();

            var config = new MapperConfiguration(cfg => cfg.AddProfiles(
                  new List<Profile>() { new AutoMapperProfileWeb(), new AutoMapperProfileBL() }));


            container.Register(c => config.CreateMapper());

            container = LightInjectConfigBL.Configurate(container);
            container.Register<IProductService, ProductService>();
            container.Register<ICatalogService, CatalogService>();
            container.Register<IOrderService, OrderService>();

            container.EnableMvc();
        }
    }
}