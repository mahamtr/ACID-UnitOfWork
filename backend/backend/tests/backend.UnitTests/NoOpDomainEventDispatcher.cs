using System.Threading.Tasks;
using backend.SharedKernel.Interfaces;
using backend.SharedKernel;

namespace backend.UnitTests
{
    public class NoOpDomainEventDispatcher : IDomainEventDispatcher
    {
        public Task Dispatch(BaseDomainEvent domainEvent)
        {
            return Task.CompletedTask;
        }
    }
}
