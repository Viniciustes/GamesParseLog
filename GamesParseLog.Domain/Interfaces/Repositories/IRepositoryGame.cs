using GamesParseLog.Domain.Entities;

namespace GamesParseLog.Domain.Interfaces.Repositories
{
    public interface IRepositoryGame
    {
        void SaveGame(Game game);
    }
}