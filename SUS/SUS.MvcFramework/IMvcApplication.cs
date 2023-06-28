namespace SUS.MvcFramework
{
    using SUS.HTTP;
    public interface IMvcApplication
    {
        void ConfigureServices();

        void Configure(List<Route> routeTable);
    }
}
