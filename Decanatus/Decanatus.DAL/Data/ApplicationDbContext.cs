﻿using Decanatus.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

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
                });
            modelBuilder.Entity<Speciality>().HasData(
            new Speciality[]
                {
                    new Speciality
                    {
                        Id = 1,
                        Name = "Комп'ютерні науки",
                        FacultyId = 1,
                    },
                    new Speciality
                    {
                        Id = 2,
                        Name = "Прикладна математикка",
                        FacultyId = 2,
                    },
                    new Speciality
                    {
                        Id = 3,
                        Name = "Програмна інженерія",
                        FacultyId = 1,
                    },
                });
            modelBuilder.Entity<Group>().HasData(
            new Group[]
                {
                    new Group
                    {
                        Id = 1,
                        Name = "ПМІ-31",
                        SpecialityId = 1,
                    },
                    new Group
                    {
                        Id = 2,
                        Name = "ПМІ-32",
                        SpecialityId = 1,
                    },
                    new Group
                    {
                        Id = 3,
                        Name = "ПМІ-33",
                        SpecialityId = 1,
                    },
                    new Group
                    {
                        Id = 4,
                        Name = "ПМА-31",
                        SpecialityId = 2,
                    },
                    new Group
                    {
                        Id = 5,
                        Name = "ПМА-32",
                        SpecialityId = 2,
                    },
                    new Group
                    {
                        Id = 6,
                        Name = "ПМА-33",
                        SpecialityId = 2,
                    },
                });
            modelBuilder.Entity<Student>().HasData(
            new Student[]
                {
                    new Student
                    {
                        Id = 1,
                        FirstName = "Святослав",
                        LastName = "Боліщук",
                        MiddleName = "Андрійович",
                        Sex = Abstractions.Sex.Male,
                        BirthDate = DateTime.Parse("01.01.2021"),
                        EmailAdress = "asdasd@gmail.com",
                        MobilePhoneNumber = "393848543",
                        GradebookNumber = "c214c12",
                        OrderNumber = 123123,
                        OrderDate = DateTime.Parse("01.01.2021"),
                        GraduateDate = DateTime.Parse("01.01.2021"),
                        StudyingForm = StudyingForm.FullTime,
                        GroupId = 1,
                    },
                    new Student
                    {
                        Id = 2,
                        FirstName = "Борис",
                        LastName = "Копитко",
                        MiddleName = "Володимирович",
                        Sex = Abstractions.Sex.Male,
                        BirthDate = DateTime.Parse("01.01.2021"),
                        EmailAdress = "asdasd@gmail.com",
                        MobilePhoneNumber = "393848543",
                        GradebookNumber = "1234c1c21",
                        OrderNumber = 123123,
                        OrderDate = DateTime.Parse("01.01.2021"),
                        GraduateDate = DateTime.Parse("01.01.2021"),
                        StudyingForm = StudyingForm.FullTime,
                        GroupId = 1,
                    },
                    new Student
                    {
                        Id = 3,
                        FirstName = "Дмитро",
                        LastName = "Дяківський",
                        MiddleName = "Дмитрович",
                        Sex = Abstractions.Sex.Male,
                        BirthDate = DateTime.Parse("01.01.2021"),
                        EmailAdress = "asdasd@gmail.com",
                        MobilePhoneNumber = "393848543",
                        GradebookNumber = "21cr23cq",
                        OrderNumber = 123123,
                        OrderDate = DateTime.Parse("01.01.2021"),
                        GraduateDate = DateTime.Parse("01.01.2021"),
                        StudyingForm = StudyingForm.FullTime,
                        GroupId = 2,
                    },
                    new Student
                    {
                        Id = 4,
                        FirstName = "Андрій",
                        LastName = "Полянський",
                        MiddleName = "",
                        Sex = Abstractions.Sex.Male,
                        BirthDate = DateTime.Parse("01.01.2021"),
                        EmailAdress = "asdasd@gmail.com",
                        MobilePhoneNumber = "393848543",
                        GradebookNumber = "asdc23cd2",
                        OrderNumber = 123123,
                        OrderDate = DateTime.Parse("01.01.2021"),
                        GraduateDate = DateTime.Parse("01.01.2021"),
                        StudyingForm = StudyingForm.FullTime,
                        GroupId = 2,
                    },
                    new Student
                    {
                        Id = 5,
                        FirstName = "Олег",
                        LastName = "Бурдяк",
                        MiddleName = "Володимирович",
                        Sex = Abstractions.Sex.Male,
                        BirthDate = DateTime.Parse("01.01.2021"),
                        EmailAdress = "asdasd@gmail.com",
                        MobilePhoneNumber = "393848543",
                        GradebookNumber = "ac2r32r43c",
                        OrderNumber = 123123,
                        OrderDate = DateTime.Parse("01.01.2021"),
                        GraduateDate = DateTime.Parse("01.01.2021"),
                        StudyingForm = StudyingForm.FullTime,
                        GroupId = 2,
                    },
                });
            modelBuilder.Entity<Lecturer>().HasData(
            new Lecturer[]
                {
                    new Lecturer
                    {
                        Id = 1,
                        FirstName = "Юрій",
                        LastName = "Щербина",
                        MiddleName = "Миколайович",
                        Sex = Abstractions.Sex.Male,
                        BirthDate = DateTime.Parse("01.01.2021"),
                        EmailAdress = "asdasd@gmail.com",
                        MobilePhoneNumber = "393848543",
                        Position = Position.Professor,
                    },
                    new Lecturer
                    {
                        Id = 2,
                        FirstName = "Анатолій",
                        LastName = "Музичук",
                        MiddleName = "Омелянович",
                        Sex = Abstractions.Sex.Male,
                        BirthDate = DateTime.Parse("01.01.2021"),
                        EmailAdress = "asdasd@gmail.com",
                        MobilePhoneNumber = "393848543",
                        Position = Position.Professor,
                    },
                    new Lecturer
                    {
                        Id = 3,
                        FirstName = "Андрій",
                        LastName = "Глова",
                        MiddleName = "Романович",
                        Sex = Abstractions.Sex.Male,
                        BirthDate = DateTime.Parse("01.01.2021"),
                        EmailAdress = "asdasd@gmail.com",
                        MobilePhoneNumber = "393848543",
                        Position = Position.Assistant,
                    },
                    new Lecturer
                    {
                        Id = 4,
                        FirstName = "Святослав",
                        LastName = "Тарасюк",
                        MiddleName = "Іванович",
                        Sex = Abstractions.Sex.Male,
                        BirthDate = DateTime.Parse("01.01.2021"),
                        EmailAdress = "asdasd@gmail.com",
                        MobilePhoneNumber = "393848543",
                        Position = Position.Professor,
                    },
                });
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
                    new Lesson
                    {
                        Id = 3,
                        LessonType = LessonType.Laboratory,
                        LessonWeekType = LessonWeekType.Both,
                        DayOfWeek = DayOfWeek.Monday,
                        LessonNumber = 3,
                        AudienceId = 1,
                        SubjectId = 3,
                    },
                    new Lesson
                    {
                        Id = 4,
                        LessonType = LessonType.Laboratory,
                        LessonWeekType = LessonWeekType.Both,
                        DayOfWeek = DayOfWeek.Tuesday,
                        LessonNumber = 1,
                        AudienceId = 2,
                        SubjectId = 2,
                    },
                    new Lesson
                    {
                        Id = 5,
                        LessonType = LessonType.Laboratory,
                        LessonWeekType = LessonWeekType.Both,
                        DayOfWeek = DayOfWeek.Tuesday,
                        LessonNumber = 2,
                        AudienceId = 3,
                        SubjectId = 3,
                    },
                });
            modelBuilder.Entity<Audience>().HasData(
            new Audience[]
                {
                    new Audience
                    {
                        Id = 1,
                        Name = "111",
                    },
                    new Audience
                    {
                        Id = 2,
                        Name = "439",
                    },
                    new Audience
                    {
                        Id = 3,
                        Name = "109",
                    },
                    new Audience
                    {
                        Id = 4,
                        Name = "145",
                    },
                });
            modelBuilder.Entity<Subject>().HasData(
            new Subject[]
                {
                    new Subject
                    {
                        Id = 1,
                        Name = "Програмна інженерія",
                    },
                    new Subject
                    {
                        Id = 2,
                        Name = "Математичний аналіз",
                    },
                    new Subject
                    {
                        Id = 3,
                        Name = "Дискретна математика",
                    },
                });
            modelBuilder.Entity<Grade>().HasData(
            new Grade[]
                {
                    new Grade
                    {
                        Id = 1,
                        Amount = 6,
                        StudentId = 1,
                        GradeType = GradeType.Module,
                        SubjectId = 1,
                        Date = DateTime.Now,
                        Description = "asd",
                        MaxAmount = 10,
                    },
                    new Grade
                    {
                        Id = 2,
                        Amount = 8,
                        StudentId = 2,
                        GradeType = GradeType.Module,
                        SubjectId = 1,
                        Date = DateTime.Now,
                        Description = "asd",
                        MaxAmount = 10,
                    },
                    new Grade
                    {
                        Id = 3,
                        Amount = 9,
                        StudentId = 3,
                        GradeType = GradeType.Module,
                        SubjectId = 1,
                        Date = DateTime.Now,
                        Description = "asd",
                        MaxAmount = 10,
                    },
                    new Grade
                    {
                        Id = 4,
                        Amount = 4,
                        StudentId = 4,
                        GradeType = GradeType.Module,
                        SubjectId = 1,
                        Date = DateTime.Now,
                        Description = "asd",
                        MaxAmount = 10,
                    },
                    new Grade
                    {
                        Id = 5,
                        Amount = 5,
                        StudentId = 5,
                        GradeType = GradeType.Module,
                        SubjectId = 1,
                        Date = DateTime.Now,
                        Description = "asd",
                        MaxAmount = 10,
                    },
                });

            modelBuilder
            .Entity<Group>()
            .HasMany(p => p.Lessons)
            .WithMany(p => p.Groups)
            .UsingEntity(j => j.ToTable("LessonsGroups").HasData(
                    new { LessonsId = 1, GroupsId = 1 },
                    new { LessonsId = 1, GroupsId = 2 },
                    new { LessonsId = 1, GroupsId = 3 },
                    new { LessonsId = 2, GroupsId = 1 },
                    new { LessonsId = 3, GroupsId = 2 },
                    new { LessonsId = 4, GroupsId = 3 },
                    new { LessonsId = 5, GroupsId = 5 },
                    new { LessonsId = 4, GroupsId = 4 },
                    new { LessonsId = 5, GroupsId = 6 }));

            modelBuilder
            .Entity<Lecturer>()
            .HasMany(p => p.Lessons)
            .WithMany(p => p.Lecturers)
            .UsingEntity(j => j.ToTable("LessonsLecturers").HasData(
                    new { LessonsId = 1, LecturersId = 1 },
                    new { LessonsId = 2, LecturersId = 3 },
                    new { LessonsId = 2, LecturersId = 2 },
                    new { LessonsId = 3, LecturersId = 3 },
                    new { LessonsId = 3, LecturersId = 2 },
                    new { LessonsId = 4, LecturersId = 4 },
                    new { LessonsId = 5, LecturersId = 4 }));

            base.OnModelCreating(modelBuilder);
        }
    }
}