using GamesParseLog.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace GamesParseLog.Domain.Entities
{
    public class Kill
    {
        [Key]
        public int IdKill { get; set; }
        public EMeansOfDeath TypeOfDeath { get; set; }

        public int IdGame { get; set; }
        public Game Game { get; set; }

        public int IdPlayer { get; set; }
        public Player Player { get; set; }
    }
}