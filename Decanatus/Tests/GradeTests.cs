using Decanatus.BLL.Classes;
using Decanatus.BLL.Services;
using Decanatus.BLL.Services.Implementations;
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
    internal class GradeTests
    {
        private GradeService _gradeService;
        private Mock<IRepositoryWrapper> _repoWrapper;
        private Mock<IUnitOfWork> _unitOfWork;

        [SetUp]
        public void SetUp()
        {
            _repoWrapper = new Mock<IRepositoryWrapper>();
            _unitOfWork = new Mock<IUnitOfWork>();
            _gradeService = new GradeService(_repoWrapper.Object, _unitOfWork.Object);
        }

        [Test]
        public async Task GetAllGrades_ReturnsGrades()
        {
            _repoWrapper
                .Setup(r => r.GradeRepository.GetData(It.IsAny<Expression<Func<Grade, bool>>>(), null, It.IsAny<Func<IQueryable<Grade>, IQueryable<Grade>>>(),
                It.IsAny<Func<IQueryable<Grade>, IIncludableQueryable<Grade, object>>>()))
                .ReturnsAsync(new List<Grade>().AsEnumerable());

            // Act
            var result = _gradeService.GetAllGrades();

            // Assert
            Assert.IsInstanceOf<IEnumerable<Grade>>(result);
        }

        [Test]
        public async Task GetStudentGrades_ReturnsGrades()
        {
            _repoWrapper
                .Setup(r => r.GradeRepository.GetData(It.IsAny<Expression<Func<Grade, bool>>>(), null, It.IsAny<Func<IQueryable<Grade>, IQueryable<Grade>>>(),
                It.IsAny<Func<IQueryable<Grade>, IIncludableQueryable<Grade, object>>>()))
                .ReturnsAsync(new List<Grade>().AsEnumerable());

            // Act
            var result = _gradeService.GetGradesByStudentId(Id);

            // Assert
            Assert.IsInstanceOf<IEnumerable<Grade>>(result);
        }

        //[Test]
        //public async Task GetAdministratorLessons_ReturnsLessons()
        //{
        //    _repoWrapper
        //        .Setup(r => r.LessonRepository.GetData(null, null, null, It.IsAny<Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>>>()))
        //        .ReturnsAsync(new List<Lesson>().AsEnumerable());

        //    // Act
        //    var result = await _scheduleService.GetLessonsAsync();

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.IsInstanceOf<IEnumerable<Lesson>>(result);
        //}

        //[Test]
        //public async Task FindLessonAsyncTest()
        //{
        //    // Arrange
        //    _repoWrapper
        //        .Setup(r => r.LessonRepository.GetFirstOrDefaultAsync(It.IsAny<Expression<Func<Lesson, bool>>>(), It.IsAny<Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>>>())).ReturnsAsync(lesson);


        //    // Act
        //    var result = _scheduleService.FindLessonAsync(1).Result;

        //    // Assert
        //    Assert.NotNull(result);
        //    Assert.IsInstanceOf<Lesson>(result);
        //}

        //[Test]
        //public async Task UpdateGradeAsyncTest()
        //{
        //    _repoWrapper.Setup(r => r.GradeRepository.UpdateAsync(It.IsAny<Grade>()));
        //    _repoWrapper.Setup(r => r.SaveAsync());

        //    // Act
        //    await _gradeService.UpdateGradeAsync(grade);

        //    // Assert
        //    _repoWrapper.Verify(r => r.GradeRepository.UpdateAsync(It.IsAny<Grade>()), Times.Once);
        //    _repoWrapper.Verify(r => r.SaveAsync(), Times.Once);
        //}


        private int Id => 1;
        //private EnumPeriodOfTime periodOfTime => EnumPeriodOfTime.Today;

        private Grade grade = new()
        {
            Id = 100,
            MaxAmount = 10,
            Amount = 5,
            StudentId = 1,
            GradeType = GradeType.Exam,
            SubjectId = 1,
            Description = "asd",
            Date = DateTime.Now,
        };
    }
}
