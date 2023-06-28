using System.Text;
using MyFirstMvcApp.Controllers;
using SUS.HTTP;
using SUS.MvcFramework;

class Program
{
     static async Task Main(string[] args)
    {

        List<Route> routeTable = new List<Route>();

        routeTable.Add(new Route("/", new HomeController().Index));
        routeTable.Add(new Route("/about", new HomeController().About));
        routeTable.Add(new Route("/cards/add", new CarsController().Add));
        routeTable.Add(new Route("/cards/all", new CarsController().All));
        routeTable.Add(new Route("/users/login", new UsersController().Login));
        routeTable.Add(new Route("/users/register", new UsersController().Register));
        routeTable.Add(new Route("/cards/collection", new CarsController().Collection));

        await Host.CreateHostAsync(routeTable);
    }

}