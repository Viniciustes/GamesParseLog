using GamesParseLog.Domain.Entities;

namespace GamesParseLog.Domain.Interfaces.Repositories
{
    public interface IRepositoryKill
    {
        void SaveKill(Kill kill);
    }
}