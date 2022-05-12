using System.ComponentModel.DataAnnotations;
using System.Xml;
using PlayerService.Models;

namespace PlayerService.Dtos
{
    public class PlayerReadDto
    {
        public int CitizenId { get; set; }
        public Guid UserLicense { get; set; }
        public string Name { get; set; }
        public string Money { get; set; }
        public string Job { get; set; }
        public string Gang { get; set; }
        public string Position { get; set; }
        public string Inventory { get; set; }
        public DateTime LastUpdated { get; set; }
    }
}
