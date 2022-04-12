using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Decanatus.DAL.Models;

namespace Decanatus.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Speciality> Specialities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }

        public DbSet<Lecturer> Lecturers { get; set; }
        public DbSet<Lesson> Lessons { get; set; }
        public DbSet<Subject> Subjects { get; set; }
        public DbSet<Grade> Grades { get; set; }
        public DbSet<Audience> Audiences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //modelBuilder
            //.Entity<Group>()
            //.HasMany(p => p.Lessons)
            //.WithMany(p => p.Groups)
            //.UsingEntity(j => j.ToTable("LessonsGroups"));

            //modelBuilder
            //.Entity<Lecturer>()
            //.HasMany(p => p.Lessons)
            //.WithMany(p => p.Lecturers)
            //.UsingEntity(j => j.ToTable("LessonsLecturers"));

            modelBuilder.Entity<Faculty>().HasData(
            new Faculty[]
                {
                    new Faculty
                    {
                        Name = "Прикладної математики та інформатики"
                    },
                    new Faculty
                    {
                        Name = "Електроніки та комп'ютерних технологій"
                    }

                }
                );
            modelBuilder.Entity<Speciality>().HasData(
            new Speciality[]
                {
                    new Speciality
                    {
                        Name = "Комп'ютерні науки",



                    },
                    new Speciality
                    {
                        Name = "Біологічний"
                    }

                }
                );
            base.OnModelCreating(modelBuilder);
        }
    }
}