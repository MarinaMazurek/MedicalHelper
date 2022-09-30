using MedicalHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace MedicalHelper.DataBase
{
    public class MedicalHelperDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }

        private const string ConnectingString =
            "Server=(localdb)\\MSSQLLocalDB;" +
            "Database=MedicalHelperDb;" +
            "Trusted_Connection=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectingString);
        }


        //public MedicalHelperDbContext(DbContextOptions options) : base(options)
        //{
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasOne(u => u.UserProfile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.UserId);

            modelBuilder
                .Entity<User>()
                .HasMany(u => u.Vaccinations)
                .WithOne(p => p.User)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
               .Entity<User>()
               .HasMany(u => u.Visits)
               .WithOne(p => p.User)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder
                .Entity<Visit>()
                .HasMany(u => u.Medicines)
                .WithOne(p => p.Visit)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder
            //.Entity<UserProfile>()
            //.Property(p => p.FullName)
            //.HasComputedColumnSql("[FirstName] + ' ' + [LastName]");
        }
    }
}
