using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public class MenuReviewRepository : IMenuReviewRepository
    {
        private static List<MenuReview> _menuReviews = new();

        public async Task AddAsync(MenuReview menuReview)
        {
            _menuReviews.Add(menuReview);
        }

        public async Task DeleteAsync(MenuReview menuReview)
        {
            _menuReviews.Remove(menuReview);
        }

        public async Task<List<MenuReview>> GetAllByGuestIdAsync(GuestId guestId)
        {
            await Task.CompletedTask;
            return _menuReviews.Where(m => m.GuestId == guestId).ToList();
        }

        public async Task<List<MenuReview>> GetAllByMenuIdAsync(MenuId menuId)
        {
            await Task.CompletedTask;
            return _menuReviews.Where(m => m.MenuId == menuId).ToList();
        }

        public async Task<MenuReview?> GetAsync(MenuReviewId id)
        {
            return _menuReviews.First(m => m.Id == id);
        }

        public Task UpdateAsync(MenuReview menuReview)
        {
            throw new NotImplementedException();
        }
    }
}
