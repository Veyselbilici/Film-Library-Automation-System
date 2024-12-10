using FinalProject.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject.Infstructure.Database.Mssql
{
    public class FinalProjectDbContext : DbContext
    {
        //entities
        public DbSet<User> Users { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Movie> Movies { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<WatchListItem> WatchList { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-BRI47F4\\SQLEXPRESS;Database=MovieTheaterDb;TrustServerCertificate=True;Integrated Security=true;");
        }

 

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<PremiumUser>();
            modelBuilder.Entity<StandartUser>();
            modelBuilder.Entity<WatchListItem>().HasKey(x => x.Id);
            modelBuilder.Entity<WatchListItem>().Property(x => x.Id).UseIdentityColumn();
            modelBuilder.Entity<Gender>().Property(x => x.ID).UseIdentityColumn();
            modelBuilder.Entity<Actor>().Property(x => x.ID).UseIdentityColumn();
            modelBuilder.Entity<Director>().Property(x => x.ID).UseIdentityColumn();
            modelBuilder.Entity<Director>().HasMany(x => x.Movies);
            modelBuilder.Entity<Genre>().Property(x => x.ID).UseIdentityColumn();
            modelBuilder.Entity<Genre>().HasMany(x => x.Movies);
            modelBuilder.Entity<Gender>().Property(x => x.ID).UseIdentityColumn();
            modelBuilder.Entity<Movie>().Property(x => x.ID).UseIdentityColumn();
            modelBuilder.Entity<Movie>().HasOne(x => x.Director);
            modelBuilder.Entity<Review>().Property(x => x.ID).UseIdentityColumn();
            modelBuilder.Entity<Movie>().HasMany(x => x.Actors).WithMany(x => x.Movies);


            modelBuilder.Entity<User>().HasKey(s => s.TC);

            modelBuilder.Entity<User>()
                .Property(p => p.TC)
                .ValueGeneratedNever();


        }
    }
}
