namespace MyFirstMvcApp.Controllers
{
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System.Text;

    public class HomeController : Controller
    {
         public HttpResponse Index(HttpRequest request)
        {
            var responseHTML = "<h1>Welcome!</h1>" +
                                        request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;

            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHTML);

            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

         public HttpResponse About(HttpRequest request)
        {
            var responseHTML = "<h1>About...!</h1>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHTML);
            var response = new HttpResponse("text/html", responseBodyBytes);


            return response;
        }
    }
}
