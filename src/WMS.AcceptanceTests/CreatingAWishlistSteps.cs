using System;
using TechTalk.SpecFlow;
using WatiN.Core;

namespace WMS.AcceptanceTests
{
    [Binding]
    public class CreatingAWishlistSteps
    {
        private IE _ie;

        [Given(@"I am on the products page")]
        public void GivenIAmOnTheProductsPage()
        {
            _ie = new IE("http://localhost:62612/Products");

        }

        
        [When(@"I select a product")]
        public void WhenISelectAProduct()
        {
            _ie.Element()
        }
        
        [When(@"I Add it to my wishlist")]
        public void WhenIAddItToMyWishlist()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"it should be in my wishlist")]
        public void ThenItShouldBeInMyWishlist()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
