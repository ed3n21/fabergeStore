using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faberge.BL.Models
{
    public class OrderBL
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime DeliveryDate { get; set; }

        // TODO
        public string UserId { get; set; }
        public ProductBL Product { get; set; }
        public int ProductId { get; set; }
    }
}
