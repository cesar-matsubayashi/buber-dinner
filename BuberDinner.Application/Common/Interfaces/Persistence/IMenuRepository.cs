using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Application.Common.Interfaces.Persistence
{
    public interface IMenuRepository
    {
        Task AddAsync(Menu menu);
        Task DeleteAsync(MenuId id);
        Task<Menu> GetAsync (MenuId id);
        Task<List<Menu>> GetAllAsync(HostId hostId);
        Task<List<MenuId>> GetAllMenuIdsByHostId(HostId hostId);
        Task UpdateAsync (Menu menu);
    }
}
