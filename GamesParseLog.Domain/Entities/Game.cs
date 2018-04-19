using System.ComponentModel.DataAnnotations;

namespace GamesParseLog.Domain.Entities
{
    public class Game
    {
        [Key]
        public int IdGame { get; set; }
    }
}