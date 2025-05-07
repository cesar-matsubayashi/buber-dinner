using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Host;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public class HostRepository : IHostRepository
    {
        private readonly BuberDinnerDbContext _dbContext;

        public HostRepository(BuberDinnerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Host host)
        {
            await _dbContext.AddAsync(host);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(HostId id)
        {
            var host = await _dbContext.Hosts.FindAsync(id);

            if (host is not null)
            {
                _dbContext.Remove(host);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<Host?> GetAsync(HostId id)
        {
            return await _dbContext.Hosts.FindAsync(id);
        }

        public async Task UpdateAsync(Host host)
        {
            _dbContext.Update(host);
            await _dbContext.SaveChangesAsync();
        }
    }
}
