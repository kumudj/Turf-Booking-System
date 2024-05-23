using System.Collections.Generic;
using TurfBooking.Models;
using TurfBooking.DTO;

namespace TurfBooking.Services
{
    public interface IUserService
    {
        IEnumerable<UserDTO> GetUsers();
        UserDTO GetUser(int id);
        UserDTO AddUser(NewUserDTO newUserDto);
        void UpdateUser(int id, UserDTO userDto);
        //void UpdateUserEmail(int id, UpdateEmailforuser dto);
        void DeleteUser(int id);
        JWTTokenResponse Login(login newlogin);
    }
}
