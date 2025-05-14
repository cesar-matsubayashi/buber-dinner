using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Guest;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public class GuestRepository : IGuestRepository
    {
        private static List<Guest> _guests = new();
        public async Task AddAsync(Guest guest)
        {
            _guests.Add(guest);
            await Task.CompletedTask; 
        }

        public async Task DeleteAsync(Guest guest)
        {
            throw new NotImplementedException();
        }

        public async Task<Guest?> GetAsync(GuestId id)
        {
            await Task.CompletedTask;
            return _guests.FirstOrDefault(g => g.Id == id);
        }

        public async Task UpdateAsync(Guest guest)
        {
            var guestToRemove = _guests.Find(g => g.Id == guest.Id);

            if (guestToRemove is not null)
            {
                _guests.Remove(guestToRemove);
                _guests.Add(guest);
            }

        }
    }
}
