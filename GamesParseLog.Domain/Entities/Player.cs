using System.ComponentModel.DataAnnotations;

namespace GamesParseLog.Domain.Entities
{
    public class Player
    {
        [Key]
        public int IdPlayer { get; set; }
        public string NamePlayer { get; set; }
    }
}