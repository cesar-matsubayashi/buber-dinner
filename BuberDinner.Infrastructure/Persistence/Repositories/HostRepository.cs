using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Application.Menus.Queries.List;
using BuberDinner.Domain.Host;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public class HostRepository : IHostRepository
    {
        private static List<Host> _hosts = new();

        public Task AddAsync(Host host)
        {
            _hosts.Add(host);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(HostId id)
        {
            _hosts.RemoveAll(h => h.Id == id);
            return Task.CompletedTask;
        }

        public Task<Host> GetAsync(HostId id)
        {
            var host = _hosts.FirstOrDefault(h => h.Id == id);

            return Task.FromResult(host)!;
        }

        public Task UpdateAsync(Host host)
        {
            var updateHost = _hosts.FirstOrDefault(host => host.Id == host.Id);

            if(updateHost is not null)
            {
                updateHost.Update(
                    host.FirstName,
                    host.LastName,
                    host.ProfileImage);
            }

            return Task.CompletedTask;
        }
    }
}
