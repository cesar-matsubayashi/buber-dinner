using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Guest;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private readonly BuberDinnerDbContext _dbContext;

        public GuestRepository(BuberDinnerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Guest guest)
        {
            await _dbContext.AddAsync(guest);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guest guest)
        {
            _dbContext.Remove(guest);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Guest?> GetAsync(GuestId id)
        {
            return await _dbContext.Guests.FindAsync(id);
        }

        public async Task UpdateAsync(Guest guest)
        {
            _dbContext.Update(guest);
            await _dbContext.SaveChangesAsync();
        }
    }
}
