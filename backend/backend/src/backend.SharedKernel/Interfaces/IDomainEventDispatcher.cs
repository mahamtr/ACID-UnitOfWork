using System.Threading.Tasks;
using backend.SharedKernel;

namespace backend.SharedKernel.Interfaces
{
    public interface IDomainEventDispatcher
    {
        Task Dispatch(BaseDomainEvent domainEvent);
    }
}