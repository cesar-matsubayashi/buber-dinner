using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Dinner.Entities
{
    public sealed class Reservation : AggregateRoot<ReservationId>
    {
        public int GuestCount { get; private set; }
        public ReservationStatus Status { get; private set;}
        public GuestId GuestId { get; private set;}
        public BillId BillId { get; private set;}
        public DateTime? ArrivalDateTime { get; private set;}
        public DateTime CreatedDateTime { get; private set;}
        public DateTime UpdatedDateTime { get; private set;}

        private Reservation(
            ReservationId reservationId, 
            int guestCount, 
            ReservationStatus status, 
            GuestId guestId, 
            BillId billId)
            : base (reservationId)
        {
            GuestCount = guestCount;
            Status = status;
            GuestId = guestId;
            BillId = billId;
            CreatedDateTime = DateTime.UtcNow;
            UpdatedDateTime = DateTime.UtcNow;
        }

        public static Reservation Create(
            int guestCount,
            GuestId guestId,
            BillId billId)
        {
            return new(
                ReservationId.CreateUnique(),
                guestCount,
                ReservationStatus.Reserved,
                guestId,
                billId);
        }

        public void Update(
            int guestCount,
            BillId billId,
            ReservationStatus status,
            DateTime? arrivalDateTime)
        {
            GuestCount = guestCount;
            BillId = billId;
            Status = status;
            ArrivalDateTime = arrivalDateTime;
            UpdatedDateTime = DateTime.UtcNow;
        }

#pragma warning disable CS8618
        private Reservation() { }
#pragma warning restore CS8618 
    }

    public enum ReservationStatus
    {
        PendingGuestConfirmation,
        Reserved,
        Cancelled
    }
}
