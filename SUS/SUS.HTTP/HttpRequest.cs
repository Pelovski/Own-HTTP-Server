namespace SUS.HTTP
{
    public class HttpRequest
    {
        public HttpRequest(string requestString)
        {

        }

        public string path { get; set; }

        public string Methode { get; set; }

        public List<Header> Headers { get; set; }

        public List<Cookie> Cookies { get; set; }

        public string Body { get; set; }
    }
}
