using AutoMapper;
using Faberge.BL.Models;
using Faberge.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faberge.BL.Services
{
    public interface ICatalogService : IGenericService<CatalogBL>
    {

    }

    public class CatalogService : GenericService<CatalogBL, Catalog>, ICatalogService
    {
        private readonly IMapper _mapper;

        public CatalogService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public override Catalog Map(CatalogBL model)
        {
            return _mapper.Map<Catalog>(model);
        }

        public override CatalogBL Map(Catalog model)
        {
            return _mapper.Map<CatalogBL>(model);
        }

        public override IEnumerable<Catalog> Map(IEnumerable<CatalogBL> models)
        {
            return _mapper.Map<IEnumerable<Catalog>>(models);
        }

        public override IEnumerable<CatalogBL> Map(IEnumerable<Catalog> models)
        {
            return _mapper.Map<IEnumerable<CatalogBL>>(models);
        }
    }
}
