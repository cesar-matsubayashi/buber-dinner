using BuberDinner.Domain.Bill;
using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Application.Common.Interfaces.Persistence
{
    public interface IBillRepository
    {
        Task AddAsync(Bill dinner);
        Task DeleteAsync(Bill dinner);
        Task<Bill?> GetAsync(BillId id);
        Task<List<Bill>> GetAllByGuestIdAsync(GuestId guestId);
        Task UpdateAsync(Bill dinner);
    }
}
