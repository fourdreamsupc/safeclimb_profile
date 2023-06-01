using System.Collections.Generic;
using System.Text.Json.Serialization;


namespace Go2Climb.API.Customers.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        [JsonIgnore]
        public string PasswordHash { get; set; }
        public string PhoneNumber { get; set; }
        public string Photo { get; set; }
    }
}