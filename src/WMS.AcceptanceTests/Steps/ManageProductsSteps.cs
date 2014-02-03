using System;
using System.Collections.Generic;
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
    public class ManageProductsSteps
    {
        private ActionResult _actionResult;
        private Product _product;
        private MongoDatabase _db;
        private IRepository _repository;

        [BeforeScenario]
        public void ScenarioSetup()
        {
            _db = DatabaseHelper.GetTestDatabase();
            _db.Drop();
        }

        [Given(@"the following product information")]
        public void GivenTheFollowingProductInformation(Table table)
        {
            _product = ProductsHelper.CreateProductFrom(table.Rows[0]);
        }

        [When(@"I create the product")]
        public void WhenICreateTheProduct()
        {
            var productsController = new ProductsController(_repository, new AutoMapperMapper(new List<Profile> { new ProductModelMapperProfile() }));
            _actionResult = productsController.CreateProduct(_product);
        }
        
        [Then(@"it should be added to the list of products")]
        public void ThenItShouldBeAddedToTheListOfProducts()
        {
            var productsModel = (IEnumerable<Product>)((ViewResult)_actionResult).ViewData.Model;
            productsModel.Should().Contain(x =>x.Name == _product.Name && x.Price == _product.Price);
        }

        [AfterScenario]
        public void ScenarioCleanup()
        {
            _db.Drop();
        }
    }
}
