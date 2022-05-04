using PlayerService.Models;

namespace PlayerService.Data
{
    //Interface>Concrete Class Pattern
    public interface IPlayerRepo
    {
        bool SaveChanges();

        IEnumerable<Player> GetAllPlayers();
        Player GetPlayerByLicense(int license);
        void CreatePlayer(Player player);
    }
}