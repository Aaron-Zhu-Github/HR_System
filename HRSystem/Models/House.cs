using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using Microsoft.Extensions.Hosting;

namespace HRSystem.Models
{
    public class House
    {
        public int ID { get; set; }
        public int ContactID { get; set; }
        public string Address { get; set; }
        public int NumberOfPerson { get; set; }

        // EF relationships
        public virtual ICollection<Employee>? Employees { get; set; }

        public virtual Person? Person { get; set; }  // Landlord

        public virtual ICollection<Facility>? Facilities { get; set; }
    }
}