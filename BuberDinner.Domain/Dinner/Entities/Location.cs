using BuberDinner.Domain.Common.Models;
using BuberDinner.Domain.Dinner.ValueObjects;
using BuberDinner.Domain.Host.ValueObjects;

namespace BuberDinner.Domain.Dinner.Entities
{
    public sealed class Location : AggregateRoot<LocationId>
    {
        public string Name { get; private set; } 
        public string Address { get; private set;} 
        public float Latitude { get; private set;} 
        public float Longitude { get; private set;}
        public HostId HostId { get; private set;}

        private Location(
            LocationId locationId,
            string name, 
            string address, 
            float latitude, 
            float longitude,
            HostId hostId)
            : base(locationId)
        {
            
            Name = name;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
            HostId = hostId;
        }

        public static Location Create(
            string name,
            string address,
            float latitude,
            float longitude,
            HostId hostId)
        {  
            return new(
                LocationId.CreateUnique(),
                name, 
                address, 
                latitude, 
                longitude, 
                hostId);
        }

        public void Update (
            string name,
            string address,
            float latitude,
            float longitude)
        {
            Name = name;
            Address = address;
            Latitude = latitude;
            Longitude = longitude;
        }

#pragma warning disable CS8618
        private Location() { }
#pragma warning restore CS8618 

    }
}
