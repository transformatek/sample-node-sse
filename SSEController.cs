using Microsoft.AspNetCore.Mvc;

namespace SseSample.Controllers;

public class SSEController : Controller
{
    private readonly ILogger<HomeController> logger;

    public SSEController(ILogger<HomeController> logger)
    {
        this.logger = logger;
    }

    [Route("/sse")]
    public async Task ConnectSse()
    {
        Response.Headers.Add("Content-Type", "text/event-stream");
        Response.Headers.Add("Cache-Control", "no-cache");
        Response.Headers.Add("Connection", "keep-alive");
        while (true)
        {
            await Response.WriteAsync($"data: Controller at {DateTime.Now}\r\r");
            await Response.Body.FlushAsync();
            await Task.Delay(1000);
        }
    }
}
