﻿using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.Entities;
using BuberDinner.Domain.Menu.Events;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;

namespace BuberDinner.Domain.Menu
{
    public sealed class Menu : AggregateRoot<MenuId>
    {
        private readonly List<MenuSection> _sections = new();
        private readonly List<DinnerId> _dinnerIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        public string Name { get; private set; }
        public string Description { get; private set; }
        public AverageRating AverageRating { get; private set; }

        public IReadOnlyList<MenuSection> Sections => _sections.AsReadOnly();
        public HostId HostId { get; private set; }
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds 
            => _menuReviewIds.AsReadOnly();
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private Menu(
            MenuId menuId, 
            HostId hostId, 
            string name, 
            string description, 
            AverageRating averageRating,
            List<MenuSection> sections)
            : base(menuId)
        {
            HostId = hostId;
            Name = name;
            Description = description;
            AverageRating = averageRating;
            _sections = sections;
            CreatedDateTime = DateTime.UtcNow;
            UpdatedDateTime = DateTime.UtcNow;
        }

        public static Menu Create(
            HostId hostId,
            string name,
            string description,
            List<MenuSection>? sections)
        {
            var menu = new Menu(
                MenuId.CreateUnique(),
                hostId,
                name, 
                description,
                AverageRating.CreateNew(),
                sections ?? new());

            menu.AddDomainEvent(new MenuCreated(menu));

            return menu;
        }

        public void Update(
            string name,
            string description,
            List<MenuSection>? sections)
        {
            Name = name;
            Description = description;
            
            _sections.Clear();
            _sections.AddRange(sections);

            UpdatedDateTime = DateTime.UtcNow;

            this.AddDomainEvent(new MenuUpdated(this));
        }

#pragma warning disable CS8618 
        private Menu() { }
#pragma warning restore CS8618 
    }
}
