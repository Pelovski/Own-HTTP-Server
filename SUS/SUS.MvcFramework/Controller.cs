namespace SUS.MvcFramework
{
    using System.Diagnostics;
    using System.Runtime.CompilerServices;
    using System.Text;
    using SUS.HTTP;

    public abstract class Controller
    {
        public HttpResponse View([CallerMemberName] string callerMethodName = null)
        {
            var layout = System.IO.File.ReadAllText("Views/Shared/_Layout.html");
            string callerClassName = this.GetType().Name.Replace("Controller", string.Empty);

            var viewPath = $"Views/{callerClassName}/{callerMethodName}.html";

            var viewContent = System.IO.File.ReadAllText(viewPath);
            var responseHtml = layout.Replace("@RenderBody()", viewContent);
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHtml);
            var response = new HttpResponse("text/html", responseBodyBytes);


            return response;
        }

        public HttpResponse File(string filePath, string contentType)
        {

            var fileBytes = System.IO.File.ReadAllBytes("wwwroot/favicon.ico");
            var response = new HttpResponse("image/vdn.microsoft.icon", fileBytes);

            return response;

        }
    }
}
