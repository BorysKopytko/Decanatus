using Decanatus.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Decanatus.DAL.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, string>
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

        public DbSet<LessonNumber> LessonNumbers { get; set; }

        public DbSet<Administrator> Administrators { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LessonNumber>().HasData(
            new LessonNumber[]
                {
                    new LessonNumber
                    {
                        Id = 1,
                        Number = 1,
                        StartTime = TimeSpan.Parse("8:30"),
                        EndTime = TimeSpan.Parse("9:50"),
                    },
                    new LessonNumber
                    {
                        Id = 2,
                        Number = 2,
                        StartTime = TimeSpan.Parse("10:10"),
                        EndTime = TimeSpan.Parse("11:30"),
                    },
                    new LessonNumber
                    {
                        Id = 3,
                        Number = 3,
                        StartTime = TimeSpan.Parse("11:50"),
                        EndTime = TimeSpan.Parse("13:10"),
                    },
                    new LessonNumber
                    {
                        Id = 4,
                        Number = 4,
                        StartTime = TimeSpan.Parse("13:30"),
                        EndTime = TimeSpan.Parse("14:50"),
                    },
                    new LessonNumber
                    {
                        Id = 5,
                        Number = 5,
                        StartTime = TimeSpan.Parse("15:05"),
                        EndTime = TimeSpan.Parse("16:25"),
                    },
                    new LessonNumber
                    {
                        Id = 6,
                        Number = 6,
                        StartTime = TimeSpan.Parse("16:40"),
                        EndTime = TimeSpan.Parse("18:00"),
                    },
                    new LessonNumber
                    {
                        Id = 7,
                        Number = 7,
                        StartTime = TimeSpan.Parse("18:10"),
                        EndTime = TimeSpan.Parse("19:30"),
                    },
                });
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
                        Name = "Прикладна математика",
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
                        GroupId = 2,
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
                        GroupId = 4,
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
                        GroupId = 5,
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
                        GroupId = 6,
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
                        DayOfWeek = UkrainianDayOfWeek.Friday,
                        DayOfWeekTime = DayOfWeek.Friday,
                        LessonNumberId = 1,
                        AudienceId = 1,
                        SubjectId = 1,
                    },
                    new Lesson
                    {
                        Id = 2,
                        LessonType = LessonType.Laboratory,
                        LessonWeekType = LessonWeekType.Denominator,
                        DayOfWeek = UkrainianDayOfWeek.Monday,
                        DayOfWeekTime = DayOfWeek.Monday,
                        LessonNumberId = 2,
                        AudienceId = 1,
                        SubjectId = 2,
                    },
                    new Lesson
                    {
                        Id = 3,
                        LessonType = LessonType.Laboratory,
                        LessonWeekType = LessonWeekType.Denominator,
                        DayOfWeek = UkrainianDayOfWeek.Friday,
                        LessonNumberId = 3,
                        DayOfWeekTime = DayOfWeek.Friday,
                        AudienceId = 1,
                        SubjectId = 3,
                    },
                    new Lesson
                    {
                        Id = 4,
                        LessonType = LessonType.Laboratory,
                        LessonWeekType = LessonWeekType.Numerator,
                        DayOfWeek = UkrainianDayOfWeek.Friday,
                        LessonNumberId = 1,
                        DayOfWeekTime = DayOfWeek.Friday,
                        AudienceId = 2,
                        SubjectId = 1,
                    },
                    new Lesson
                    {
                        Id = 5,
                        LessonType = LessonType.Laboratory,
                        LessonWeekType = LessonWeekType.Both,
                        DayOfWeek = UkrainianDayOfWeek.Tuesday,
                        LessonNumberId = 2,
                        DayOfWeekTime = DayOfWeek.Tuesday,
                        AudienceId = 3,
                        SubjectId = 2,
                    },
                    new Lesson
                    {
                        Id = 6,
                        LessonType = LessonType.Laboratory,
                        LessonWeekType = LessonWeekType.Both,
                        DayOfWeek = UkrainianDayOfWeek.Thursday,
                        LessonNumberId = 7,
                        DayOfWeekTime = DayOfWeek.Thursday,
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
                        Date = DateTime.Parse("2021-03-21 13:26"),
                        Description = "asd",
                        MaxAmount = 10,
                    },
                    new Grade
                    {
                        Id = 2,
                        Amount = 8,
                        StudentId = 1,
                        GradeType = GradeType.Practice,
                        SubjectId = 1,
                        Date = DateTime.Parse("2022-03-21 13:26"),
                        Description = "asd",
                        MaxAmount = 10,
                    },
                    new Grade
                    {
                        Id = 3,
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
                        Id = 4,
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
                        Id = 5,
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
                        Id = 6,
                        Amount = 5,
                        StudentId = 5,
                        GradeType = GradeType.Module,
                        SubjectId = 1,
                        Date = DateTime.Now,
                        Description = "asd",
                        MaxAmount = 10,
                    },
                });

            //modelBuilder
            //.Entity<Group>()
            //.HasMany(p => p.Lessons)
            //.WithMany(p => p.Groups)
            //.UsingEntity(j => j.ToTable("LessonGroups").HasData(
            //        new { Id = 1, LessonId = 1, GroupId = 1 },
            //        new { Id = 2, LessonId = 1, GroupId = 2 },
            //        new { Id = 3, LessonId = 1, GroupId = 3 },
            //        new { Id = 4, LessonId = 2, GroupId = 1 },
            //        new { Id = 5, LessonId = 3, GroupId = 2 },
            //        new { Id = 6, LessonId = 4, GroupId = 3 },
            //        new { Id = 7, LessonId = 5, GroupId = 5 },
            //        new { Id = 8, LessonId = 4, GroupId = 4 },
            //        new { Id = 9, LessonId = 5, GroupId = 6 },
            //        new { Id = 10, LessonId = 6, GroupId = 1 }));

            modelBuilder.Entity<Lesson>()
            .HasMany(p => p.Groups)
            .WithMany(p => p.Lessons)
            .UsingEntity<LessonGroup>(
                j => j
                    .HasOne(pt => pt.Group)
                    .WithMany(t => t.LessonGroups)
                    .HasForeignKey(pt => pt.GroupId),
                j => j
                    .HasOne(pt => pt.Lesson)
                    .WithMany(p => p.LessonGroups)
                    .HasForeignKey(pt => pt.LessonId),
                j =>
                {
                    j.HasKey(t => new { t.LessonId, t.GroupId });
                });

            modelBuilder.Entity<LessonGroup>().HasData(
                    new { Id = 1, LessonId = 1, GroupId = 1 },
                    new { Id = 2, LessonId = 1, GroupId = 2 },
                    new { Id = 3, LessonId = 1, GroupId = 3 },
                    new { Id = 4, LessonId = 2, GroupId = 1 },
                    new { Id = 5, LessonId = 3, GroupId = 2 },
                    new { Id = 6, LessonId = 4, GroupId = 3 },
                    new { Id = 7, LessonId = 5, GroupId = 5 },
                    new { Id = 8, LessonId = 4, GroupId = 4 },
                    new { Id = 9, LessonId = 5, GroupId = 6 },
                    new { Id = 10, LessonId = 6, GroupId = 1 });

            modelBuilder.Entity<Lesson>()
            .HasMany(p => p.Lecturers)
            .WithMany(p => p.Lessons)
            .UsingEntity<LessonLecturer>(
                j => j
                    .HasOne(pt => pt.Lecturer)
                    .WithMany(t => t.LessonLecturers)
                    .HasForeignKey(pt => pt.LecturerId),
                j => j
                    .HasOne(pt => pt.Lesson)
                    .WithMany(p => p.LessonLecturers)
                    .HasForeignKey(pt => pt.LessonId),
                j =>
                {
                    j.HasKey(t => new { t.LessonId, t.LecturerId });
                });



            modelBuilder.Entity<LessonLecturer>().HasData(
                    new { Id = 1, LessonId = 1, LecturerId = 1 },
                    new { Id = 2, LessonId = 2, LecturerId = 3 },
                    new { Id = 3, LessonId = 2, LecturerId = 2 },
                    new { Id = 4, LessonId = 3, LecturerId = 3 },
                    new { Id = 5, LessonId = 3, LecturerId = 2 },
                    new { Id = 6, LessonId = 4, LecturerId = 4 },
                    new { Id = 7, LessonId = 5, LecturerId = 4 },
                    new { Id = 8, LessonId = 6, LecturerId = 4 });



            //modelBuilder
            //.Entity<Lecturer>()
            //.HasMany(p => p.Lessons)
            //.WithMany(p => p.Lecturers)
            //.UsingEntity(j => j.ToTable("LessonsLecturers").HasData(
            //        new { LessonsId = 1, LecturersId = 1 },
            //        new { LessonsId = 2, LecturersId = 3 },
            //        new { LessonsId = 2, LecturersId = 2 },
            //        new { LessonsId = 3, LecturersId = 3 },
            //        new { LessonsId = 3, LecturersId = 2 },
            //        new { LessonsId = 4, LecturersId = 4 },
            //        new { LessonsId = 5, LecturersId = 4 },
            //        new { LessonsId = 6, LecturersId = 4 }));


            base.OnModelCreating(modelBuilder);
        }
    }
}