using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using AutoMapper;
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

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult CreateProduct(Models.Product productModel)
        {
            var productToCreate = _mapper.Map<Models.Product>(productModel);
            _repository.Save(productToCreate);

            return RedirectToAction("Index");
        }

        public ActionResult GetProductsByCategory(string category)
        {
            var productsByCategory = _repository.GetAll<Product>().Where(x => x.Category == category);
            var productModels = _mapper.Map<IEnumerable<Models.Product>>(productsByCategory);
            return View("Index", productModels);
        }
    }

    public interface IMapper
    {
        TDestination Map<TSource, TDestination>(TSource source);
        TDestination Map<TDestination>(object data);
    }

    public class AutoMapperMapper : IMapper
    {
        public AutoMapperMapper()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<ProductModelMapper>());
        }

        public TDestination Map<TSource, TDestination>(TSource source)
        {
            return Mapper.Map<TSource, TDestination>(source);
        }

        public TDestination Map<TDestination>(object sourceData)
        {
            return Mapper.Map<TDestination>(sourceData);
        }
    }

    public class ProductModelMapper : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Product, Models.Product>();
            Mapper.CreateMap<Models.Product, Product>();
        }
    }
}

