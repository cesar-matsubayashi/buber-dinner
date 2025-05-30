﻿using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Application.Common.Interfaces.Persistence
{
    public  interface IMenuReviewRepository
    {
        Task AddAsync(MenuReview menuReview);
        Task DeleteAsync(MenuReview menuReview);
        Task<MenuReview?> GetAsync(MenuReviewId id);
        Task<List<MenuReview>> GetAllByMenuIdAsync(MenuId menuId);
        Task<List<MenuReview>> GetAllByGuestIdAsync(GuestId guestId);
        Task UpdateAsync(MenuReview menuReview);
    }
}
