using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO
{
    public class UserDto
    {
        public UserDto(int userId, string userName, string firstName, string lastName, string email, string passWord, DateTime createdDate)
        {
            UserId = userId;
            UserName = userName;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PassWord = passWord;
            CreatedDate = createdDate;
        }

        [Required]
        public int UserId { get; set; }
        [Required]
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        [MinLength(8)]
        public string PassWord { get; set; }
        [Required]
        public DateTime CreatedDate { get; set; }

    }
}
