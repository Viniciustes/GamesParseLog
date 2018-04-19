using GamesParseLog.Domain.Entities;
using GamesParseLog.Domain.Interfaces.Repositories;
using GamesParseLog.Infrastructure.Contexts;

namespace GamesParseLog.Infrastructure.Repositories
{
    public class RepositoryKill : IRepositoryKill
    {
        private readonly ContextDb _contextDb;

        public RepositoryKill(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public void SaveKill(Kill kill)
        {
            _contextDb.Kill.Add(kill);
            _contextDb.SaveChanges();
        }
    }
}