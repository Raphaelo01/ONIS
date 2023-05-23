using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ONIS.API.Catalog.Controllers;

[Route("api/authentication")]

[ApiController]
public class AuthenticationController : ControllerBase
{
    public class AuthenticationRequestBody
    {
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
    public class CityInfoUser
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string City { get; set; }
        public CityInfoUser(int userId, string userName, string firstName, string lastName, string city)
        {
            UserId = userId;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            City = city;
        }
    }

    private readonly IConfiguration _configuration;
    public AuthenticationController(IConfiguration configuration)
    {
        _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
    }
    [HttpPost("authenticate")]
    public ActionResult<string> Authenticate(AuthenticationRequestBody authenticationRequestBody)
    {
        //step 1: validate the user / password

        var user = ValidateUserCredentials(authenticationRequestBody.Username, authenticationRequestBody.Password);


        if (user == null)
        {
            return Unauthorized();
        }
        var configureAutenticationKey = _configuration["Authentication:SecretForKey"] ?? "";
        var securytyKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configureAutenticationKey));
        var signingCredentials = new SigningCredentials(securytyKey, SecurityAlgorithms.HmacSha256);

        //The claims that
        var claimsForToken = new List<Claim>();
        claimsForToken.Add(new Claim("sub", user.UserId.ToString()));//standar key 
        claimsForToken.Add(new Claim("given_name", user.FirstName.ToString()));//standar key
        claimsForToken.Add(new Claim("family_name", user.LastName.ToString()));//standar key
        claimsForToken.Add(new Claim("city", user.City.ToString()));

        var jwtSecurytiToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials
            );

        var tokenToReturn = new JwtSecurityTokenHandler().WriteToken(jwtSecurytiToken);

        return Ok(tokenToReturn);
    }

    private CityInfoUser ValidateUserCredentials(string? username, string? password)
    {
        ////domy de acceso a base de datos
        return new CityInfoUser(1, username ?? "", "Rafael", "Gonzalez", "Mexico");

    }
}