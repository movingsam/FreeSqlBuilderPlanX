using System.ComponentModel.DataAnnotations;

namespace FreeSqlBuilderPlanX.Application.Dto.Login
{
    public class LoginRequest
    {
        [Required]
        [MaxLength(24)]
        public string UserId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}