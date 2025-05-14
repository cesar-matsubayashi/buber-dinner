using BuberDinner.Domain.Bill.ValueObjects;
using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Guest.Entities;
using BuberDinner.Domain.Guest.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.MenuReview.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Guest
{
    public sealed class Guest : AggregateRoot<GuestId>
    {
        private readonly List<DinnerId> _upcomingDinnerIds = new();
        private readonly List<DinnerId> _pastDinnerIds = new();
        private readonly List<DinnerId> _pendingDinnerIds = new();
        private readonly List<BillId> _billIds = new();
        private readonly List<MenuReviewId> _menuReviewIds = new();
        private readonly List<GuestRating> _guestRatings = new();

        public string FirstName { get; private set; }
        public string LastName { get; private set;}
        public string ProfileImage { get; private set;}
        public UserId UserId { get; private set;}
        public AverageRating AverageRating { get; private set;}
        public IReadOnlyList<DinnerId> UpcomingDinnerIds 
            => _upcomingDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PastDinnerIds 
            => _pastDinnerIds.AsReadOnly();
        public IReadOnlyList<DinnerId> PendingDinnerIds 
            => _pendingDinnerIds.AsReadOnly();
        public IReadOnlyList<BillId> BillIds
            => _billIds.AsReadOnly();
        public IReadOnlyList<MenuReviewId> MenuReviewIds
            => _menuReviewIds.AsReadOnly();
        public IReadOnlyList<GuestRating> GuestRatings
            => _guestRatings.AsReadOnly();
        public DateTime CreatedDateTime { get; private set;}
        public DateTime UpdatedDateTime { get; private set;}

        private Guest(
            GuestId guestId,
            string firstName, 
            string lastName, 
            string profileImage, 
            UserId userId, 
            AverageRating averageRating,
            DateTime createdDateTime, 
            DateTime updatedDateTime)
            : base(guestId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            UserId = userId;
            AverageRating = averageRating;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Guest Create(
            string firstName,
            string lastName,
            string profileImage,
            UserId userId)
        {
            return new(
                GuestId.CreateUnique(),
                firstName,
                lastName,
                profileImage,
                userId,
                AverageRating.CreateNew(),
                DateTime.UtcNow,
                DateTime.UtcNow);
        }

        public void AddGuestRating(
            HostId hostId,
            DinnerId dinnerId,
            Rating rating)
        {
            var guestRating = GuestRating.Create(hostId, dinnerId, rating);

            _guestRatings.Add(guestRating);
        }

        public void UpdateGuestRating(
            GuestRatingId guestRatingId,
            Rating rating)
        {
            var guestRating = _guestRatings.FirstOrDefault(
                r => r.Id == guestRatingId);

            if (guestRating is not null)
            {
                guestRating.Update(rating);
            }
        }

        public void SetUpcomingDinnerIds(IEnumerable<DinnerId> dinnerIds)
        {
            _upcomingDinnerIds.Clear();
            _upcomingDinnerIds.AddRange(dinnerIds);
        }

        public void SetPastDinnerIds(IEnumerable<DinnerId> dinnerIds)
        {
            _pastDinnerIds.Clear();
            _pastDinnerIds.AddRange(dinnerIds);
        }

        public void SetPendingDinnerIds(IEnumerable<DinnerId> dinnerIds)
        {
            _pendingDinnerIds.Clear();
            _pendingDinnerIds.AddRange(dinnerIds);
        }

        public void SetBillIds(IEnumerable<BillId> billIds)
        {
            _billIds.Clear();
            _billIds.AddRange(billIds);
        }

        public void SetMenuReviewIds(IEnumerable<MenuReviewId> menuReviewIds)
        {
            _menuReviewIds.Clear();
            _menuReviewIds.AddRange(menuReviewIds);
        }

        public void Update(
            string firstName,
            string lastName,
            string profileImage)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            UpdatedDateTime = DateTime.UtcNow;
        }
    }
}
