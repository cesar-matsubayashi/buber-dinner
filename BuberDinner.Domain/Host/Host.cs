using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Common.ValueObjects;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;
using BuberDinner.Domain.Menu.ValueObjects;
using BuberDinner.Domain.User.ValueObjects;

namespace BuberDinner.Domain.Host
{
    public sealed class Host : AggregateRoot<HostId>
    {
        private readonly List<MenuId> _menuIds = new();
        private readonly List<DinnerId> _dinnerIds = new();
        public string FirstName { get; private set; }
        public string LastName { get; private set; }
        public string ProfileImage { get; private set; }
        public AverageRating AverageRating { get; private set; }
        public UserId UserId { get; private set; }
        public IReadOnlyList<MenuId> MenuIds => _menuIds.AsReadOnly();
        public IReadOnlyList<DinnerId> DinnerIds => _dinnerIds.AsReadOnly();
        public DateTime CreatedDateTime { get; private set; }
        public DateTime UpdatedDateTime { get; private set; }

        public Host(
            HostId hostId,
            string firstName, 
            string lastName, 
            string profileImage, 
            UserId userId, 
            AverageRating averageRating,
            DateTime createdDateTime, 
            DateTime updatedDateTime)
            : base (hostId)
        {
            FirstName = firstName;
            LastName = lastName;
            ProfileImage = profileImage;
            UserId = userId;
            AverageRating = averageRating;
            CreatedDateTime = createdDateTime;
            UpdatedDateTime = updatedDateTime;
        }

        public static Host Create(
            string firstName,
            string lastName,
            string profileImage,
            UserId userId)
        {
            return new(
                HostId.CreateUnique(),
                firstName,
                lastName,
                profileImage,
                userId,
                AverageRating.CreateNew(),
                DateTime.UtcNow,
                DateTime.UtcNow);
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

#pragma warning disable CS8618
        private Host() { }
#pragma warning restore CS8618 
    }
}
