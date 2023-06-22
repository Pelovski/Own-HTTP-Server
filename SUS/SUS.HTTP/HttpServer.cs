namespace SUS.HTTP
{
    using System.Net;
    using System.Net.Sockets;
    using System.Reflection.Metadata;
    using System.Text;

    public class HttpServer : IHttpServer
    {
        private const int BufferSize = 4096;
        private const string NewLine = "\r\n";

        IDictionary<string, Func<HttpRequest, HttpResponse>> 
            routeTable = new Dictionary<string, Func<HttpRequest, HttpResponse>>();
        public void AddRoute(string path, Func<HttpRequest, HttpResponse> action)
        {
            if (routeTable.ContainsKey(path))
            {
                routeTable[path] = action;
            }
            else
            {
                routeTable.Add(path, action);
            }
            
        }

        public async Task StartAsync(int port)
        {
            TcpListener tcpListener = new TcpListener(IPAddress.Loopback, port);
            tcpListener.Start();

            while (true)
            {
                TcpClient tcpClient = await tcpListener.AcceptTcpClientAsync();
                ProcessClient(tcpClient);
            }
        }

        private async Task ProcessClient(TcpClient tcpClient)
        {
            using (NetworkStream stream = tcpClient.GetStream())
            {
                List<byte> data = new List<byte>();

                byte[] buffer = new byte[BufferSize];
                int position = 0;

                while (true)
                {
                   int count =  await stream.ReadAsync(buffer, position, buffer.Length);

                    position += count;

                    if (count < buffer.Length)
                    {
                        var partialBuffer = new byte[count];
                        Array.Copy(buffer, partialBuffer, count);

                        data.AddRange(partialBuffer);
                        break;
                    }
                    else
                    {
                        data.AddRange(buffer);
                    }
                }
                
                var requestAsString = Encoding.UTF8.GetString(data.ToArray());

                Console.WriteLine(requestAsString);

                var responseHTML = "<h1>Welcome!</h1>";
                var responseBodyBytes = Encoding.UTF8.GetBytes(responseHTML);

                var responeHTTP = "HTTP/1.1 200 OK" + NewLine +
                                   "Server: SUS Server 1.0" + NewLine +
                                   "Content-Type: text/html" + NewLine +
                                   "Content-Lenght: " + responseBodyBytes.Length + NewLine
                                   + NewLine;

                var responseHeadersBytes = Encoding.UTF8.GetBytes(responeHTTP);

                await stream.WriteAsync(responseHeadersBytes, 0, responseHeadersBytes.Length);
                await stream.WriteAsync(responseBodyBytes, 0, responseBodyBytes.Length);

            }

            tcpClient.Close();

        }
    }
}
