using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kolokwium2.Models
{
    public class PlayerContext : DbContext
    {
        public DbSet<Championship> Championships { get; set; }
        public DbSet<Championship_Team> Championship_Teams { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<Player_Team> Player_Teams { get; set; }
        public DbSet<Team> Teams { get; set; }

        public PlayerContext()
        {
        }

        public PlayerContext(DbContextOptions options):base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //Definicja Ograniczen
            modelBuilder.Entity<Championship>(e =>
            {
                e.HasKey(p => p.IdChampionship);
                e.Property(p => p.IdChampionship).ValueGeneratedOnAdd();

                e.Property(p => p.Officialname).HasMaxLength(100).IsRequired();

                e.HasMany(p => p.Championship_Teams).WithOne(p => p.Championship).HasForeignKey(p => p.IdChampionship);
            });

            modelBuilder.Entity<Championship_Team>(e =>{
                e.HasKey(p => p.IdTeam);
                e.Property(p => p.IdTeam).ValueGeneratedOnAdd();

                e.HasKey(p => p.IdChampionship);
                e.Property(p => p.IdChampionship).ValueGeneratedOnAdd();
            });

            modelBuilder.Entity<Team>(e => {
                e.HasKey(p => p.IdTeam);
                e.Property(p => p.IdTeam).ValueGeneratedOnAdd();

                e.Property(p => p.TeamName).HasMaxLength(30).IsRequired();

                e.HasMany(p => p.Championship_Teams).WithOne(p => p.Team).HasForeignKey(p => p.IdTeam);
                e.HasMany(p => p.Player_Teams).WithOne(p => p.Team).HasForeignKey(p => p.IdTeam);
            });

            modelBuilder.Entity<Player_Team>(e => {
                e.HasKey(p => p.IdPlayer);
                e.Property(p => p.IdPlayer).ValueGeneratedOnAdd();

                e.HasKey(p => p.IdTeam);
                e.Property(p => p.IdTeam).ValueGeneratedOnAdd();

                e.Property(p => p.Comment).HasMaxLength(300);
            });

            modelBuilder.Entity<Player>(e => {
                e.HasKey(p => p.IdPlayer);
                e.Property(p => p.IdPlayer).ValueGeneratedOnAdd();

                e.Property(p => p.FirstName).HasMaxLength(30).IsRequired();
                e.Property(p => p.LastName).HasMaxLength(50).IsRequired();

                e.HasMany(p => p.Player_Teams).WithOne(p => p.Player).HasForeignKey(p => p.IdPlayer);
            });



        }
    }
}
