using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ONIS.Data.Order.Entities
{
    public class Address
    {
        //public Address(string country, string state, string city, string zipcode, string fulladdress)
        //{
        //    Country = country;
        //    State = state;
        //    City = city;
        //    ZipCode = zipcode;
        //    FullAddress = fulladdress;
        //}
        [Required]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Country { get; set; } = string.Empty;
        public string State { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string ZipCode { get; set; } = string.Empty;
        public string FullAddress { get; set; } = string.Empty;
    }
}
