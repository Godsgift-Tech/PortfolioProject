using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities;
using Portfolio.Core.ProfileUser;

namespace Portfolio.Infra.Data
{
    public class PortfolioContext : IdentityDbContext<AppUser, Role, Guid>
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options) { }

        public DbSet<ProfileEntity> Profiles { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<ProfessionalStack> ProfessionalStacks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding roles with static GUIDs
            var recruiterRoleId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var developerRoleId = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var adminRoleId = Guid.Parse("33333333-3333-3333-3333-333333333333");

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = recruiterRoleId, Name = "Recruiter", NormalizedName = "RECRUITER" },
                new Role { Id = developerRoleId, Name = "Developer", NormalizedName = "DEVELOPER" },
                new Role { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" }
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
                .HasForeignKey<ProfileEntity>(p => p.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // AppUser ↔ WorkExperiences (1-to-many)
            modelBuilder.Entity<AppUser>()
                .HasMany(a => a.WorkExperiences)
                .WithOne(w => w.AppUser)
                .HasForeignKey(w => w.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // ProfessionalStack ↔ WorkExperiences (optional link)
            modelBuilder.Entity<ProfessionalStack>()
                .HasMany(p => p.WorkExperiences)
                .WithOne()
             .OnDelete(DeleteBehavior.Restrict); // or DeleteBehavior.NoAction


           

            // AppUser ↔ Post (1-to-many)
            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.Posts)
                .WithOne(p => p.AppUser)
                .HasForeignKey(p => p.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // AppUser ↔ Comment (1-to-many)
            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.AppUser)
                .HasForeignKey(c => c.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Post ↔ Comment (1-to-many) — restrict to avoid multiple cascade paths
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Restrict); // FIXED HERE

            // Post ↔ Media (1-to-many)
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Media)
                .WithOne(m => m.Post)
                .HasForeignKey(m => m.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            // AppUser ↔ RecruiterProfile (1-to-1)
            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.RecruiterProfile)
                .WithOne(r => r.AppUser)
                .HasForeignKey<RecruiterProfile>(r => r.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // AppUser ↔ JobPosts (1-to-many)
            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.JobPosts)
                .WithOne(j => j.AppUser)
                .HasForeignKey(j => j.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }


}
