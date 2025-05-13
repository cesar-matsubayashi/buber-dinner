using BuberDinner.Domain.Dinner;
using BuberDinner.Domain.Dinner.ValueObjects;

namespace BuberDinner.Application.Common.Interfaces.Persistence
{
    public interface IDinnerRepository
    {
        Task AddAsync(Dinner dinner);
        Task DeleteAsync(Dinner dinner);
        Task<Dinner?> GetAsync(DinnerId id);
        Task<List<Dinner>> GetAllAsync();
        Task UpdateAsync(Dinner dinner);
    }
}
