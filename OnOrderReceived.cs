using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using mloitzl.demos.functionpipeline.Model;

namespace mloitzl.demos.functionpipeline.Services
{
    public static class OnOrderReceived
    {
        [FunctionName("OnOrderReceived")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
            [Queue("orders")] IAsyncCollector<Order> orderQueue,
            ILogger log)
        {
            // Retrieve 'Order' from HttpRequest
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            var order = JsonConvert.DeserializeObject<Order>(requestBody);

            // Add 'Order' to the 'order' queue
            await orderQueue.AddAsync(order);

            string responseMessage = order != null
                ? $"Hello, {order.Email}. Received {order.OrderId}"
                : "Error occurred";

            return new OkObjectResult(responseMessage);
        }
    }
}