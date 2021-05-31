using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using mloitzl.demos.functionpipeline.Service;
using mloitzl.demos.functionpipeline.Model;
using Newtonsoft.Json;

namespace mloitzl.demos.functionpipeline.Services
{
    public class ProcessOrder
    {
        private readonly ILicenseGenerator _licenseGenerator;

        public ProcessOrder(ILicenseGenerator licenseGenerator)
        {
            _licenseGenerator = licenseGenerator;
        }

        [FunctionName("ProcessOrder")]
        public async void Run( 
            [QueueTrigger("orders")] string queueItem,
            [Table("licences")] IAsyncCollector<License> licenseTable,
            [Queue("licences")] IAsyncCollector<License> licenceQueue,
            ILogger log)
        {
            // get the 'Order' queue Item
            var order = JsonConvert.DeserializeObject<Order>(queueItem);

            // generate license
            var licence = _licenseGenerator.Generate(order.Email);

            // add licence to the table of active licenses
            await licenseTable.AddAsync(licence);

            // add licence to the queue for delivering it by e-mail
            await licenceQueue.AddAsync(licence);
        }
    }
}