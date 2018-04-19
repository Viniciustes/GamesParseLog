using GamesParseLog.Domain.Entities;
using System.Collections.Generic;

namespace GamesParseLog.Domain.Interfaces.Repositories
{
    public interface IRepositoryFileParse
    {
        void SaveFileParse(FileParse fileParse);
        IEnumerable<FileParse> GetAllFilesProcessed();
        FileParse FindByName(string name);
    }
}