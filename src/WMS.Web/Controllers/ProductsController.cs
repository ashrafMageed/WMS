using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using WMS.Common.Mappers;
using WMS.DataStore;
using WMS.Domain;

namespace WMS.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public ProductsController(IRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public ActionResult Index()
        {
            var products = _repository.GetAll<Product>();
            var productsToDisplay = _mapper.Map<IEnumerable<Models.Product>>(products);
            return View(productsToDisplay);
        }

//        [AcceptVerbs(HttpVerbs.Post)]
//        public ActionResult CreateProduct(Models.Product productModel)
//        {
//            var productToCreate = _mapper.Map<Models.Product>(productModel);
//            _repository.Save(productToCreate);
//
//            return RedirectToAction("Index");
//        }

        public ActionResult GetProductsByCategory(string category)
        {
            var productsByCategory = _repository.GetAll<Product>().Where(x => x.Category == category);
            var productModels = _mapper.Map<IEnumerable<Models.Product>>(productsByCategory);
            return View("Index", productModels);
        }

        public ActionResult GetProductsByPriceRange(decimal minimumPrice, decimal maximumPrice)
        {
            var productsByPriceRange = _repository.GetAll<Product>().Where(x => x.Price >= minimumPrice && x.Price <= maximumPrice);
            return View("Index", _mapper.Map<IEnumerable<Models.Product>>(productsByPriceRange));
        }
    }
}

