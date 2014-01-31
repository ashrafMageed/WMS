using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using MongoDB.Driver;
using TechTalk.SpecFlow;
using WMS.DataStore;
using WMS.Tests.Common;
using WMS.Web.Controllers;
using WMS.Web.Models;

namespace WMS.AcceptanceTests.Steps
{
    [Binding]
    public class BrowseProductsSteps
    {
        private ActionResult _actionResult;
        private IEnumerable<Domain.Product> _givenProducts;
        private MongoDatabase _db;
        private IRepository _repository;

        [BeforeScenario]
        public void ScenarioSetup()
        {
            _db = DatabaseHelper.GetTestDatabase();
            _db.Drop();
        }

        [Given(@"I have the following products")]
        public void GivenIHaveTheFollowingProducts(Table tableOfProducts)
        {
            _givenProducts = tableOfProducts.Rows.Select(ProductsHelper.CreateDomainProductFrom);
            _repository = new Repository(_db);
            _repository.SaveAll(_givenProducts.ToList());
        }

        [When(@"I select '(.*)' product category")]
        public void WhenISelectProductCategory(string category)
        {
            var productsController = new ProductsController(_repository);
            _actionResult = productsController.GetProductsByCategory(category);
        }

        [Then(@"I should see")]
        public void ThenIShouldSee(Table expectedProductsTable)
        {
            var productsModel = (IEnumerable<Product>)((ViewResult)_actionResult).ViewData.Model;
            var expectedProducts = expectedProductsTable.Rows.Select(ProductsHelper.CreateProductFrom);
            productsModel.ShouldAllBeEquivalentTo(expectedProducts);
        }

        [AfterScenario]
        public void ScenarioCleanup()
        {
            _db.Drop();
        }

    }
}
