using System.Collections.Generic;

namespace Dashboard.Domain.Entity
{
    public class DeliveryTeam
    {
        public int Id { get; set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public string LicensePlate { get; private set; }

        public DeliveryTeam(string name, string description, string licensePlate)
        {
            Name = name;
            Description = description;
            LicensePlate = licensePlate;
        }

        public void Update(string name, string description, string licensePlate)
        {
            Name = name;
            Description = description;
            LicensePlate = licensePlate;
        }
    }
}
