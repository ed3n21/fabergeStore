using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faberge.Web.Models
{
    public class CatalogModel
    {
        [Required]
        public int Id { get; set; }
        [Required]
        [StringLength(40,MinimumLength = 3)]
        public string Name { get; set; }
    }
}
