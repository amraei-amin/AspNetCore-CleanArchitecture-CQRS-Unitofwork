namespace RoyalUtility.Interface
{
    public interface IRoyalMapping
    {
        TDestination Map<TDestination>(object source);
        TDestination Map<TSource, TDestination>(TSource source, TDestination destination);
    }
}