using System.ComponentModel.DataAnnotations;

namespace ApiUser.Api.Model
{
    public class Create
    {
        [Required(AllowEmptyStrings = false)]
        public string FirstName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string LastName { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Email { get; set; }
        [Required(AllowEmptyStrings = false)]
        public string Password { get; set; }
    }
}
