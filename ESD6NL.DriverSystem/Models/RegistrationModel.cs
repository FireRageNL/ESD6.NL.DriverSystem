using System.ComponentModel.DataAnnotations;

namespace ESD6NL.DriverSystem.Models
{
    public class RegistrationModel
    {
        [Required]
        public string Username { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password))]
        public string PasswordRepeat { get; set; }
        [Required]
        public string Verification { get; set; }
    }
}