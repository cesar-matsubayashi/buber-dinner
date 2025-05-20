using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Bill;
using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public class BillRepository : IBillRepository
    {
        private static List<Bill> _bills = new();

        public async Task AddAsync(Bill dinner)
        {
            _bills.Add(dinner);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Bill dinner)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Bill>> GetAllByGuestIdAsync(GuestId guestId)
        {
            return _bills.Where(b => b.GuestId == guestId).ToList();
        }

        public async Task<Bill?> GetAsync(BillId id)
        {
            return _bills.FirstOrDefault(b => b.Id == id);
        }

        public async Task UpdateAsync(Bill dinner)
        {
            throw new NotImplementedException();
        }
    }
}
