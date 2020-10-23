using System.Threading.Tasks;
using backend.SharedKernel;

namespace backend.SharedKernel.Interfaces
{
    public interface IHandle<in T> where T : BaseDomainEvent
    {
        Task Handle(T domainEvent);
    }
}