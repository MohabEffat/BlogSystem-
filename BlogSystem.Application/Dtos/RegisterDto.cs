using System.ComponentModel.DataAnnotations;

namespace BlogSystem.Application.Dtos
{
    public class RegisterDto
    {
        public string FirstName { get; set; }  
        public string LastName { get; set; }
        public string UserName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
