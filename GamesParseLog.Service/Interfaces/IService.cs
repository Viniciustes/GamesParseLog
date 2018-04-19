using GamesParseLog.Domain.Entities;
using System.Collections.Generic;
using System.Web;

namespace GamesParseLog.Service.Interfaces
{
    public interface IService
    {
        bool AddFileLog(HttpFileCollectionBase files);
        IEnumerable<FileParse> GetAllFilesProcessed();
    }
}