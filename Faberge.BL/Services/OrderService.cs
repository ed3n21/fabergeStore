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
    public interface IOrderService : IGenericService<OrderBL>
    {

    }

    public class OrderService : GenericService<OrderBL, Order>, IOrderService
    {
        private readonly IMapper _mapper;

        public OrderService(IMapper mapper)
        {
            _mapper = mapper;
        }

        public override Order Map(OrderBL model)
        {
            return _mapper.Map<Order>(model);
        }

        public override OrderBL Map(Order model)
        {
            return _mapper.Map<OrderBL>(model);
        }

        public override IEnumerable<Order> Map(IEnumerable<OrderBL> models)
        {
            return _mapper.Map<IEnumerable<Order>>(models);
        }

        public override IEnumerable<OrderBL> Map(IEnumerable<Order> models)
        {
            return _mapper.Map<IEnumerable<OrderBL>>(models);
        }
    }
}
