using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesParseLog.Domain.Entities
{
    public class Game
    {
        public Game()
        {
            Player = new HashSet<Player>();
        }

        [Key]
        public int IdGame { get; set; }
        public string NameGame { get; set; }
        public virtual ICollection<Player> Player { get; set; }
    }
}