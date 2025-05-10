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
            var dinner = _dinners.FirstOrDefault(d => d.Id == id);

            if (dinner is not null)
            {
                _dinners.Remove(dinner);
            }
            await Task.CompletedTask;
        }

        public async Task<List<Dinner>> GetAllAsync()
        {
            return _dinners;
        }

        public async Task<Dinner?> GetAsync(DinnerId id)
        {
            return _dinners.FirstOrDefault(d => d.Id == id);
        }

        public async Task UpdateAsync(Dinner updatedDinner)
        {
            var dinner = _dinners.FirstOrDefault(d => d.Id == updatedDinner.Id);

            if (dinner is not null)
            {
                _dinners.Remove(dinner);
                _dinners.Add(updatedDinner);
            }
        }
    }
}
