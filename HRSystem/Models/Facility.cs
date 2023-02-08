using System;
namespace HRSystem.Models
{
    public class Facility
    {
        public int ID { get; set; }
        public string TYPE { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int HouseID { get; set; }

        // EF Relationships
        public virtual House? House { get; set; }
    }
}

