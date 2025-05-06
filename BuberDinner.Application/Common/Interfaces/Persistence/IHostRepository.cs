using BuberDinner.Domain.Host;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Application.Common.Interfaces.Persistence
{
    public interface IHostRepository
    {
        Task AddAsync(Host menu);
        Task DeleteAsync(HostId id);
        Task<Host> GetAsync (HostId id);
        Task UpdateAsync (Host menu);
    }
}
