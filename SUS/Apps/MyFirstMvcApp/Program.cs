using System.Text;
using MyFirstMvcApp.Controllers;
using SUS.HTTP;

 class Program
{
     static async Task Main(string[] args)
    {
        IHttpServer server = new HttpServer();

       

        server.AddRoute("/", new HomeController().Index);
        server.AddRoute("/about", new HomeController().About);
        server.AddRoute("/users/login", new UsersController().Login);
        server.AddRoute("/users/register", new UsersController().Register);
        server.AddRoute("/favicon.ico", new StaticFileController().Favicon);

        await server.StartAsync(80);
    }

}