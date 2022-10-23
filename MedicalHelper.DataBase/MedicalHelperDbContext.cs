using MedicalHelper.DataBase.Entities;
using Microsoft.EntityFrameworkCore;

namespace MedicalHelper.DataBase
{
    public class MedicalHelperDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Vaccination> Vaccinations { get; set; }
        public DbSet<Role> Roles { get; set; }


        public MedicalHelperDbContext(DbContextOptions<MedicalHelperDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<User>()
                .HasOne(u => u.UserProfile)
                .WithOne(p => p.User)
                .HasForeignKey<UserProfile>(p => p.UserId);

            modelBuilder
              .Entity<Role>()
              .HasMany(u => u.Users)
              .WithOne(p => p.Role)
              .OnDelete(DeleteBehavior.Cascade);

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
