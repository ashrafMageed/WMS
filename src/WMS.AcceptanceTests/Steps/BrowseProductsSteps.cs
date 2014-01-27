using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using TechTalk.SpecFlow;
using WMS.AcceptanceTests.Helpers;
using WMS.Web.Controllers;
using WMS.Web.Models;

namespace WMS.AcceptanceTests.Steps
{
    [Binding]
    public class BrowseProductsSteps
    {
        private ActionResult _actionResult;
        private IEnumerable<Product> _givenProducts;

        [Given(@"I have the following products")]
        public void GivenIHaveTheFollowingProducts(Table tableOfProducts)
        {
            _givenProducts = tableOfProducts.Rows.Select(ProductsHelper.CreateProductFrom);
            // Create DB
            // Add to DB
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
            var productsModel = (List<Product>)((ViewResult) _actionResult).ViewData.Model;
            productsModel.ShouldAllBeEquivalentTo(_givenProducts);
        }
    }
}
