using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Host.ValueObjects;
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

        public async Task DeleteAsync(MenuId id)
        {
            var menu = await _dbContext.Set<Menu>().FindAsync(id);

            if (menu is not null)
            {
                _dbContext.Remove(menu);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<Menu>> GetAllAsync(HostId hostId)
        {
            return await _dbContext.Set<Menu>()
                .Where(m =>  m.HostId == hostId)
                .ToListAsync();
        }

        public async Task<List<MenuId>> GetAllMenuIdsByHostId(HostId hostId)
        {
            return await _dbContext.Menus
                .Where(menu => menu.HostId == hostId)
                .Select(menu => menu.Id)
                .ToListAsync();
        }

        public async Task<Menu?> GetAsync(MenuId id)
        {
            return await _dbContext.Set<Menu>().FindAsync(id);
        }

        public async Task UpdateAsync(Menu menu)
        {
            _dbContext.Update(menu);
            await _dbContext.SaveChangesAsync();
        }
    }
}
