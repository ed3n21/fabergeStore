using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faberge.DAL.Models
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DeliveryDate { get; set; }

        // TODO
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }
}
