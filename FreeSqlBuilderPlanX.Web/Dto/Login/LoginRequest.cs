using System.ComponentModel.DataAnnotations;

namespace FreeSqlBuilderPlanX.Web.Dto.Login
{
    public class LoginRequest
    {
        [Required]
        [MaxLength(24)]
        public string Username { get; set; }
        [Required]
        [MaxLength(50)]
        public string Password { get; set; }
    }
}