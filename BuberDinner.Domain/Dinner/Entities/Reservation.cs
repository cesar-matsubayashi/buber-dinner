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

        public Reservation(
            ReservationId reservationId, 
            int guestCount, 
            ReservationStatus reservationStatus, 
            GuestId guestId, 
            BillId billId, 
            DateTime createdDateTime, 
            DateTime updatedDateTime)
            : base (reservationId)
        {
            GuestCount = guestCount;
            Status = reservationStatus;
            GuestId = guestId;
            BillId = billId;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
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
                billId,
                DateTime.UtcNow,
                DateTime.UtcNow);
        }
    }

    public enum ReservationStatus
    {
        PendingGuestConfirmation,
        Reserved,
        Cancelled
    }
}
