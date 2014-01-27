using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;
using WMS.Web.Models;

namespace WMS.AcceptanceTests.Helpers
{
    public static class ProductsHelper
    {
        public static Product CreateProductFrom(TableRow productRow)
        {
            return new Product
            {
                Id = int.Parse(productRow["Id"]),
                Name = productRow["Name"],
                Description = productRow["Description"],
                Price = decimal.Parse(productRow["Price"])
            };
        } 
    }
}
