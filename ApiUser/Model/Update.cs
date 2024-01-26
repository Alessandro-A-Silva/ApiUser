using System.ComponentModel.DataAnnotations;

namespace ApiUser.Api.Model
{
    public class Update
    {
        [Required, Range(1, int.MaxValue)]
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
