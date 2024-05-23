using Microsoft.EntityFrameworkCore;
using TurfBooking.Models;
using System.Security.Cryptography;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using TurfBooking.DTO;

namespace TurfBooking.Services
{
    public class UserService : IUserService
    {
        private readonly TurfBookingContext _context;
        private readonly IConfiguration configuration;

        public UserService(TurfBookingContext context,IConfiguration configuration)
        {
            _context = context;
            this.configuration = configuration;

        }

        public IEnumerable<UserDTO> GetUsers()
        {
            return _context.Users.Select(MapToDTO).ToList();
        }

        public UserDTO GetUser(int id)
        {
            var user = _context.Users.Find(id);
            return user != null ? MapToDTO(user) : null;
        }

        public UserDTO AddUser(NewUserDTO newUserDto)
        {
            var user = new User
            {
                Name = newUserDto.Name,
                Email = newUserDto.Email,
                Password =newUserDto.Password,
                Phone = newUserDto.Phone,
            };

            _context.Users.Add(user);
            _context.SaveChanges();

            var userDto = new UserDTO
            {
                Id = user.Id,
                Name = newUserDto.Name,
                Email = newUserDto.Email,
                Phone = newUserDto.Phone
                // Add other properties as necessary
            };

            return userDto;
        }
        public JWTTokenResponse Login(login newlogin)
        {
            var userExist = _context.Users.FirstOrDefault(t => t.Email == newlogin.Email && EF.Functions.Collate(t.Password, "SQL_Latin1_General_CP1_CS_AS") == newlogin.Password);
            if (userExist != null)
            {
                var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Key"]));
                var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
                var claims = new[]
                {
            new Claim(ClaimTypes.Email,userExist.Email),
            new Claim("Id",userExist.Id.ToString()),
            new Claim(ClaimTypes.Role,userExist.Role)
        };
                var token = new JwtSecurityToken(configuration["Jwt:Issuer"], configuration["Jwt:Audience"], claims, expires: DateTime.Now.AddMinutes(30), signingCredentials: credentials);
                var userid = userExist.Id;
                var userRole = userExist.Role;

                return new JWTTokenResponse
                {
                   Id = userid,
                   Name = userExist.Name,
                   Role = userExist.Role,
                   token= new JwtSecurityTokenHandler().WriteToken(token)

                };
            }
            return new JWTTokenResponse { token="1"};
        }

        public void UpdateUser(int id, UserDTO userDto)
        {
            var user = _context.Users.Find(id);
            if (user == null) return;

            user.Name = userDto.Name;
            user.Email = userDto.Email;
            user.Phone = userDto.Phone;
            // Consider updating the password securely

            _context.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }
        private bool UserExist(User user)
        {
            return _context.Users.Any(t => t.Email == user.Email);
        }

        private UserDTO MapToDTO(User user)
        {
            return new UserDTO
            {
                Id = user.Id,
                Name = user.Name,
                Email = user.Email,
                Phone = user.Phone
            };
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var bytes = Encoding.UTF8.GetBytes(password);
                var hash = sha256.ComputeHash(bytes);
                return Convert.ToBase64String(hash);
            }
        }
    }
}
