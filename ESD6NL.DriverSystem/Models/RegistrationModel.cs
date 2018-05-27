using System.ComponentModel.DataAnnotations;

namespace ESD6NL.DriverSystem.Models
{
    public class RegistrationModel
    {
        [Required]
        [Display(Name = "First name")]
        public string FirstName { get; set; }
        [Required]
        [Display(Name = "Last name")]
        public string LastName { get; set; }
        [Required]
        [Display(Name ="Citizen Service Number")]
        public long CitizenServiceNumber { get; set; }
        [Required]
        public string Username { get; set; }
        [Required,DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required,DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.Password), Compare(nameof(Password))]
        [Display(Name = "Password validation")]
        public string PasswordRepeat { get; set; }
    }
}