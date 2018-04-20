using GamesParseLog.Domain.Entities;
using GamesParseLog.Domain.Interfaces.Repositories;
using GamesParseLog.Infrastructure.Contexts;
using System.Linq;

namespace GamesParseLog.Infrastructure.Repositories
{
    public class RepositoryPlayer : IRepositoryPlayer
    {
        private readonly ContextDb _contextDb;

        public RepositoryPlayer(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public void SavePlayer(Player player)
        {
            _contextDb.Player.Add(player);
            _contextDb.SaveChanges();
        }

        public Player GetByName(string name) => _contextDb.Player.Where(x => x.NamePlayer.Trim() == name.Trim()).FirstOrDefault();
    }
}