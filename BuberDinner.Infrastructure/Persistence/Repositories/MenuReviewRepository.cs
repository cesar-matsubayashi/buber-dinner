using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview;
using BuberDinner.Domain.MenuReview.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public class MenuReviewRepository : IMenuReviewRepository
    {
        private readonly BuberDinnerDbContext _dbContext;

        public MenuReviewRepository(BuberDinnerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(MenuReview menuReview)
        {
            await _dbContext.AddAsync(menuReview);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(MenuReview menuReview)
        {
            _dbContext.Remove(menuReview);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<MenuReview>> GetAllByGuestIdAsync(GuestId guestId)
        {
            return await _dbContext.MenuReviews
                .Where(m => m.GuestId == guestId)
                .ToListAsync();
        }

        public async Task<List<MenuReview>> GetAllByMenuIdAsync(MenuId menuId)
        {
            return await _dbContext.MenuReviews
                .Where(m => m.MenuId == menuId)
                .ToListAsync();
        }

        public async Task<MenuReview?> GetAsync(MenuReviewId id)
        {
            return await _dbContext.MenuReviews.FindAsync(id);
        }

        public async Task UpdateAsync(MenuReview menuReview)
        {
            _dbContext.Update(menuReview);
            await _dbContext.SaveChangesAsync();
        }
    }
}
