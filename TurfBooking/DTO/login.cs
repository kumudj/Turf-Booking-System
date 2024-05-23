using System.IdentityModel.Tokens.Jwt;

namespace TurfBooking.DTO
{
    public class login
    {
        public string Email {  get; set; }
        public string Password { get; set; }
    }
    public class JWTTokenResponse
    {
        public string token { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Role { get; set; }
    }
}
