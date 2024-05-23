namespace TurfBooking.Models
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }


    }

    public class NewUserDTO
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Phone { get; set; }
      
    }
    public class UpdateEmailforuser
    {
        public string Email { get; set; }
    }

}
