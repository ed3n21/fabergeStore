using AutoMapper;
using Faberge.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faberge.BL.Services
{
    public class ProductService : GenericService<ProductBL, Product>
    {
        private readonly IMapper _mapper;

        public ProductService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public override Product Map(ProductBL model)
        {
            return _mapper.Map<Product>(model);
        }

        public override ProductBL Map(Product model)
        {
            return _mapper.Map<ProductBL>(model);
        }

        public override IEnumerable<Product> Map(IEnumerable<ProductBL> models)
        {
            return _mapper.Map<IEnumerable<Product>>(models);
        }

        public override IEnumerable<ProductBL> Map(IEnumerable<Product> models)
        {
            return _mapper.Map<IEnumerable<ProductBL>>(models);
        }
    }
}
