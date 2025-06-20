using Dapr;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace BackeryOrderService.Controllers;

[ApiController]
public class OrderController : ControllerBase
{
    private static IList<JObject> Orders { get; } = new List<JObject>();
    
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
        var json = JObject.FromObject(order);
        Orders.Add(json);
        Console.WriteLine($"Order received: {json}");
    }
}