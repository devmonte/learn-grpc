using System.Threading.Tasks;
using Grpc.Core;
using Microsoft.Extensions.Logging;
using Notifier;

namespace NotifierService.Services
{
    public class NotifierService : Notifier.Notifier.NotifierBase
    {
        private readonly ILogger<NotifierService> _logger;

        public NotifierService(ILogger<NotifierService> logger)
        {
            _logger = logger;
        }

        public override Task<NotificationReply> Notify(NotificationRequest request, ServerCallContext context)
        {
            _logger.LogInformation($"Received request: {request.Id}  with content: {request.Content}");
            return Task.FromResult(new NotificationReply { Result = "Success" });
        }
    }
}
