using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.ValueObjects;

namespace BuberDinner.Domain.Dinner.Entities
{
    public sealed class Reservation : AggregateRoot<ReservationId>
    {
        public int GuestCount { get; }
        public ReservationStatus Status { get; }
        public GuestId GuestId { get; }
        public BillId BillId { get; }
        public DateTime? ArrivalDateTime { get; }
        public DateTime CreatedDateTime { get; }
        public DateTime UpdatedDateTime { get; }

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
    }

    public enum ReservationStatus
    {
        PendingGuestConfirmation,
        Reserved,
        Cancelled
    }
}
