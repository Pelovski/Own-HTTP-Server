using MyFirstMvcApp;
using SUS.MvcFramework;

public class Program
{
     static async Task Main(string[] args)
    {
        await Host.CreateHostAsync(new StartUp(), 80);
        var one = HttpMethod.Get;
    }

}