using Microsoft.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Common;
using SchoolManagementSystem.Domain.Entities;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using SchoolManagementSystem.Domain.Enums;
using SchoolManagementSystem.Infrastructure;

namespace SchoolManagementSystem.Infrastructure.Data
{
    public class ApplicationDbContext : IdentityDbContext<SchoolManagementSystem.Domain.Entities.ApplicationUser>, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSets for all entities
        public DbSet<User> Users { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<Grade> Grades { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Student entity
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.StudentId).IsRequired().HasMaxLength(20);
                entity.Property(s => s.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(s => s.LastName).IsRequired().HasMaxLength(50);
                entity.Property(s => s.DateOfBirth).IsRequired();
                entity.HasIndex(s => s.StudentId).IsUnique();
            });

            // Configure Teacher entity
            modelBuilder.Entity<Teacher>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(t => t.LastName).IsRequired().HasMaxLength(50);
                entity.Property(t => t.Specialization).HasMaxLength(100);
                entity.Property(t => t.Email).IsRequired().HasMaxLength(100);
            });

            // Configure Subject entity
            modelBuilder.Entity<Subject>(entity =>
            {
                entity.HasKey(s => s.Id);
                entity.Property(s => s.Name).IsRequired().HasMaxLength(100);
                entity.Property(s => s.Description).HasMaxLength(500);

                // Relationship with Teacher
                entity.HasOne(s => s.Teacher)
                    .WithMany(t => t.Subjects)
                    .HasForeignKey(s => s.TeacherId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure Class entity
            modelBuilder.Entity<Class>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Name).IsRequired().HasMaxLength(50);
                entity.Property(c => c.RoomNumber).HasMaxLength(20);
            });

            // Configure Schedule entity
            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(s => s.Id);

                // Relationship with Subject
                entity.HasOne(s => s.Subject)
                    .WithMany(s => s.Schedules)
                    .HasForeignKey(s => s.SubjectId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relationship with Class
                entity.HasOne(s => s.Class)
                    .WithMany(c => c.Schedules)
                    .HasForeignKey(s => s.ClassId)
                    .OnDelete(DeleteBehavior.Cascade);

                entity.Property(s => s.DayOfWeek).IsRequired();
                entity.Property(s => s.StartTime).IsRequired();
                entity.Property(s => s.EndTime).IsRequired();
            });

            // Configure Grade entity
            modelBuilder.Entity<Grade>(entity =>
            {
                entity.HasKey(g => g.Id);
                entity.Property(g => g.Score).HasColumnType("decimal(5,2)");
                entity.Property(g => g.Date).IsRequired();

                // Relationship with Student
                entity.HasOne(g => g.Student)
                    .WithMany(s => s.Grades)
                    .HasForeignKey(g => g.StudentId)
                    .OnDelete(DeleteBehavior.Cascade);

                // Relationship with Subject
                entity.HasOne(g => g.Subject)
                    .WithMany()
                    .HasForeignKey(g => g.SubjectId)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            // Configure User entity (if using Identity, this would be different)
            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.FirstName).IsRequired().HasMaxLength(50);
                entity.Property(u => u.LastName).IsRequired().HasMaxLength(50);
                entity.Property(u => u.Email).IsRequired().HasMaxLength(100);
                entity.Property(u => u.PasswordHash).IsRequired();
                entity.Property(u => u.Role).IsRequired();
                entity.HasIndex(u => u.Email).IsUnique();
            });
        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            // You can add domain events dispatching here if needed
            return await base.SaveChangesAsync(cancellationToken);
        }

        // Explicit implementation of IUnitOfWork
        async Task<int> IUnitOfWork.SaveChangesAsync()
        {
            return await SaveChangesAsync();
        }
    }
}