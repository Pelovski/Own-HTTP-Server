namespace SUS.MvcFramework
{
    using System.Text;
    using SUS.HTTP;

    public abstract class Controller
    {
        public HttpResponse View(string viewPath)
        {
            var responseHTML = File.ReadAllText(viewPath);
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHTML);
            var response = new HttpResponse("text/html", responseBodyBytes);


            return response;
        }
    }
}
