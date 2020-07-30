namespace Gene.Runtime
{
    public static class IIoCModuleEx
    {
        public static T Use<T>(this IIoCComponent ioc)
        {
            return (T)ioc.Use(typeof(T));
        }
    }
}