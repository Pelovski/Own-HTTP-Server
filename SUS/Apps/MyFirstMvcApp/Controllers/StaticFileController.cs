namespace MyFirstMvcApp.Controllers
{
    using SUS.HTTP;
    using SUS.MvcFramework;

    public class StaticFileController : Controller
    {
         public HttpResponse Favicon(HttpRequest request)
        {
            return this.File("wwwroot/favicon.ico", "image/vnd.microsoft.icon");
        }
    }
}
