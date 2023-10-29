using Mapster;
using RoyalUtility.Interface;

namespace Mapping
{
    public class RoyalMapping : IRoyalMapping
    {
        public TDestination Map<TDestination>(object source)
        {
            return source.Adapt<TDestination>();
        }

        public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
        {
            return source.Adapt(destination);
        }
    }
}