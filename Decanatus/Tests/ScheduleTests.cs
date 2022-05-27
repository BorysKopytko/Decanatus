

using Decanatus.BLL.Classes;
using Decanatus.BLL.Services;
using Decanatus.DAL.Models;
using Decanatus.DAL.Repositories.Interfaces;
using Decanatus.Web.Controllers;
using Microsoft.EntityFrameworkCore.Query;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Tests
{
    [TestFixture]
    internal class ScheduleTests
    {
        private ScheduleService _scheduleService;
        private Mock<IRepositoryWrapper> _repoWrapper;
        private Mock<IUnitOfWork> _unitOfWork;
        private ScheduleController _scheduleController;

        [SetUp]
        public void SetUp()
        {
            _repoWrapper = new Mock<IRepositoryWrapper>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _scheduleService = new ScheduleService(_repoWrapper.Object, _unitOfWork.Object);
            _scheduleController = new ScheduleController(_scheduleService);
        }

        [Test]
        public async Task GetStudentLessons_ReturnsLessons()
        {
            _repoWrapper.Setup(r => r.StudentRepository.GetData(null, null, null, It.IsAny<Func<IQueryable<Student>, IIncludableQueryable<Student, object>>>()));
            _repoWrapper
                .Setup(r => r.LessonRepository.GetData(It.IsAny<Expression<Func<Lesson, bool>>>(), null, It.IsAny<Func<IQueryable<Lesson>, IQueryable<Lesson>>>(),
                It.IsAny<Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>>>()))
                .ReturnsAsync(new List<Lesson>().AsEnumerable());

            // Act
            var result = await _scheduleService.GetStudentLessonsAsync(periodOfTime, Id);

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<IEnumerable<Lesson>>(result);
        }

        [Test]
        public async Task GetLecturerLessons_ReturnsLessons()
        {
            _repoWrapper.Setup(r => r.LecturerRepository.GetData(null, null, null, It.IsAny<Func<IQueryable<Lecturer>, IIncludableQueryable<Lecturer, object>>>()));
            _repoWrapper
                .Setup(r => r.LessonRepository.GetData(It.IsAny<Expression<Func<Lesson, bool>>>(), null, It.IsAny<Func<IQueryable<Lesson>, IQueryable<Lesson>>>(),
                It.IsAny<Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>>>()))
                .ReturnsAsync(new List<Lesson>().AsEnumerable());

            // Act
            var result = await _scheduleService.GetLecturerLessonsAsync(periodOfTime, Id);

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<IEnumerable<Lesson>>(result);
        }

        [Test]
        public async Task GetAdministratorLessons_ReturnsLessons()
        {
            _repoWrapper
                .Setup(r => r.LessonRepository.GetData(null, null, null, It.IsAny<Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>>>()))
                .ReturnsAsync(new List<Lesson>().AsEnumerable());

            // Act
            var result = await _scheduleService.GetLessonsAsync();

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<IEnumerable<Lesson>>(result);
        }

        [Test]
        public async Task FindLessonAsyncTest()
        {
            // Arrange
            _repoWrapper
                .Setup(r => r.LessonRepository.GetFirstOrDefaultAsync(It.IsAny< Expression<Func<Lesson, bool>>>(),It.IsAny<Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>>>())).ReturnsAsync(lesson);


            // Act
            var result = _scheduleService.FindLessonAsync(1).Result;

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<Lesson>(result);
        }

        [Test]
        public async Task UpdateLessonAsyncTest()
        {
            // Arrange
            _repoWrapper
                .Setup(r => r.LessonRepository.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Lesson, bool>>>(), It.IsAny<Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>>>())).ReturnsAsync(lesson);


            // Act
            var result = _scheduleService.AddNewLessonAsync
                (lesson).Result;

            // Assert
            Assert.NotNull(result);
            Assert.IsInstanceOf<Lesson>(result);
        }


        private int Id => 1;
        private EnumPeriodOfTime periodOfTime => EnumPeriodOfTime.Today;

        private Lesson lesson = new ()
        {
            Id = 100,
            LessonType = LessonType.Laboratory,
            LessonWeekType = LessonWeekType.Both,
            DayOfWeek = UkrainianDayOfWeek.Tuesday,
            DayOfWeekTime = DayOfWeek.Tuesday,
            LessonNumberId = 1,
            AudienceId = 1,
            SubjectId = 1,
        };
    }
}
