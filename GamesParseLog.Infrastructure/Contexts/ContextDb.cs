using GamesParseLog.Domain.Entities;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace GamesParseLog.Infrastructure.Contexts
{
    public class ContextDb : DbContext
    {
        public ContextDb() : base("ParseLogGamesDb")
        {
            Database.SetInitializer<ContextDb>(null);
        }

        public DbSet<Game> Game { get; set; }
        public DbSet<Kill> Kill { get; set; }
        public DbSet<Player> Player { get; set; }
        public DbSet<FileParse> FileParse { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}