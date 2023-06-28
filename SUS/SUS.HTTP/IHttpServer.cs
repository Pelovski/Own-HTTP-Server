namespace SUS.HTTP
{
    public interface IHttpServer
    {
        Task StartAsync(int port);
    }
}
