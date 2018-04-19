using GamesParseLog.Domain.Entities;
using GamesParseLog.Domain.Interfaces.Repositories;
using GamesParseLog.Infrastructure.Contexts;

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
    }
}