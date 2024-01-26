using System.ComponentModel.DataAnnotations;

namespace ApiUser.Api.Model
{
    public class Login
    {
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}
