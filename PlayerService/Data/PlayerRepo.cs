using System.Security.AccessControl;
using System.Xml;
using PlayerService.Models;

namespace PlayerService.Data
{
    public class PlayerRepo : IPlayerRepo
    {
        private readonly AppDbContext _context;

        public PlayerRepo(AppDbContext context)
        {
            _context = context;
        }

        public void CreatePlayer(Player player)
        {
            if (player == null)
            {
                throw new ArgumentNullException(nameof(player));
            }

            _context.Player.Add(player);
        }

        public IEnumerable<Player> GetAllPlayers()
        {
            return _context.Player.ToList();
        }

        public Player GetPlayerByLicense(Guid license)
        {
            var res = _context.Player.FirstOrDefault(p => p.UserLicense == license);
            if (res != null) {
                return res;
            }
            throw new ArgumentException("A problem occured accesing this context.");
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}
