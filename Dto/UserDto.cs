using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace backTOT.Dto
{
    public class UserDto
    {
        [MaxLength(50)]
        public string UserName { get; set; }
        [MaxLength(50)]
        public string Email { get; set; }
        [MaxLength(50)]
        public string Password { get; set; }
    }
}
