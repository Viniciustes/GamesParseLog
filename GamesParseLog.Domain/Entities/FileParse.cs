using System;
using System.ComponentModel.DataAnnotations;

namespace GamesParseLog.Domain.Entities
{
    public class FileParse
    {
        [Key]
        public int IdFileParse { get; set; }
        public string FileName { get; set; }
        public DateTime DateFile { get; set; }
    }
}