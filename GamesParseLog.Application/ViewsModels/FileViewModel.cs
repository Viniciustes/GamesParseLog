using System;

namespace GamesParseLog.Application.ViewsModels
{
    public class FileViewModel
    {
        public FileViewModel() { }

        public FileViewModel(string fileName, DateTime dateFile)
        {
            FileName = fileName;
            DateFile = dateFile;
        }

        public string FileName { get; set; }
        public DateTime DateFile { get; set; }
    }
}