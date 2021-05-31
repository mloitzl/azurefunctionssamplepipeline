using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using SendGrid.Helpers.Mail;
using mloitzl.demos.functionpipeline.Model;

namespace mloitzl.demos.functionpipeline.Services
{
    public static class DeliverLicense
    {
        [FunctionName("DeliverLicense")]
        public static async void Run(
            [QueueTrigger("licences")] License license,
            [SendGrid(ApiKey = "SendGridApiKey")] IAsyncCollector<SendGridMessage> messageCollector,
            ILogger log)
        {
            // Create a new Message
            var message = new SendGridMessage();

            // send to License Owner
            message.AddTo(license.IsssuedTo);
            
            message.AddContent("text/html", $"<pre>{license.LicenseData}</pre>");
            message.SetFrom(new EmailAddress("<SendGrid Sender>"));
            message.SetSubject($"Here is your license '{license.Id}'");

            // send the message
            await messageCollector.AddAsync(message);
        }
    }
}
