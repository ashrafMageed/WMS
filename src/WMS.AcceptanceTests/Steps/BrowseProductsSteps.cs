using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
using FluentAssertions;
using MongoDB.Driver;
using TechTalk.SpecFlow;
using WMS.Common.Mappers;
using WMS.DataStore;
using WMS.Tests.Common;
using WMS.Web.Controllers;
using WMS.Web.Mappers;
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
            var productsController = new ProductsController(_repository, new AutoMapperMapper(new List<Profile>{new ProductModelMapperProfile()}));
            _actionResult = productsController.GetProductsByCategory(category);
        }

        [Then(@"I should see")]
        public void ThenIShouldSee(Table expectedProductsTable)
        {
            var productsModel = (IEnumerable<Product>)((ViewResult)_actionResult).ViewData.Model;
            var expectedProducts = expectedProductsTable.Rows.Select(ProductsHelper.CreateProductFrom);
            productsModel.ShouldAllBeEquivalentTo(expectedProducts);
        }

        [When(@"I filter products by a price range from '(.*)' to '(.*)'")]
        public void WhenIFilterProductsByAPriceRangeFromTo(decimal minimumPrice, decimal maximumPrice)
        {
            var productsController = new ProductsController(_repository, new AutoMapperMapper(new List<Profile> { new ProductModelMapperProfile() }));
            _actionResult = productsController.GetProductsByPriceRange(minimumPrice, maximumPrice);
        }


        [AfterScenario]
        public void ScenarioCleanup()
        {
            _db.Drop();
        }

    }
}
