using System.ComponentModel.DataAnnotations;
using System.Xml;
using PlayerService.Models;

namespace PlayerService.Dtos
{
    public class PlayerCreateDto
    {
        [Required]
        public Guid UserLicense { get; set; }
    }
}
