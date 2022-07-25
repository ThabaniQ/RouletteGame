using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Roulette.DAL.Models
{
    public partial class RouletteContext : DbContext
    {
        public RouletteContext()
        {
        }

        public RouletteContext(DbContextOptions<RouletteContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Bet> Bets { get; set; }
        public virtual DbSet<UserDetail> UserDetails { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {   
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\qwabet\\Downloads\\Compressed\\sqlitestudio-3.3.3\\SQLiteStudio\\Roulette;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Bet>(entity =>
            {
                entity.ToTable("Bet");

                entity.Property(e => e.BetId).HasColumnType("CHAR");

                entity.Property(e => e.BetAmount)
                    .HasColumnType("DOUBLE")
                    .HasColumnName("Bet_amount");

                entity.Property(e => e.BetValue)
                    .HasColumnType("BIGINT")
                    .HasColumnName("Bet_value");

                entity.Property(e => e.Payout).HasColumnType("DOUBLE");

                entity.Property(e => e.SpinValue)
                    .HasColumnType("CHAR")
                    .HasColumnName("Spin_value");

                entity.Property(e => e.UserId).HasColumnType("CHAR");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Bets)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<UserDetail>(entity =>
            {
                entity.HasKey(e => e.UserId);

                entity.Property(e => e.UserId).HasColumnType("CHAR");

                entity.Property(e => e.Balance).HasColumnType("BIGINT");

                entity.Property(e => e.Name).HasColumnType("CHAR");

                entity.Property(e => e.NumberOfLoses)
                    .HasColumnType("BIGINT")
                    .HasColumnName("Number_of_loses");

                entity.Property(e => e.NumberOfWins)
                    .HasColumnType("BIGINT")
                    .HasColumnName("Number_of_wins");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
