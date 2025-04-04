using System.Text.RegularExpressions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Group = Domain.Entities.Group;

namespace Infrastructure.Data;

public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
{
    public DbSet<Student> Students { get; set; }
    public DbSet<Group> Groups { get; set; }
    public DbSet<Address> Addresses { get; set; }
    public DbSet<StudentGroup> StudentGroups { get; set; }
    public DbSet<Course> Courses { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<StudentGroup>().HasKey(sg => new { sg.StudentId, sg.GroupId });

        modelBuilder.Entity<Course>()
            .HasMany(c => c.Groups)
            .WithOne(g => g.Course)
            .HasForeignKey(g => g.CourseId);
        
        modelBuilder.Entity<Address>()
            .HasOne(a => a.Student)
            .WithOne(s => s.Address)
            .HasForeignKey<Address>(a => a.StudentId);

        modelBuilder.Entity<StudentGroup>()
            .HasOne(sg => sg.Group)
            .WithMany(g => g.StudentGroups)
            .HasForeignKey(sg => sg.GroupId);

        modelBuilder.Entity<StudentGroup>()
            .HasOne(sg => sg.Student)
            .WithMany(s => s.StudentGroups)
            .HasForeignKey(sg => sg.StudentId);
        
        modelBuilder.Entity<Student>().HasData(
            new Student { Id = 1, FirstName = "Алексей"},
            new Student { Id = 2, FirstName= "Ирина" }
        );
    }
}