namespace SUS.MvcFramework
{
    using System.Diagnostics;
    using System.Text;
    using SUS.HTTP;

    public abstract class Controller
    {
        public HttpResponse View()
        {
            StackTrace stackTrace = new StackTrace();
            StackFrame callerFrame = stackTrace.GetFrame(1);

            string callerMethodName = callerFrame.GetMethod().Name;
            string callerClass = this.GetType().Name;
            string callerClassName = callerClass.Substring(0, callerClass.IndexOf("Controller"));

            var viewPath = $"Views/{callerClassName}/{callerMethodName}.html";

            var responseHTML = File.ReadAllText(viewPath);
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHTML);
            var response = new HttpResponse("text/html", responseBodyBytes);


            return response;
        }
    }
}
