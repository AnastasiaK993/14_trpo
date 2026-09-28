using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12prak.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public DbSet<Passport> Passports { get; set; }
        public DbSet<Group> Group { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<InterestGroup> InterestGroups { get; set; }
        public DbSet<UserInterestGroup> UserInterestGroups { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=localhost\SQLEXPRESS;Database=SchoolDBNew;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Group>().ToTable("Group");

            modelBuilder.Entity<Student>()
                .HasOne(s => s.Passport)
                .WithOne(ps => ps.Student)
                .HasForeignKey<Passport>(ps => ps.StudentId);

            modelBuilder.Entity<Group>()
                .HasMany(g => g.Students)
                .WithOne(s => s.Group)
                .HasForeignKey(s => s.GroupId);

            modelBuilder.Entity<Role>()
                .HasMany(r => r.Students)
                .WithOne(s => s.Role)
                .HasForeignKey(s => s.RoleId);

            modelBuilder.Entity<Student>()
                .HasOne(s => s.UserProfile)
                .WithOne(up => up.Student)
                .HasForeignKey<UserProfile>(up => up.StudentId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<UserInterestGroup>()
                .HasKey(uig => new { uig.UserId, uig.InterestGroupId });

            modelBuilder.Entity<UserInterestGroup>()
                .HasOne(uig => uig.User)
                .WithMany(s => s.UserInterestGroups)
                .HasForeignKey(uig => uig.UserId);

            modelBuilder.Entity<UserInterestGroup>()
                .HasOne(uig => uig.InterestGroup)
                .WithMany(g => g.UserInterestGroups)
                .HasForeignKey(uig => uig.InterestGroupId);
        }
    }
}