﻿using System.Linq;
using System.Web.Mvc;
using WMS.DataStore;
using WMS.Domain;

namespace WMS.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IRepository _repository;

        public ProductsController()
        {
            var db = Bootstrapper.Initialise("WMS");
            _repository = new Repository(db);
        }

        public ProductsController(IRepository repository)
        {
            _repository = repository;
        }

        public ActionResult Index()
        {
            var products = _repository.GetAll<Product>();
            var productsToDisplay = products.Select(MapToProductModel);
            return View(productsToDisplay);
        }

        public void CreateProduct(Models.Product productModel)
        {
            var productToCreate = MapToProduct(productModel);
            _repository.Save(productToCreate);
        }

        public static Product MapToProduct(Models.Product productModel)
        {
            return new Product
            {
                Id = productModel.Id,
                Description = productModel.Description,
                Name = productModel.Name,
                Price = productModel.Price,
                Category = productModel.Category
            };
        }

        public static Models.Product MapToProductModel(Product product)
        {
            return new Models.Product
            {
                Id = product.Id,
                Description = product.Description,
                Name = product.Name,
                Price = product.Price,
                Category = product.Category
            };
        }

        public ActionResult GetProductsByCategory(string category)
        {
            var productsByCategory = _repository.GetAll<Product>().Where(x => x.Category == category);
            var productModels = productsByCategory.Select(MapToProductModel);
            return View("Index", productModels);
        }
    }
}

