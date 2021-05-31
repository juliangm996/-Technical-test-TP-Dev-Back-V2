using Dev_Back.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Dev_Back.Api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { 
        }

        public DbSet<Classroom> Classrooms { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Classroom>(e =>
            {
                e.HasIndex(x => x.Name)
                .IsUnique();
            });

            modelBuilder.Entity<Student>(e =>
            {
                e.HasOne(x => x.Classroom)
                .WithMany(x => x.Students)
                .HasForeignKey(x => x.ClassroomId);
            });
        }

    }
}
