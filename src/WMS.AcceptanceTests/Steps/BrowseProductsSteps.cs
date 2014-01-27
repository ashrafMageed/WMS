using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using TechTalk.SpecFlow;
using WMS.AcceptanceTests.Helpers;
using WMS.DataStore;
using WMS.Web.Controllers;
using WMS.Web.Models;

namespace WMS.AcceptanceTests.Steps
{
    [Binding]
    public class BrowseProductsSteps
    {
        private ActionResult _actionResult;
        private IEnumerable<Domain.Product> _givenProducts;

        [Given(@"I have the following products")]
        public void GivenIHaveTheFollowingProducts(Table tableOfProducts)
        {
            var db = Bootstrapper.Initialise();
            db.Drop();
            _givenProducts = tableOfProducts.Rows.Select(ProductsHelper.CreateDomainProductFrom);
            var respository = new Repository(db);
            respository.SaveAll(_givenProducts.ToList());
        }
        
        [When(@"I view products")]
        public void WhenIViewProducts()
        {
            var productsController = new ProductsController();
            _actionResult = productsController.Index();
        }
        
        [Then(@"I should see all products")]
        public void ThenIShouldSeeAllProducts()
        {
            var productsModel = (IEnumerable<Product>)((ViewResult) _actionResult).ViewData.Model;
            var expectedProducts = _givenProducts.Select(ProductsHelper.MapToProductViewModel);
            productsModel.ShouldAllBeEquivalentTo(expectedProducts);
        }
    }
}
