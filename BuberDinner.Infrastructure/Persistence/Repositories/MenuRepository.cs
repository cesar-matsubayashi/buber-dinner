﻿using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Menu;

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
    }
}
