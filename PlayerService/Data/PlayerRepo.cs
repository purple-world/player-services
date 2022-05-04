using PlayerService.Models;

namespace PlayerService.Data
{
    public class PlayerRepo : IPlayerRepo
    {
        //Dependency injection of AppDbContext
        private readonly AppDbContext _context;

        public PlayerRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePlayer(Player player)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return _context.Player.ToList();
        }

        public Player GetPlayerByLicense(int license)
        {
            return _context.Player.FirstOrDefault(p => p.UserLicense == license);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
