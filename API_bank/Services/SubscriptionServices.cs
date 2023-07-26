using API_bank.Interfaces;

namespace API_bank.Services
{
    public class SubscriptionServices : ISubscriptionServices
    {
        public SubscriptionServices()
        {
            this.ContaAddedService = new ContaAddedService();
        }
        public ContaAddedService ContaAddedService { get; }
    }
}
