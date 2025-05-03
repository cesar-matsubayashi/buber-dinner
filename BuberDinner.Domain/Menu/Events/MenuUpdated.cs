using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.Events
{
    public class MenuUpdated(Menu menu) : IDomainEvent;
}
