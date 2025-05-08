namespace BuberDinner.Domain.Dinner.Entities
{
    public sealed class Location
    {
        public string Name { get; } 
        public string Address { get; } 
        public float Latitude { get; } 
        public float Longitude { get; }

        public Location(
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
        public static Location Create(
            string name,
            string address,
            float latitude,
            float longitude)
        {  
            return new(name, address, latitude, longitude);
        }



    }
}
