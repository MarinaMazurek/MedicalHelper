using MedicalHelper.EfStaff.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Collections.Generic;
using System.Data;

namespace MedicalHelper.EfStaff
{
    public class MedicalHelperDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Medicine> Medicines { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<Vaccination> Vaccination { get; set; }

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

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);

        //    builder.HasOne(x => x.UserProfile)
        //        .WithOne(x => x.Owner)
        //        .HasForeignKey<UserProfile>(x => x.UserId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.HasMany(x => x.BankCards)
        //        .WithOne(x => x.Owner)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.HasMany(x => x.Books)
        //        .WithOne(x => x.Creater);

        //    builder.Property(x => x.Role).HasDefaultValue(Role.User);

        //    builder.Property(x => x.Language).HasDefaultValue(Language.English);
        //}
        //private void UserConfigure(EntityTypeBuilder<User> builder)
        //{
        //    builder.HasOne(x => x.UserProfile)
        //        .WithOne(x => x.Owner)
        //        .HasForeignKey<UserProfile>(x => x.UserId)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.HasMany(x => x.BankCards)
        //        .WithOne(x => x.Owner)
        //        .OnDelete(DeleteBehavior.Cascade);

        //    builder.HasMany(x => x.Books)
        //        .WithOne(x => x.Creater);

        //    builder.Property(x => x.Role).HasDefaultValue(Role.User);

        //    builder.Property(x => x.Language).HasDefaultValue(Language.English);
        //}

        //private void UserProfileConfigure(EntityTypeBuilder<UserProfile> builder)
        //{
        //    builder.Property(x => x.FullName)
        //        .HasComputedColumnSql("[FirstName] + ' ' + [LastName]");

        //    //builder.Property(x => x.LastName).IsRequired();

        //    builder.Property(x => x.FirstName).HasDefaultValue("FirstName");
        //    builder.Property(x => x.LastName).HasDefaultValue("LastName");
        //}

        //private void LessonConfigure(EntityTypeBuilder<Lesson> builder)
        //{
        //    builder.HasMany(x => x.Users)
        //        .WithMany(x => x.Lessons);
        //}
    }
}
