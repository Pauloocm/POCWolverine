using Microsoft.Extensions.Logging;

namespace WolverineTest
{
    public class FailedPaymentHandler(ILogger<FailedPaymentHandler> _logger)
    {
        private readonly ILogger<FailedPaymentHandler> logger = _logger;
        private List<FailedPayment> processedEvents = [];

        public void Handle(FailedPayment failedPayment)
        {
            decimal totalAmount = 0;

            logger.LogInformation("Handling FailedPayment event with Id: {Id} and Amount: {Amount}", failedPayment.Id, failedPayment.Amount);

            processedEvents.Add(failedPayment);

            totalAmount += failedPayment.Amount;

            logger.LogInformation("Total Amount of Failed Payments: {TotalAmount}", totalAmount);
        }
    }
}
