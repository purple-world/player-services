using System.ComponentModel.DataAnnotations;
using System.Xml;
using PlayerService.Models;

namespace PlayerService.Dtos
{
    public class PlayerCreateDto
    {
        [Required]
        public int CitizenID { get; set; }
        [Required]
        public Guid UserLicense { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Money { get; set; }
        [Required]
        public string Job { get; set; }
        [Required]
        public string Gang { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public string Inventory { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }
    }
}
