using System.Xml;
using PlayerService.Models;

namespace PlayerService.Data
{
    //Interface>Concrete Class Pattern
    public interface IPlayerRepo
    {
        bool SaveChanges();
        IEnumerable<Player> GetAllPlayers();
        IEnumerable<Player> GetPlayersByLicense(Guid license);
        void CreatePlayer(Player player);
    }
}