namespace MyFirstMvcApp.Controllers
{
    using SUS.HTTP;
    using SUS.MvcFramework;
    using System.Text;

    public class HomeController : Controller
    {
         public HttpResponse Index(HttpRequest request)
        {
            return this.View();
        }

         public HttpResponse About(HttpRequest request)
        {
            return View();
        }
    }
}
