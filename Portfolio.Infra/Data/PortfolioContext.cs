using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities;
using Portfolio.Core.ProfileUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Infra.Data
{
    public class PortfolioContext : IdentityDbContext<AppUser, Role, Guid>
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options)
        {
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<ProfessionalStack> ProfessionalStacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seeding initial data

            // Define static role IDs (optional, but ensures consistency)
            var recruiterRoleId = Guid.NewGuid();
            var developerRoleId = Guid.NewGuid();
            var adminRoleId = Guid.NewGuid();

            modelBuilder.Entity<Role>().HasData(
                new Role
                {
                    Id = recruiterRoleId,
                    Name = "Recruiter",
                    NormalizedName = "RECRUITER"
                },
                new Role
                {
                    Id = developerRoleId,
                    Name = "Developer",
                    NormalizedName = "DEVELOPER"
                },
                new Role
                {
                    Id = adminRoleId,
                    Name = "Admin",
                    NormalizedName = "ADMIN"
                }
            );


            // AppUser ↔ ProfessionalStack (1-to-1)
            modelBuilder.Entity<AppUser>()
                .HasOne(a => a.ProfessionalStack)
                .WithOne(p => p.AppUser)
                .HasForeignKey<ProfessionalStack>(p => p.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // AppUser ↔ Profile (1-to-1)
            modelBuilder.Entity<AppUser>()
                .HasOne(a => a.Profile)
                .WithOne(p => p.AppUser)
                .HasForeignKey<Profile>(p => p.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // AppUser ↔ WorkExperiences (1-to-many)
            modelBuilder.Entity<AppUser>()
                .HasMany(a => a.WorkExperiences)
                .WithOne(w => w.AppUser)
                .HasForeignKey(w => w.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // ProfessionalStack ↔ WorkExperiences (optional if AppUser already links WorkExperience directly)
            modelBuilder.Entity<ProfessionalStack>()
                .HasMany(p => p.WorkExperiences)
                .WithOne()
                .OnDelete(DeleteBehavior.Cascade);

            // AppUser <-> Profile (1-to-1)
            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.Profile)
                .WithOne(p => p.AppUser)
                .HasForeignKey<Profile>(p => p.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // AppUser <-> Post (1-to-many)
            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.AppUser)
                .HasForeignKey(p => p.AppUserId);

            // AppUser <-> Comment (1-to-many)
            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.AppUser)
                .HasForeignKey(c => c.AppUserId);

            // Post <-> Comment (1-to-many)
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Comments)
                .WithOne(c => c.Post)
                .HasForeignKey(c => c.PostId);

            // Post <-> Media (1-to-many)
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Media)
                .WithOne(m => m.Post)
                .HasForeignKey(m => m.PostId);

            modelBuilder.Entity<AppUser>()
    .HasOne(u => u.RecruiterProfile)
    .WithOne(r => r.AppUser)
    .HasForeignKey<RecruiterProfile>(r => r.AppUserId)
    .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.JobPosts)
                .WithOne(j => j.AppUser)
                .HasForeignKey(j => j.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

        }


    }


}
