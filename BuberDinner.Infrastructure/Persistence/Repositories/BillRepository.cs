using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Bill;
using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public class BillRepository : IBillRepository
    {
        private readonly BuberDinnerDbContext _dbContext;

        public BillRepository(BuberDinnerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Bill bill)
        {
            await _dbContext.AddAsync(bill);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Bill bill)
        {
            _dbContext.Remove(bill);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<Bill>> GetAllByGuestIdAsync(GuestId guestId)
        {
            return await _dbContext.Bills
                .Where(b => b.GuestId == guestId)
                .ToListAsync();
        }

        public async Task<Bill?> GetAsync(BillId id)
        {
            return await _dbContext.Bills.FindAsync(id);
        }

        public async Task UpdateAsync(Bill bill)
        {
            _dbContext.Update(bill);
            await _dbContext.SaveChangesAsync();
        }
    }
}
