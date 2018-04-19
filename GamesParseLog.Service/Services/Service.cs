using GamesParseLog.Domain.Entities;
using GamesParseLog.Domain.Interfaces.Repositories;
using GamesParseLog.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Web;

namespace GamesParseLog.Service.Services
{
    public class Service : IService
    {
        private readonly IRepositoryFileParse _repositoryFileParse;

        public Service(IRepositoryFileParse repositoryFileParse)
        {
            _repositoryFileParse = repositoryFileParse;
        }

        public bool AddFileLog(HttpFileCollectionBase files)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<FileParse> GetAllFilesProcessed() => _repositoryFileParse.GetAllFilesProcessed();
    }
}