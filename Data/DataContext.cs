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
        public DbSet<Scores> Scores { get; set; }
        public DbSet<Enrollments> Enrollments { get; set; }
        public DbSet<Schedules> Schedules { get; set; }
        public DbSet<Lessons> Lessons { get; set; }
        public DbSet<Carts> Carts { get; set; }
        public DbSet<CourseTeachers> CourseTeachers { get; set; }
        public DbSet<Reviews> Reviews { get; set; }
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
            modelBuilder.Entity<Carts>().HasKey(c => c.Id);
            modelBuilder.Entity<CourseTeachers>().HasKey(ct => ct.Id);
            modelBuilder.Entity<Reviews>().HasKey(r => r.Id);
            // Quan hệ Carts - course  
            modelBuilder.Entity<Carts>()
               .HasOne(ca => ca.course)  
               .WithMany(c => c.Carts)  
               .HasForeignKey(c => c.Course_id)  
               .OnDelete(DeleteBehavior.Cascade);  
            // Quan hệ Carts - user  
            modelBuilder.Entity<Carts>()
               .HasOne(ca => ca.users) 
               .WithMany(u => u.Carts)  
               .HasForeignKey(c => c.Users_id)  
               .OnDelete(DeleteBehavior.Cascade); 
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
            // Quan hệ coursesteachers - course
            modelBuilder.Entity<CourseTeachers>()
            .HasOne(ct => ct.Course)
            .WithMany(c => c.CourseTeachers)
            .HasForeignKey(ct => ct.CourseId);
            // Quan hệ coursesteachers - teacher
            modelBuilder.Entity<CourseTeachers>()
                .HasOne(ct => ct.Teacher)
                .WithMany(u => u.CourseTeachers)
                .HasForeignKey(ct => ct.TeacherId);
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
            // Quan hệ review - users
            modelBuilder.Entity<Reviews>()
            .HasOne(r => r.users)
            .WithMany(u => u.Reviews)
            .HasForeignKey(r => r.UserId)
            .OnDelete(DeleteBehavior.Restrict);
            // Quan hệ review - course
            modelBuilder.Entity<Reviews>()
                .HasOne(r => r.courses)
                .WithMany(c => c.Reviews)
                .HasForeignKey(r => r.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
