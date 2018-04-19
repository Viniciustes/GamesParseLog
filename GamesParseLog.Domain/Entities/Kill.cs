using GamesParseLog.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace GamesParseLog.Domain.Entities
{
    public class Kill
    {
        [Key]
        public int IdKill { get; set; }
        public Player Player { get; set; }
        public int Kills { get; set; }
        public EMeansOfDeath TypeOfDeath { get; set; }
    }
}