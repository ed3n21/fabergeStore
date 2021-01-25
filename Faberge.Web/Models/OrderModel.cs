using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faberge.Web.Models
{
    public class OrderModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }
        [Required]
        public DateTime DeliveryDate { get; set; }

        // TODO
        //public int ClientId { get; set; }
    }
}
