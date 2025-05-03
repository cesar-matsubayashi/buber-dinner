using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public class MenuRepository : IMenuRepository
    {
        private readonly BuberDinnerDbContext _dbContext;

        public MenuRepository(BuberDinnerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Menu menu)
        {
            await _dbContext.AddAsync(menu);
            await _dbContext.SaveChangesAsync();
        }

        public Task DeleteAsync(MenuId id)
        {
            throw new NotImplementedException();
        }

        public Task<List<Menu>> FindAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Menu?> GetAsync(MenuId id)
        {
            return await _dbContext.Set<Menu>().FindAsync(id);
        }

        public Task UpdateAsync(Menu menu)
        {
            throw new NotImplementedException();
        }
    }
}
