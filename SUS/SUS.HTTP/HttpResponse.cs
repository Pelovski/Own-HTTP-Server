using System.Text;

namespace SUS.HTTP
{
    public class HttpResponse
    {

        public HttpResponse(string contentType, byte[] body, HttpStatusCode statusCode = HttpStatusCode.Ok)
        {
            this.StatusCode = statusCode;
            this.Body= body;

            this.Headers = new List<Header>()
            {
                {new Header("Content-Type:", contentType) },
                {new Header("Content-Length ", body.Length.ToString()) },
            };
        }

        public override string ToString()
        {
            StringBuilder responseBuilder = new StringBuilder();

            responseBuilder.Append($"HTTP/1.1 / {(int)this.StatusCode} {this.StatusCode}+ {HttpConstants.NewLine}");

            foreach (Header header in this.Headers)
            {
                responseBuilder.Append(header.ToString() + HttpConstants.NewLine);
            }

            responseBuilder.Append(HttpConstants.NewLine);

            return responseBuilder.ToString();
        }
        public HttpStatusCode StatusCode { get; set; }

        public ICollection<Header> Headers { get; set; }

        public byte[] Body { get; set; }
    }
}
