using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Faberge.Web.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [StringLength(30, MinimumLength = 3)]
        public string Name { get; set; }
        [Range(0, float.MaxValue, ErrorMessage = "Please enter valid decimal number")]
        public decimal Price { get; set; }
        [StringLength(300, MinimumLength = 3)]
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string ImgSrc { get; set; }

        public int CatalogId { get; set; }
        public CatalogModel Catalog { get; set; }
    }
}
