using MongoDB.Driver;
using TechTalk.SpecFlow;
using WMS.DataStore;
using WMS.Web.Models;

namespace WMS.Tests.Common
{
    public static class ProductsHelper
    {
        // need to manage IDs in MongoDB

        public static Product CreateProductFrom(TableRow productRow)
        {
            return new Product
            {
                Id = productRow.ContainsKey("Id") ? 9 : int.Parse(productRow["Id"]),
                Name = productRow["Name"],
                Description = productRow["Description"],
                Price = decimal.Parse(productRow["Price"]),
                Category = productRow["Category"]
            };
        }

        public static Domain.Product CreateDomainProductFrom(TableRow productRow)
        {
            return new Domain.Product
            {
                Id = productRow.ContainsKey("Id") ? 9 : int.Parse(productRow["Id"]),
                Name = productRow["Name"],
                Description = productRow["Description"],
                Price = decimal.Parse(productRow["Price"]),
                Category = productRow["Category"]
            };
        }

        public static Product MapToProductViewModel(Domain.Product product)
        {
            return new Product
            {
                Id = product.Id,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category
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
