using System;
using System.ComponentModel.DataAnnotations;

namespace GamesParseLog.Domain.Entities
{
    public class FileParse
    {
        public FileParse() { }

        public FileParse(string fileName)
        {
            FileName = fileName;
            DateFile = DateTime.Now;
        }

        [Key]
        public int IdFileParse { get; private set; }
        public string FileName { get; private set; }
        public DateTime DateFile { get; private set; }
    }
}