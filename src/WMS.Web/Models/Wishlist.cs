using System.Collections.Generic;

namespace WMS.Web.Models
{
    public class Wishlist
    {
        public IEnumerable<Product> Products { get; set; }
    }
}