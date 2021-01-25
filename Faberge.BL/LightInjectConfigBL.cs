using LightInject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Faberge.DAL;
using Faberge.DAL.ApplicationDbContext;

namespace Faberge.BL
{
    public static class LightInjectConfigBL
    {
        public static ServiceContainer Configurate(ServiceContainer container)
        {
            container.Register<ApplicationContext>(new PerScopeLifetime());
            container.Register(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return container;
        }
    }
}
