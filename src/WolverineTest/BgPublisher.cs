using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Wolverine;

namespace WolverineTest
{
    public class BgPublisher(IMessageBus messageBus, ILogger<BgPublisher> _logger) : BackgroundService
    {
        private readonly IMessageBus messageBus = messageBus ?? throw new ArgumentNullException(nameof(messageBus));
        private readonly ILogger<BgPublisher> logger = _logger ?? throw new ArgumentNullException(nameof(_logger));

        protected override async Task ExecuteAsync(CancellationToken ct)
        {
            while (!ct.IsCancellationRequested)
            {
                logger.LogInformation("Publishing FailedPayment events...");

                var random = new Random();

                var amount = random.Next(4, 1000);

                await messageBus.SendAsync(new FailedPayment(Guid.NewGuid(), amount));

                logger.LogInformation("Published FailedPayment event with Id: {Id} and Amount: {Amount}", Guid.NewGuid(), amount);

                logger.LogInformation("Waiting for 2 seconds before publishing the next event...");
                await Task.Delay(8000, ct);
            }
        }
    }
}
