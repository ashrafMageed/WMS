using MongoDB.Driver;
using TechTalk.SpecFlow;
using WMS.DataStore;
using WMS.Web.Models;

namespace WMS.Tests.Common
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

    public static class DatabaseHelper
    {
        public static MongoDatabase GetTestDatabase()
        {
            return Bootstrapper.Initialise("TestDB");
        }
    }

}
