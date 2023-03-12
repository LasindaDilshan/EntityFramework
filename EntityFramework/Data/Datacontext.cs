using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;
using System.Drawing;

namespace EntityFramework.Data
{
    public class Datacontext: DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> options) :base (options)
        {

        }
        public DbSet<User> userst { get; set; }

        public DbSet<Charactor> charactors { get; set; }
        public DbSet<Weapon> weapons { get; set; }

        public DbSet<Skill> Skills { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Charactor>()
             .HasOne(a => a.Weapon)
             .WithOne(a => a.Charactor)
             .HasForeignKey<Weapon>(c => c.CharactorId);

        }
    }
}
