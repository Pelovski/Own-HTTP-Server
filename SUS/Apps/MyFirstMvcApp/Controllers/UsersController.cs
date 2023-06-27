namespace MyFirstMvcApp.Controllers
{
    using SUS.HTTP;
    using System.Text;

    public class UsersController
    {
         public HttpResponse Login(HttpRequest request)
        {
            var responseHTML = "<h1>Login...!</h1>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHTML);
            var response = new HttpResponse("text/html", responseBodyBytes);


            return response;
        }

        public HttpResponse Register(HttpRequest request)
        {
            var responseHTML = "<h1>Register...!</h1>";
            var responseBodyBytes = Encoding.UTF8.GetBytes(responseHTML);
            var response = new HttpResponse("text/html", responseBodyBytes);


            return response;
        }
    }
}
