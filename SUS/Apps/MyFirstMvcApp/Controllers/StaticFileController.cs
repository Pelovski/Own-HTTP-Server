namespace MyFirstMvcApp.Controllers
{
    using SUS.HTTP;

    public class StaticFileController
    {
         public HttpResponse Favicon(HttpRequest request)
        {
            var fileBytes = File.ReadAllBytes("wwwroot/favicon.ico");
            var response = new HttpResponse("image/vdn.microsoft.icon", fileBytes);

            return response;
        }
    }
}
