using System.ComponentModel.DataAnnotations;

namespace PlayerService.Models
{
    public class Player
    {
        [Key]
        [Required]
        public string CitizenID { get; set; }
        [Required]
        public string UserLicense { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Money { get; set; }
        [Required]
        public string CharInfo { get; set; }
        [Required]
        public string Job { get; set; }
        [Required]
        public string Gang { get; set; }
        [Required]
        public string Position { get; set; }
        [Required]
        public MetaData MetaData { get; set; }
        [Required]
        public string Inventory { get; set; }
        [Required]
        public DateTime LastUpdated { get; set; }
    }
}