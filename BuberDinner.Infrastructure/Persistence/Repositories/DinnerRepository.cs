using BuberDinner.Application.Common.Interfaces.Persistence;
using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Dinner.ValueObjects;

namespace BuberDinner.Infrastructure.Persistence.Repositories
{
    public class DinnerRepository : IDinnerRepository
    {
        private static List<Dinner> _dinners = new();

        public async Task AddAsync(Dinner dinner)
        {
            _dinners.Add(dinner);
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(DinnerId id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Dinner>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Dinner?> GetAsync(DinnerId id)
        {
            return _dinners.FirstOrDefault(d => d.Id == id);
        }

        public async Task UpdateAsync(Dinner dinner)
        {
            throw new NotImplementedException();
        }
    }
}
