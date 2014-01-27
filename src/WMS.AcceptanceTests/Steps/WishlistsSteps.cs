using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using TechTalk.SpecFlow;
using WMS.AcceptanceTests.Helpers;
using WMS.DataStore;
using WMS.Tests.Common;
using WMS.Web.Controllers;
using WMS.Web.Models;

namespace WMS.AcceptanceTests.Steps
{
    [Binding]
    public class WishlistsSteps
    {
        private ActionResult _actionResult;
        private IEnumerable<Product> _givenProducts;

        [Given(@"the following products")]
        public void GivenTheFollowingProducts(Table tableOfProducts)
        {
            var db = DatabaseHelper.GetTestDatabase();
            db.DropCollection(typeof(Product).Name);
            _givenProducts = tableOfProducts.Rows.Select(ProductsHelper.CreateProductFrom);
            var respository = new Repository(db);
            respository.SaveAll(_givenProducts.ToList());
        }

        [When(@"I Add '(.*)' to my wishlist")]
        public void WhenIAddToMyWishlist(string productName)
        {
            var product = _givenProducts.First(x => x.Name == productName);
            var controller = new WishlistController();
            _actionResult = controller.AddToWishlist(product);
        }

        [Then(@"my wishlist should show")]
        public void ThenMyWishlistShouldShow(Table expectedProductsTable)
        {
            var viewResult = (ViewResult)_actionResult;
            var model = (Wishlist)viewResult.ViewData.Model;
            var expectedProducts = expectedProductsTable.Rows.Select(ProductsHelper.CreateProductFrom);
            model.Products.ShouldAllBeEquivalentTo(expectedProducts);
        }

    }
}
