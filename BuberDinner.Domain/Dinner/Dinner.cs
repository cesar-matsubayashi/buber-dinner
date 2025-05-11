using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.Entities;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;

namespace BuberDinner.Domain.Dinner
{
    public sealed class Dinner : AggregateRoot<DinnerId>
    {
        private readonly List<Reservation> _reservations = new();

        public string Name { get; private set; }
        public string Description { get; private set; }
        public DateTime StartDateTime { get; private set; }
        public DateTime EndDateTime { get; private set; }
        public DateTime? StartedDateTime { get; private set; }
        public DateTime? EndedDateTime { get; private set; }
        public DinnerStatus Status { get; private set; }
        public bool IsPublic { get; private set; }
        public int MaxGuests { get; private set; }
        public Price Price { get; private set; }
        public HostId HostId { get; private set; }
        public MenuId MenuId { get; private set; }
        public string ImageUrl { get; private set; }
        public Location Location { get; private set; }
        public IReadOnlyList<Reservation> Reservations
            => _reservations.AsReadOnly();
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        private Dinner(
            DinnerId dinnerId,
            HostId hostId,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            DinnerStatus status,
            bool isPublic,
            int maxGuests,
            Price price,
            MenuId menuId,
            string imageUrl,
            Location location)
            : base (dinnerId)
        {
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            Status = status;
            IsPublic = isPublic;
            MaxGuests = maxGuests;
            Price = price;
            HostId = hostId;
            MenuId = menuId;
            ImageUrl = imageUrl;
            Location = location;
            Status = DinnerStatus.Upcoming;
            CreatedDateTime = DateTime.UtcNow;
            UpdatedDateTime = DateTime.UtcNow;
        }

        public static Dinner Create(
            HostId hostId,
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            bool isPublic,
            int maxGuests,
            Price price,
            MenuId menuId,
            string imageUrl,
            Location location)
        {
            return new(
                DinnerId.CreateUnique(),
                hostId,
                name,
                description,
                startDateTime,
                endDateTime,
                DinnerStatus.Upcoming,
                isPublic,
                maxGuests,
                price,
                menuId,
                imageUrl,
                location);
        }

        public void AddReservation(
            int guestCount,
            GuestId guestId,
            BillId billId)
        {
            var reservation = Reservation.Create(
                guestCount,
                guestId,
                billId);

            _reservations.Add(reservation);
        }

        public void UpdateReservation(
            ReservationId reservationId,
            int guestCount,
            BillId billId,
            ReservationStatus status,
            DateTime? arrivalDateTime)
        {
            var reservation = Reservations.FirstOrDefault(
                r => r.Id == reservationId);
            
            if (reservation is not null)
            {
                reservation.Update(
                    guestCount,
                    billId,
                    status,
                    arrivalDateTime);
            }
        }

        public void Update(
            string name,
            string description,
            DateTime startDateTime,
            DateTime endDateTime,
            DateTime? startedDateTime,
            DateTime? endedDateTime,
            DinnerStatus status,
            bool isPublic,
            int maxGuests,
            Price price,
            MenuId menuId,
            string imageUrl,
            Location location)
        {
            Name = name;
            Description = description;
            StartDateTime = startDateTime;
            EndDateTime = endDateTime;
            StartedDateTime = startedDateTime;
            EndedDateTime = endedDateTime;
            Status = status;
            IsPublic = isPublic;
            MaxGuests = maxGuests;
            Price = price;
            MenuId = menuId;
            ImageUrl = imageUrl;
            Location = location;
            UpdatedDateTime = DateTime.UtcNow;
        }
    }

    public enum DinnerStatus
    {
        Upcoming,
        InProgress,
        Ended,
        Cancelled
    }
}
