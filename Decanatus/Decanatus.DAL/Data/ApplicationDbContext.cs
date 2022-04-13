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
            Database.EnsureCreated();
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
            modelBuilder.Entity<Faculty>().HasData(
            new Faculty[]
                {
                    new Faculty
                    {
                        Id = 1,
                        Name = "Прикладної математики та інформатики",
                    },
                    new Faculty
                    {
                        Id = 2,
                        Name = "Електроніки та комп'ютерних технологій",
                    },

                }
                );
            modelBuilder.Entity<Speciality>().HasData(
            new Speciality[]
                {
                    new Speciality
                    {
                        Id = 1,
                        Name = "Комп'ютерні науки",
                        FacultyId = 1
                    },
                    new Speciality
                    {
                        Id = 2,
                        Name = "Біологічний",
                        FacultyId = 1
                    },
                }
                );
            modelBuilder.Entity<Group>().HasData(
            new Group[]
                {
                    new Group
                    {
                        Id = 1,
                        Name = "ПМІ-31",
                        SpecialityId = 1
                    },
                    new Group
                    {
                        Id = 2,
                        Name = "ПМІ-32",
                        SpecialityId = 1
                    },
                    new Group
                    {
                        Id = 3,
                        Name = "ПМІ-33",
                        SpecialityId = 1
                    },
                }
                );
            modelBuilder.Entity<Student>().HasData(
            new Student[]
                {
                    new Student
                    {
                        Id = 1,
                        FirstName = "firstname1",
                        LastName = "lastname1",
                        MiddleName = "middlename1",
                        Sex = Abstractions.Sex.Male,
                        BirthDate = DateTime.Parse("01.01.2021"),
                        EmailAdress = "asdasd@gmail.com",
                        MobilePhoneNumber = "393848543",
                        GradebookNumber = 123123,
                        OrderNumber = 123123,
                        OrderDate = DateTime.Parse("01.01.2021"),
                        GraduateDate = DateTime.Parse("01.01.2021"),
                        StudyingForm = StudyingForm.FullTime,
                        GroupId = 1,
                    },
                    new Student
                    {
                        Id = 2,
                        FirstName = "firstname2",
                        LastName = "lastname2",
                        MiddleName = "middlename2",
                        Sex = Abstractions.Sex.Male,
                        BirthDate = DateTime.Parse("01.01.2021"),
                        EmailAdress = "asdasd@gmail.com",
                        MobilePhoneNumber = "393848543",
                        GradebookNumber = 123123,
                        OrderNumber = 123123,
                        OrderDate = DateTime.Parse("01.01.2021"),
                        GraduateDate = DateTime.Parse("01.01.2021"),
                        StudyingForm = StudyingForm.FullTime,
                        GroupId = 1,
                    },
                    new Student
                    {
                        Id = 3,
                        FirstName = "firstname3",
                        LastName = "lastname3",
                        MiddleName = "middlename3",
                        Sex = Abstractions.Sex.Male,
                        BirthDate = DateTime.Parse("01.01.2021"),
                        EmailAdress = "asdasd@gmail.com",
                        MobilePhoneNumber = "393848543",
                        GradebookNumber = 123123,
                        OrderNumber = 123123,
                        OrderDate = DateTime.Parse("01.01.2021"),
                        GraduateDate = DateTime.Parse("01.01.2021"),
                        StudyingForm = StudyingForm.FullTime,
                        GroupId = 2,
                    },
                    new Student
                    {
                        Id = 4,
                        FirstName = "firstname4",
                        LastName = "lastname4",
                        MiddleName = "middlename4",
                        Sex = Abstractions.Sex.Male,
                        BirthDate = DateTime.Parse("01.01.2021"),
                        EmailAdress = "asdasd@gmail.com",
                        MobilePhoneNumber = "393848543",
                        GradebookNumber = 123123,
                        OrderNumber = 123123,
                        OrderDate = DateTime.Parse("01.01.2021"),
                        GraduateDate = DateTime.Parse("01.01.2021"),
                        StudyingForm = StudyingForm.FullTime,
                        GroupId = 2,
                    },
                }
                );
            modelBuilder.Entity<Lecturer>().HasData(
            new Lecturer[]
                {
                    new Lecturer
                    {
                        Id = 1,
                        FirstName = "firstname5",
                        LastName = "lastname5",
                        MiddleName = "middlename5",
                        Sex = Abstractions.Sex.Male,
                        BirthDate = DateTime.Parse("01.01.2021"),
                        EmailAdress = "asdasd@gmail.com",
                        MobilePhoneNumber = "393848543",
                        Position = Position.Assistant,
                    },
                    new Lecturer
                    {
                        Id = 2,
                        FirstName = "firstname6",
                        LastName = "lastname6",
                        MiddleName = "middlename6",
                        Sex = Abstractions.Sex.Male,
                        BirthDate = DateTime.Parse("01.01.2021"),
                        EmailAdress = "asdasd@gmail.com",
                        MobilePhoneNumber = "393848543",
                        Position = Position.Assistant,
                    },

                }
                );
            modelBuilder.Entity<Lesson>().HasData(
            new Lesson[]
                {
                    new Lesson
                    {
                        Id = 1,
                        LessonType = LessonType.Laboratory,
                        LessonWeekType = LessonWeekType.Both,
                        DayOfWeek = DayOfWeek.Monday,
                        LessonNumber = 1,
                        AudienceId = 1,
                        SubjectId = 1,
                    },
                    new Lesson
                    {
                        Id = 2,
                        LessonType = LessonType.Laboratory,
                        LessonWeekType = LessonWeekType.Both,
                        DayOfWeek = DayOfWeek.Monday,
                        LessonNumber = 2,
                        AudienceId = 1,
                        SubjectId = 2,
                    },
                }
                );
            modelBuilder.Entity<Audience>().HasData(
            new Audience[]
                {
                    new Audience
                    {
                        Id = 1,
                        Name = "301",
                    },
                    new Audience
                    {
                        Id = 2,
                        Name = "439",
                    },
                }
                );
            modelBuilder.Entity<Subject>().HasData(
            new Subject[]
                {
                    new Subject
                    {
                        Id = 1,
                        Name = "subj1",
                    },
                    new Subject
                    {
                        Id = 2,
                        Name = "subj2",
                    },
                }
                );
            modelBuilder.Entity<Grade>().HasData(
            new Grade[]
                {
                    new Grade
                    {
                        Id = 1,
                        Amount = 10,
                        StudentId = 1,
                        GradeType = GradeType.Laboratory,
                        SubjectId = 1,
                        Date = DateTime.Now,
                        Description = "asd",
                        MaxAmount = 10,
                    },
                    new Grade
                    {
                        Id = 2,
                        Amount = 10,
                        StudentId = 2,
                        GradeType = GradeType.Laboratory,
                        SubjectId = 1,
                        Date = DateTime.Now,
                        Description = "asd",
                        MaxAmount = 10,
                    },
                }
                );

            modelBuilder
            .Entity<Group>()
            .HasMany(p => p.Lessons)
            .WithMany(p => p.Groups)
            .UsingEntity(j => j.ToTable("LessonsGroups").HasData(
                    new { LessonsId = 1, GroupsId = 1 },
                    new { LessonsId = 1, GroupsId = 2 },
                    new { LessonsId = 1, GroupsId = 3 },
                    new { LessonsId = 2, GroupsId = 1 }
                ));

            modelBuilder
            .Entity<Lecturer>()
            .HasMany(p => p.Lessons)
            .WithMany(p => p.Lecturers)
            .UsingEntity(j => j.ToTable("LessonsLecturers").HasData(
                    new { LessonsId = 1, LecturersId = 1 },
                    new { LessonsId = 1, LecturersId = 2 },
                    new { LessonsId = 2, LecturersId = 2 }
                ));

            base.OnModelCreating(modelBuilder);
        }
    }
}