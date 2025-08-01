using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Portfolio.Core.Entities;
using Portfolio.Core.ProfileUser;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Portfolio.Infra.Data
{
    public class PortfolioContext : IdentityDbContext<AppUser, Role, Guid>
    {
        public PortfolioContext(DbContextOptions<PortfolioContext> options) : base(options) { }

        public DbSet<ProfileEntity> Profiles { get; set; }
        public DbSet<WorkExperience> WorkExperiences { get; set; }
        public DbSet<ProfessionalStack> ProfessionalStacks { get; set; }
        public DbSet<RecruiterProfile>RecruiterProfiles { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seeding roles
            var recruiterRoleId = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var developerRoleId = Guid.Parse("22222222-2222-2222-2222-222222222222");
            var adminRoleId = Guid.Parse("33333333-3333-3333-3333-333333333333");

            modelBuilder.Entity<Role>().HasData(
                new Role { Id = recruiterRoleId, Name = "Recruiter", NormalizedName = "RECRUITER" },
                new Role { Id = developerRoleId, Name = "Developer", NormalizedName = "DEVELOPER" },
                new Role { Id = adminRoleId, Name = "Admin", NormalizedName = "ADMIN" }
            );

            // AppUser <-> ProfileEntity (1-to-1)
            modelBuilder.Entity<AppUser>()
                .HasOne(a => a.Profile)
                .WithOne(p => p.AppUser)
                .HasForeignKey<ProfileEntity>(p => p.AppUserId)
                .OnDelete(DeleteBehavior.Cascade); // Only one side uses Cascade

            // Profile <-> ProfessionalStack (1-to-1)
            modelBuilder.Entity<ProfileEntity>()
      .HasOne(p => p.ProfessionalStack)
      .WithOne(ps => ps.Profile)
      .HasForeignKey<ProfessionalStack>(ps => ps.ProfileId)
      .OnDelete(DeleteBehavior.Restrict); // or Cascade


            // ProfessionalStack <-> WorkExperience (1-to-many)
            modelBuilder.Entity<WorkExperience>()
                .HasOne(w => w.ProfessionalStack)
                .WithMany(ps => ps.WorkExperiences)
                .HasForeignKey(w => w.ProfessionalStackId)
                .IsRequired();


            // AppUser <-> Post (1-to-many)
            modelBuilder.Entity<AppUser>()
                .HasMany(u => u.JobPosts)
                .WithOne(p => p.AppUser)
                .HasForeignKey(p => p.AppUserId)
                .OnDelete(DeleteBehavior.Cascade); // Allowed cascade

            // ProfileEntity <-> Posts (optional)
            modelBuilder.Entity<Post>()
                .HasOne(p => p.Profile)
                .WithMany(pe => pe.Posts)
                .HasForeignKey(p => p.ProfileId)
                .OnDelete(DeleteBehavior.Restrict);

            // ProfileEntity <-> Comments (1-to-many)
            modelBuilder.Entity<ProfileEntity>()
                .HasMany(u => u.Comments)
                .WithOne(c => c.Profile)
                .HasForeignKey(c => c.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ProfileEntity>()
                .HasMany(k => k.MediaUploads)
                .WithOne(r => r.Profile)
                .HasForeignKey(r => r.ProfileId)
                .OnDelete(DeleteBehavior.Restrict);

            //  RECRUITER PROFILE ZONE

            // AppUser <-> Recruiter (1-to-1)
            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.RecruiterProfile)
                .WithOne(r => r.AppUser)
                .HasForeignKey<RecruiterProfile>(r => r.AppUserId)
                .OnDelete(DeleteBehavior.Cascade); // Only one side uses Cascade
       


            // Media uploads <-> Recruiter
            modelBuilder.Entity<RecruiterProfile>()
                .HasMany(k => k.Media)
                .WithOne(r => r.Recruiter)
                .HasForeignKey(r => r.RecruiterId)
                .OnDelete(DeleteBehavior.Restrict);

            // Recruiter <-> JobPosts (1-to-many)
            modelBuilder.Entity<RecruiterProfile>()
                .HasMany(r => r.JobPosts)
                .WithOne(j => j.Recruiter)
                .HasForeignKey(j => j.RecruiterId)
                .OnDelete(DeleteBehavior.Restrict); //


            // Post <-> Comment (1-to-many)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Post)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Restrict); // Prevent circular cascade

            // ProfileEntity <-> Comments (optional)
            modelBuilder.Entity<Comment>()
                .HasOne(c => c.Profile)
                .WithMany(p => p.Comments)
                .HasForeignKey(c => c.ProfileId)
                .OnDelete(DeleteBehavior.Restrict);

            // Post <-> Media (1-to-many)
            modelBuilder.Entity<Post>()
                .HasMany(p => p.Media)

                .WithOne(m => m.Post)
                .HasForeignKey(m => m.PostId)
                .OnDelete(DeleteBehavior.Cascade);

            // AppUser <-> RecruiterProfile (1-to-1)
            modelBuilder.Entity<AppUser>()
                .HasOne(u => u.RecruiterProfile)
                .WithOne(r => r.AppUser)
                .HasForeignKey<RecruiterProfile>(r => r.AppUserId)
                .OnDelete(DeleteBehavior.Cascade);

            // AppUser <-> JobPosts (1-to-many)
            modelBuilder.Entity<AppUser>()
     .HasMany(u => u.JobPosts)
     .WithOne(j => j.AppUser)
     .HasForeignKey(j => j.AppUserId)
     .OnDelete(DeleteBehavior.Restrict);
            // Work experience to nullable userId
            modelBuilder.Entity<WorkExperience>()
    .HasOne(w => w.AppUser)
    .WithMany()
    .HasForeignKey(w => w.AppUserId)
    .IsRequired(false);

        }
    }
}
