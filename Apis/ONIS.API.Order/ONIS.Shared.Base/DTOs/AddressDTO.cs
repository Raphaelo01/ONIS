namespace ONIS.Shared.Base.DTOs;

public class AddressDTO
{
    public AddressDTO(int id, string country, string state, string city, string zipcode, string fulladdress)
    {
        Id = id;
        Country = country;
        State = state;
        City = city;
        ZipCode = zipcode;
        FullAddress = fulladdress;
    }
    public int Id { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string ZipCode { get; set; }
    public string FullAddress { get; set; }
}
