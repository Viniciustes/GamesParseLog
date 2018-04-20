using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace GamesParseLog.Domain.Entities
{
    public class Player
    {
        public Player()
        {
            Game = new HashSet<Game>();
        }

        [Key]
        public int IdPlayer { get; set; }
        public string NamePlayer { get; set; }
        public virtual ICollection<Game> Game { get; set; }
    }
}