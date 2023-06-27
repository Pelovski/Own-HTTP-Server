namespace MyFirstMvcApp.Controllers
{
    using SUS.HTTP;
    using System.Text;

    public class HomeController
    {
         HttpResponse Index(HttpRequest request)
        {
            var responseHTML = "<h1>Welcome!</h1>" +
                                        request.Headers.FirstOrDefault(x => x.Name == "User-Agent")?.Value;

            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHTML);

            var response = new HttpResponse("text/html", responseBodyBytes);

            return response;
        }

         HttpResponse About(HttpRequest request)
        {
            var responseHTML = "<h1>About...!</h1>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHTML);
            var response = new HttpResponse("text/html", responseBodyBytes);


            return response;
        }
    }
}
