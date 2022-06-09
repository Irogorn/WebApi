using System.ComponentModel.DataAnnotations;

namespace WebApi.DTO
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }
        [Required]
        public string PassWord { get; set; }
    }
}
