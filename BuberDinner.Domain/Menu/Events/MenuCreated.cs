using BuberDinner.Domain.Common.Models;

namespace BuberDinner.Domain.Menu.Events
{
    public class MenuCreated(Menu menu) : IDomainEvent;
}
