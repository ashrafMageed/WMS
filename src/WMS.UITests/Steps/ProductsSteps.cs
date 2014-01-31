using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using MongoDB.Driver;
using TechTalk.SpecFlow;
using WMS.DataStore;
using WMS.Tests.Common;
using WMS.Web.Controllers;
using WMS.Web.Models;
using WatiN.Core;
using Table = TechTalk.SpecFlow.Table;

namespace WMS.UITests.Steps
{
    [Binding]
    public class ProductsSteps
    {
        private IE _ie;
        private IList<Product> _givenProducts;
        private MongoDatabase _db;
        private const string BASE_URL = "http://localhost:62612/{0}";

        [BeforeScenario]
        public void ScenarioSetup()
        {
            _db = DatabaseHelper.GetTestDatabase();
            _ie = new IE {AutoClose = true};
        }

        [Given(@"I have the following products")]
        public void GivenIHaveTheFollowingProducts(Table tableOfProducts)
        {
            _givenProducts = tableOfProducts.Rows.Select(ProductsHelper.CreateProductFrom).ToList();
            var productsToSave = new AutoMapperMapper().Map<IEnumerable<Product>, IEnumerable<Domain.Product>>(_givenProducts);
            var repository = new Repository(_db);
            repository.SaveAll(productsToSave.ToList());
        }

        [When(@"I navigate to the '(.*)' page")]
        public void WhenINavigateToThePage(string page)
        {
            _ie.GoTo(string.Format(BASE_URL, page));
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

        [AfterScenario]
        public void ScenarioCleanup()
        {
            _db.Drop();
            _ie.Close();
        }
    }
}

