using backTOT.Entitys;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace backTOT.Data
{   
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }
        public DbSet<Users> Users { get; set; }
        public DbSet<Courses> Courses { get; set; }
        public DbSet<Lessons> Lessons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // primary and convert

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Role)
                      .HasConversion(new EnumToStringConverter<Role>())
                      .HasDefaultValue(Role.USER);
            });
            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Mode)
                      .HasConversion(new EnumToStringConverter<Mode>());
            });
            modelBuilder.Entity<Enrollments>().HasKey(e => e.Id);
            modelBuilder.Entity<Lessons>().HasKey(l => l.Id);
            modelBuilder.Entity<Scores>().HasKey(s => s.Id);
            modelBuilder.Entity<Schedules>().HasKey(sche => sche.Id);
            // Quan hệ enrollments - users  
            modelBuilder.Entity<Enrollments>()
                .HasOne(e => e.user)
                .WithMany(u => u.Enrollments)
                .HasForeignKey(e => e.Student_id)
                .OnDelete(DeleteBehavior.Restrict);
            // Quan hệ enrollments - courses
            modelBuilder.Entity<Enrollments>()
                .HasOne(e => e.courses)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.Courses_id)
                 .OnDelete(DeleteBehavior.Cascade);
            // Quan hệ courses - user
            modelBuilder.Entity<Courses>()
                .HasOne(c => c.user)
                .WithMany(u => u.Courses)
                .HasForeignKey(c => c.Teacher_id)
               .OnDelete(DeleteBehavior.Restrict);
            // Quan hệ courses - scores
            modelBuilder.Entity<Scores>()
                .HasOne(s => s.courses)
                .WithMany(c => c.Scores)
                .HasForeignKey(s => s.Courses_id)
                .OnDelete(DeleteBehavior.Cascade);
            // Quan hệ courses - schedules
            modelBuilder.Entity<Schedules>()
               .HasOne(sch => sch.courses)
               .WithMany(c => c.Schedules)
               .HasForeignKey(sch => sch.Courses_id)
               .OnDelete(DeleteBehavior.Cascade);
            // Quan hệ courses - lessons
            modelBuilder.Entity<Lessons>()
               .HasOne(l => l.courses)
               .WithMany(c => c.Lessons)
               .HasForeignKey(l => l.Courses_id)
               .OnDelete(DeleteBehavior.Cascade);
            // Quan hệ users - Scores
            modelBuilder.Entity<Scores>()
              .HasOne(s => s.user)
              .WithMany(u => u.Scores)
              .HasForeignKey(s => s.Student_id)
              .OnDelete(DeleteBehavior.Restrict);
            // Quan hệ schedules - lessons
            modelBuilder.Entity<Schedules>()
              .HasOne(sch => sch.lessons)
              .WithMany(l => l.Schedules)
              .HasForeignKey(sch => sch.Lessons_id)
               .OnDelete(DeleteBehavior.Restrict);
            base.OnModelCreating(modelBuilder);
        }
    }
}
