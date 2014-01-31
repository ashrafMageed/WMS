using System.Collections.Generic;
using System.Linq;
using AutoMapper;

namespace WMS.Common.Mappers
{
    public class AutoMapperMapper : IMapper
    {
        public AutoMapperMapper(IEnumerable<Profile> profiles)
        {
            Mapper.Initialize(cfg => profiles.ToList().ForEach(cfg.AddProfile));
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

}
