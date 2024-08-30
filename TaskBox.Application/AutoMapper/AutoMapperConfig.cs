using AutoMapper;
using AutoMapper.Internal;
using System.Linq.Expressions;

namespace TaskBox.Application.AutoMapper
{
    public static class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMappings()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AllowNullDestinationValues = true;
                cfg.AllowNullCollections = true;

                cfg.DisableConstructorMapping();

                cfg.Internal().ForAllMaps
                (
                    (mapType, mapperExpression) =>
                    {
                        mapperExpression.MaxDepth(1);
                    }
                );

                cfg.AddProfile(new DomainToDtoMappingProfile());
            });
        }

        public static IMappingExpression<TSource, TDestination> Ignore<TSource, TDestination>(
            this IMappingExpression<TSource, TDestination> map, Expression<Func<TDestination, object>> selector)
        {
            map.ForMember(selector, config => config.Ignore());
            return map;
        }
    }
}
