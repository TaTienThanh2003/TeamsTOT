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
        public DbSet<Sections> Sections { get; set; }
        public DbSet<User_plans> User_plans { get; set; }
        public DbSet<Lesson_notes> Lesson_notes { get; set; }
        public DbSet<Comments> Comments { get; set; }
        public DbSet<CourseOff> CourseOff { get; set; }
        public DbSet<Catalogs> Catalogs { get; set; }
        public DbSet<Topics> Topics { get; set; }
        public DbSet<Vocabularys> Vocabularys { get; set; }
        public DbSet<UserTopics> UserTopics { get; set; }
        public DbSet<UserVocabularys> UserVocabularys { get; set; }
        public DbSet<UserLesson> UserLessons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // primary and convert

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasKey(u => u.Id);
                entity.Property(u => u.Role)
                      .HasConversion(new EnumToStringConverter<Entitys.Role>())
                      .HasDefaultValue(Entitys.Role.USER);
            });
            modelBuilder.Entity<User_plans>(entity =>
            {
                entity.HasKey(up => up.Id);
                entity.Property(up => up.Status)
                      .HasConversion(new EnumToStringConverter<Status>())
                      .HasDefaultValue(Status.ACTIVE);
            });
            modelBuilder.Entity<Courses>(entity =>
            {
                entity.HasKey(c => c.Id);
                entity.Property(c => c.Mode)
             .HasConversion(new EnumToStringConverter<Entitys.Mode>()); 
            });
            modelBuilder.Entity<Lessons>(entity =>
            {
                entity.Property(e => e.Completed)
                      .HasDefaultValue(false); // Mặc định Completed = false trong DB

                entity.Property(e => e.Position)
                      .HasDefaultValue(0); // Mặc định Position = 0 trong DB
            });
            modelBuilder.Entity<Plans>(entity =>
            {
                entity.Property(p => p.TrialPeriodDays)
                      .HasDefaultValue(30); 
            });
            modelBuilder.Entity<Comments>(entity =>
            {
                entity.Property(cm => cm.Likes)
                      .HasDefaultValue(0);
                entity.Property(cm => cm.DisLikes)
                      .HasDefaultValue(0);
            });
            modelBuilder.Entity<UserVocabularys>(entity =>
            {
                entity.Property(uv => uv.IsActive)
                      .HasDefaultValue(true);
            });
            modelBuilder.Entity<UserLesson>(entity =>
            {
                entity.Property(ul => ul.IsComplete)
                      .HasDefaultValue(true); 
            });
            modelBuilder.Entity<UserTopics>(entity =>
            {
                entity.Property(ut => ut.IsComplete)
                      .HasDefaultValue(false);
            });
            modelBuilder.Entity<Enrollments>().HasKey(e => e.Id);
            modelBuilder.Entity<Lessons>().HasKey(l => l.Id);
            modelBuilder.Entity<Scores>().HasKey(s => s.Id);
            modelBuilder.Entity<Schedules>().HasKey(sche => sche.Id);
            modelBuilder.Entity<Carts>().HasKey(c => c.Id);
            modelBuilder.Entity<CourseTeachers>().HasKey(ct => ct.Id);
            modelBuilder.Entity<Reviews>().HasKey(r => r.Id);
            modelBuilder.Entity<Sections>().HasKey(se => se.Id);
            modelBuilder.Entity<User_plans>().HasKey(up => up.Id);
            modelBuilder.Entity<Lesson_notes>().HasKey(ln => ln.Id);
            modelBuilder.Entity<Comments>().HasKey(cm => cm.Id);
            modelBuilder.Entity<CourseOff>().HasKey(co => co.Id);
            modelBuilder.Entity<Catalogs>().HasKey(ctl => ctl.Id);
            modelBuilder.Entity<Topics>().HasKey(t => t.Id);
            modelBuilder.Entity<Vocabularys>().HasKey(f => f.Id);
            modelBuilder.Entity<UserTopics>().HasKey(ut => ut.Id);
            modelBuilder.Entity<UserVocabularys>().HasKey(uv => uv.Id);
            modelBuilder.Entity<UserLesson>().HasKey(ul => ul.Id);
            /////// relation

            // Quan hệ users - User_plans  
            modelBuilder.Entity<User_plans>()
               .HasOne(up => up.users)
               .WithMany(u => u.User_Plans)
               .HasForeignKey(up => up.User_id)
               .OnDelete(DeleteBehavior.Cascade);
            // Quan hệ plans - User_plans  
            modelBuilder.Entity<User_plans>()
               .HasOne(up => up.plans)
               .WithMany(p => p.User_Plans)
               .HasForeignKey(up => up.Plan_id)
               .OnDelete(DeleteBehavior.Cascade);
            // Quan hệ cart - course
            modelBuilder.Entity<Carts>()
               .HasOne(ca => ca.course)
               .WithMany(c => c.Carts)
               .HasForeignKey(c => c.Course_id)
               .OnDelete(DeleteBehavior.Cascade);
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
            // Quan hệ sections - lessons
            modelBuilder.Entity<Lessons>()
               .HasOne(l => l.sections)
               .WithMany(se => se.Lessons)
               .HasForeignKey(l => l.Section_id)
               .OnDelete(DeleteBehavior.Cascade);
            // Quan hệ sections - course
            modelBuilder.Entity<Sections>()
               .HasOne(se => se.courses)
               .WithMany(c => c.Sections)
               .HasForeignKey(l => l.Courses_id)
               .OnDelete(DeleteBehavior.Cascade);
            // Quan hệ catalog - course
            modelBuilder.Entity<Courses>()
                .HasOne(c => c.catalogs)
                .WithMany(ctl => ctl.Courses)
                .HasForeignKey(c => c.CatalogId)
                .OnDelete(DeleteBehavior.Restrict);
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
            // Quan hệ lessons - lesson_note
            modelBuilder.Entity<Lesson_notes>()
                .HasOne(ln => ln.lessons)
                .WithMany(l => l.Lesson_notes)
                .HasForeignKey(ln => ln.Lesson_id)
                .OnDelete(DeleteBehavior.Restrict);
            // Quan hệ users - lesson_note
            modelBuilder.Entity<Lesson_notes>()
                .HasOne(ln => ln.users)
                .WithMany(l => l.Lesson_notes)
                .HasForeignKey(ln => ln.User_id)
                .OnDelete(DeleteBehavior.Restrict);
            // Quan hệ users - Comments
            modelBuilder.Entity<Comments>()
                .HasOne(cm => cm.users)
                .WithMany(u => u.Comments)
                .HasForeignKey(cm => cm.User_id)
                .OnDelete(DeleteBehavior.Restrict);
            // Quan hệ lessons - Comments
            modelBuilder.Entity<Comments>()
                .HasOne(cm => cm.lessons)
                .WithMany(l => l.Comments)
                .HasForeignKey(cm => cm.Lesson_id)
                .OnDelete(DeleteBehavior.Restrict);
            // Quan hệ ParentComment - Comments
            modelBuilder.Entity<Comments>()
                .HasOne(cm => cm.ParentComment)
                .WithMany(cm => cm.Replies)
                .HasForeignKey(cm => cm.Parent_id)
                .OnDelete(DeleteBehavior.Restrict);
            // Quan hệ Coursesoff - Courses
            modelBuilder.Entity<Courses>()
                .HasOne(c => c.courseOff)
                .WithOne(co => co.courses)
                .HasForeignKey<CourseOff>(co => co.course_id)
                .OnDelete(DeleteBehavior.Restrict);
            // Quan hệ Vocabulary - Topics
            modelBuilder.Entity<Vocabularys>()
                .HasOne(f => f.topics)
                .WithMany(t => t.Vocabularys)
                .HasForeignKey(t => t.Topics_id)
                .OnDelete(DeleteBehavior.Restrict);
            // Quan hệ user - Topics
            modelBuilder.Entity<Topics>()
            .HasOne(t => t.UserCreated)
            .WithMany(u => u.TopicsCreated)
            .HasForeignKey(t => t.UsersCreated_id)
            .OnDelete(DeleteBehavior.Restrict);
            // Quan hệ UserLesson - Users
            modelBuilder.Entity<UserLesson>()
                .HasOne(ul => ul.Users)
                .WithMany(u => u.UserLessons)
                .HasForeignKey(ul => ul.Student_id)
                .OnDelete(DeleteBehavior.Cascade); // hoặc Restrict tùy bạn

            // Quan hệ UserLesson - Lessons
            modelBuilder.Entity<UserLesson>()
                .HasOne(ul => ul.Lessons)
                .WithMany(l => l.UserLessons)
                .HasForeignKey(ul => ul.LessonsId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
