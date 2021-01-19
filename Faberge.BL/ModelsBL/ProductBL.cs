using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Faberge.DAL.Models
{
    public class ProductBL
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public string ImgSrc { get; set; }

        public int CatalogId { get; set; }
        public CatalogBL Catalog { get; set; }
    }
}
