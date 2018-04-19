using GamesParseLog.Domain.Entities;
using GamesParseLog.Domain.Interfaces.Repositories;
using GamesParseLog.Infrastructure.Contexts;
using System.Collections.Generic;
using System.Linq;

namespace GamesParseLog.Infrastructure.Repositories
{
    public class RepositoryFileParse : IRepositoryFileParse
    {
        private readonly ContextDb _contextDb;

        public RepositoryFileParse(ContextDb contextDb)
        {
            _contextDb = contextDb;
        }

        public void SaveFileParse(FileParse fileParse)
        {
            _contextDb.FileParse.Add(fileParse);
            _contextDb.SaveChanges();
        }

        public IEnumerable<FileParse> GetAllFilesProcessed() => _contextDb.FileParse;

        public FileParse FindByName(string name) => GetAllFilesProcessed().Where(f => f.FileName == name).FirstOrDefault();
    }
}