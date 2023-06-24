using System.Text;
using SUS.HTTP;

 class Program
{
     static async Task Main(string[] args)
    {
        IHttpServer server = new HttpServer();

       

        server.AddRoute("/", HomePage);
        server.AddRoute("/about", About);
        server.AddRoute("/users/login", Login);
        server.AddRoute("/favicon.ico", Favicon);

        await server.StartAsync(80);
    }

    static HttpResponse Favicon(HttpRequest request)
    {
        var fileBytes = File.ReadAllBytes("wwwroot/favicon.ico");
        var response = new HttpResponse("image/vdn.microsoft.icon", fileBytes);

        return response;
    }

    static HttpResponse HomePage(HttpRequest request)
    {
        var responseHTML = "<h1>Welcome!</h1>" +
                                    request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;

        var responseBodyBytes = Encoding.UTF8.GetBytes(responseHTML);

        var response = new HttpResponse("text/html", responseBodyBytes);

        return response;
    }

    static HttpResponse About(HttpRequest request)
    {
        var responseHTML = "<h1>About...!</h1>";
        var responseBodyBytes = Encoding.UTF8.GetBytes(responseHTML);
        var response = new HttpResponse("text/html", responseBodyBytes);


        return response;
    }

    static HttpResponse Login(HttpRequest request)
    {
        var responseHTML = "<h1>Login...!</h1>";
        var responseBodyBytes = Encoding.UTF8.GetBytes(responseHTML);
        var response = new HttpResponse("text/html", responseBodyBytes);


        return response;
    }
}