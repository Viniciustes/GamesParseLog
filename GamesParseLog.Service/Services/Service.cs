using GamesParseLog.Domain.Entities;
using GamesParseLog.Domain.Interfaces.Repositories;
using GamesParseLog.Service.Interfaces;
using GamesParseLog.Service.Services.ServicesFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;

namespace GamesParseLog.Service.Services
{
    public class Service : IService
    {
        private readonly IRepositoryGame _repositoryGame;
        private readonly IRepositoryKill _repositoryKill;
        private readonly IRepositoryPlayer _repositoryPlayer;
        private readonly IRepositoryFileParse _repositoryFileParse;

        public Service(IRepositoryGame repositoryGame, IRepositoryKill repositoryKill, IRepositoryPlayer repositoryPlayer, IRepositoryFileParse repositoryFileParse)
        {
            _repositoryGame = repositoryGame;
            _repositoryKill = repositoryKill;
            _repositoryPlayer = repositoryPlayer;
            _repositoryFileParse = repositoryFileParse;
        }

        public bool AddFileLog(HttpFileCollectionBase files)
        {
            if (!FileIsValid(files)) return false;

            var serviceFileUpload = new ServiceFileUpload();
            var file = serviceFileUpload.Upload(files);

            var serviceFileRead = new ServiceFileRead(_repositoryGame, _repositoryKill, _repositoryPlayer);
            var fileReturn = serviceFileRead.FileRead(file[2]);

            var fileParse = new FileParse(file[0]);

            _repositoryFileParse.SaveFileParse(fileParse);

            return true;
            throw new NotImplementedException();
        }

        private bool FileIsValid(HttpFileCollectionBase files)
        {
            var httpPostedFileBase = files[0];
            var extension = Path.GetExtension(httpPostedFileBase?.FileName);
            if (extension == null) return false;
            var extensionReplace = extension.Replace(".", "");
            var name = httpPostedFileBase.FileName;

            return ServiceVerifyExtensionFileParse.VerifyExtensionFileParse(extensionReplace) && FileExists(name);
        }

        private bool FileExists(string name) => _repositoryFileParse.FindByName(name) == null;

        public IEnumerable<FileParse> GetAllFilesProcessed() => _repositoryFileParse.GetAllFilesProcessed();
    }
}