﻿using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Menu.Entities
{
    public sealed class MenuSection : AggregateRoot<MenuSectionId>
    {
        private readonly List<MenuItem> _items = new();
        public string Name { get; private set; }
        public string Description { get; private set; }

        public IReadOnlyList<MenuItem> Items => _items.AsReadOnly();   

        private MenuSection(
            MenuSectionId menuSectionId, 
            string name, 
            string description,
            List<MenuItem> items)
            : base(menuSectionId)
        {
            Name = name;
            Description = description;
            _items = items;
        }

        public static MenuSection Create(
            string name, 
            string description,
            List<MenuItem> items)
        {
            return new(
                MenuSectionId.CreateUnique(), 
                name, 
                description,
                items);
        }

#pragma warning disable CS8618
        private MenuSection() { }
#pragma warning disable CS8618
    }
}
