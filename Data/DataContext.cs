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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Users>().HasKey(u => u.Id);
            modelBuilder.Entity<Users>().Property(u => u.Role).HasConversion(new EnumToStringConverter<Role>());
            base.OnModelCreating(modelBuilder);
        }
    }
}
