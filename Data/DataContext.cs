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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // User
            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Role)
                      .HasConversion(new EnumToStringConverter<Role>())
                      .HasDefaultValue(Role.USER);
            });
            // Courses
            modelBuilder.Entity<Courses>()
                .HasKey(c => c.Id);
            
            modelBuilder.Entity<Enrollments>()
                .HasKey(e => e.Id);
            // Quan hệ users - enrollments
            modelBuilder.Entity<Enrollments>()
                .HasOne(e => e.user)
                .WithMany(u => u.Enrollments)
                .HasForeignKey(e => e.User_id)
                .OnDelete(DeleteBehavior.Cascade);
            // Quan hệ courses - enrollments
            modelBuilder.Entity<Enrollments>()
                .HasOne(e => e.courses)
                .WithMany(c => c.Enrollments)
                .HasForeignKey(e => e.Courses_id)
                .OnDelete(DeleteBehavior.Cascade);
            base.OnModelCreating(modelBuilder);
        }
    }
}
