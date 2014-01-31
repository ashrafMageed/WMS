using AutoMapper;
using WMS.Domain;

namespace WMS.Web.Mappers
{
    public class ProductModelMapperProfile : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<Product, Models.Product>();
            Mapper.CreateMap<Models.Product, Product>();
        }
    }
}