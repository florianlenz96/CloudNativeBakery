using System.Text.Json;
using Dapr;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BackeryOrderService.Controllers;

[ApiController]
public class OrderController : ControllerBase
{
    private static IList<string> Orders { get; } = new List<string>();
    
    [HttpGet("api/order")]
    public IActionResult GetOrder()
    {
        return this.Ok(Orders);
    }

    [Topic("orderpubsub", "ordercreated")]
    [HttpPost("topic/order-handler")]
    [ApiExplorerSettings(IgnoreApi = true)]
    public void CreateOrderHandler([FromBody] object order)
    {
        var json = JsonSerializer.Serialize(order);
        Orders.Add(json);
        Console.WriteLine($"Order received: {json}");
    }
}