﻿using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuItem : AggregateRoot<MenuItemId>
    {
        public string Name { get; private set; }
        public string Description { get; private set; }
        
        public MenuItem(MenuItemId menuItemId, string name, string description) 
            : base(menuItemId)
        {
            Name = name;
            Description = description;
        }

        public static MenuItem Create(string name, string description)
        {
            return new(MenuItemId.CreateUnique(), name, description);
        }

#pragma warning disable CS8618
        private MenuItem() { }
#pragma warning disable CS8618
    }
}
