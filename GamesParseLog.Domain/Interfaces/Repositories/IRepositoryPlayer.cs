using GamesParseLog.Domain.Entities;

namespace GamesParseLog.Domain.Interfaces.Repositories
{
    public interface IRepositoryPlayer
    {
        void SavePlayer(Player player);
        Player GetByName(string name);
    }
}