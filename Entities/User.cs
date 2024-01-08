using System.ComponentModel.DataAnnotations;

namespace LaundroMat.Entities
{
    public class User
    {
        public User(string firstName, string lastName, string email, string phoneNumber)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
            RegistrationDate = DateTime.UtcNow.ToString();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [Required]
        [MaxLength(14)]
        public string PhoneNumber { get; set; }

        [Required]
        public string RegistrationDate { get; set; } = DateTime.UtcNow.ToString();
    }
}
