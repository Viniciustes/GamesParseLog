using GamesParseLog.Domain.Entities;
using GamesParseLog.Domain.Interfaces.Repositories;
using GamesParseLog.Infrastructure.Contexts;

namespace GamesParseLog.Infrastructure.Repositories
{
    public class RepositoryGame : IRepositoryGame
    {
        private readonly ContextDb _contextDb;

        public RepositoryGame(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public void SaveGame(Game game)
        {
            _contextDb.Game.Add(game);
            _contextDb.SaveChanges();
        }
    }
}