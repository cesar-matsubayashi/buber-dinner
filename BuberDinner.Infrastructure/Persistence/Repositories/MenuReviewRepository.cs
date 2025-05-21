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

        public Task DeleteAsync(MenuReview menuReview)
        {
            throw new NotImplementedException();
        }

        public Task<List<MenuReview>> GetAllIdsByGuestId(GuestId menuId)
        {
            throw new NotImplementedException();
        }

        public Task<List<MenuReview>> GetAllIdsByMenuId(MenuId menuId)
        {
            throw new NotImplementedException();
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
