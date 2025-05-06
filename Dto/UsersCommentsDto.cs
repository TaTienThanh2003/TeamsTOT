using System.ComponentModel.DataAnnotations;

namespace backTOT.Dto
{
    public class UsersCommentsDto
    {
        [MaxLength(50)]
        public string UserName { get; set; }
        public string? Image { get; set; } = "img/face.jpg";
    }
}
