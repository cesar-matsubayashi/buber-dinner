using BuberDinner.Domain.Guest;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Application.Common.Interfaces.Persistence
{
    public interface IGuestRepository
    {
        Task AddAsync(Guest guest);
        Task DeleteAsync(Guest guest);
        Task<Guest?> GetAsync(GuestId id);
        Task UpdateAsync(Guest guest);
    }
}
