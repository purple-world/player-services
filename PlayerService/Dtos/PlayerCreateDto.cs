using System.ComponentModel.DataAnnotations;
using PlayerService.Models;

namespace PlayerService.Dtos
{
    public class PlayerCreateDto
    {
        [Required]
        public string UserLicense { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
