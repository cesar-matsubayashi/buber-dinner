using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Dinner.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public class DinnerRepository : IDinnerRepository
    {
        private readonly BuberDinnerDbContext _dbContext;

        public DinnerRepository(BuberDinnerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Dinner dinner)
        {
            await _dbContext.AddAsync(dinner);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Dinner dinner)
        {
            _dbContext.Remove(dinner);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Dinner>> GetAllAsync()
        {
            return await _dbContext.Dinners.ToListAsync();
        }

        public async Task<Dinner?> GetAsync(DinnerId id)
        {
            return await _dbContext.Dinners.FindAsync(id);
        }

        public async Task UpdateAsync(Dinner dinner)
        {
            _dbContext.Update(dinner);
            await _dbContext.SaveChangesAsync();
        }
    }
}
