using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using TechTalk.SpecFlow;
using WMS.DataStore;
using WMS.Web.Controllers;
using WMS.Web.Models;
using WatiN.Core;
using Table = TechTalk.SpecFlow.Table;
using TableRow = TechTalk.SpecFlow.TableRow;

namespace WMS.UITests.Steps
{
    [Binding]
    public class ProductsSteps
    {
        private IE _ie;
        private IList<Product> _givenProducts;

        [Given(@"I have the following products")]
        public void GivenIHaveTheFollowingProducts(Table tableOfProducts)
        {
            _givenProducts = tableOfProducts.Rows.Select(CreateProductFrom).ToList();

            var db = Bootstrapper.Initialise();
            db.Drop();
            var respository = new Repository(db);
            var controller = new ProductsController(respository);
            _givenProducts.ToList().ForEach(controller.CreateProduct);
        }

        [When(@"I navigate to the products page")]
        public void WhenINavigateToTheProductsPage()
        {
            _ie = new IE("http://localhost:62612/Products");
        }
        
        [Then(@"I should see all products")]
        public void ThenIShouldSeeAllProducts()
        {
            var products = _ie.Elements.Filter(Find.ByClass("product"));
            products.Should().HaveCount(3);
            products[0].InnerHtml.Should().Contain(_givenProducts[0].Name);
            products[1].InnerHtml.Should().Contain(_givenProducts[1].Name);
            products[2].InnerHtml.Should().Contain(_givenProducts[2].Name);
        }

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

