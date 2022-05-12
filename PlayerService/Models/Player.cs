using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace PlayerService.Models
{
    public class Player
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1, TypeName = "serial")]
        public int CitizenId { get; set; }
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