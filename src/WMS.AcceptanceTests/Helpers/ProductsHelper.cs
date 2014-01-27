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

        public static Domain.Product CreateDomainProductFrom(TableRow productRow)
        {
            return new Domain.Product
            {
                Id = int.Parse(productRow["Id"]),
                Name = productRow["Name"],
                Description = productRow["Description"],
                Price = decimal.Parse(productRow["Price"])
            };
        } 

        public static Product MapToProductViewModel(Domain.Product product)
        {
            return new Product
                {
                    Id = product.Id,
                    Description = product.Description,
                    Name = product.Name,
                    Price = product.Price
                };
        }
    }
}
