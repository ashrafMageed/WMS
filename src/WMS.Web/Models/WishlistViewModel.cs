using System.Collections.Generic;

namespace WMS.Web.Models
{
    public class Wishlist
    {
        public IEnumerable<Product> Products { get; set; }
    }

    public class Product
    {
        public long Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal Price { get; set; }
    }
}