using Decanatus.BLL.Classes;
using Decanatus.BLL.Services.Interfaces;
using Decanatus.DAL.Models;
using Decanatus.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Globalization;
using System.Linq.Expressions;

namespace Decanatus.BLL.Services
{
    public class ScheduleService : IScheduleService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IUnitOfWork _unitOfWork;

        public ScheduleService(IRepositoryWrapper repositoryWrapper, IUnitOfWork unitOfWork)
        {
            _repositoryWrapper = repositoryWrapper;
            _unitOfWork = unitOfWork;
        }

        private Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>> LessonsInclude()
        {
            Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>> expr = x => x.Include(i => i.Audience).Include(c => c.Subject).Include(a => a.Lecturers).Include(b => b.Groups).Include(b => b.LessonNumber);
            return expr;
        }

        public async Task<IEnumerable<Lesson>> GetLessonsAsync()
        {
            var include = LessonsInclude();
            var lessons = await _repositoryWrapper.LessonRepository.GetData(null, null, null, include);
            return lessons;
        }

        public Task<IEnumerable<Lesson>> GetStudentLessonsAsync(EnumPeriodOfTime periodType) //(DataAccessShedule.User user)
        {
            //var userId = await _userManager.GetUserIdAsync(user);

            var include = LessonsInclude();
            var filterLessons = GetLessonByPeriod(periodType);//(dayType, userId)
            var sortingLessons = OrderLessonByTime();

            var lessons = _repositoryWrapper.LessonRepository.GetData(filterLessons, null, sortingLessons, include);

            return lessons;
        }

        public void AddNewLessonAsync(Lesson newLesson)
        {
            _repositoryWrapper.LessonRepository.UpdateAsync(newLesson);
            _unitOfWork.Commit();
        }

        private Expression<Func<Lesson, bool>> GetLessonByPeriod(EnumPeriodOfTime periodOfTime) //(string periodOfTime, userId)
        {
            var startWeekNumber = DateTime.Now.Month >= 9 ?
                CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(new DateTime(DateTime.Now.Year, 9, 1), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) % 2 == 0 ? true : false
                :
                CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(new DateTime(DateTime.Now.Year - 1, 9, 1), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) % 2 == 0 ? true : false;

            var now = DateTime.Now.DayOfWeek;
            var tomorrow = DateTime.Today.AddDays(1).DayOfWeek;
            var dayAfterTomorrow = DateTime.Today.AddDays(2).DayOfWeek;
            var currentWeekNumber = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Now.Date, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday) % 2 == 0 ? true : false;

            bool evenOrOddWeek = startWeekNumber == currentWeekNumber ? true : false;

            Expression<Func<Lesson, bool>> numerator = x => x.LessonWeekType == LessonWeekType.Numerator || x.LessonWeekType == LessonWeekType.Both;
            Expression<Func<Lesson, bool>> denominator = x => x.LessonWeekType == LessonWeekType.Denominator || x.LessonWeekType == LessonWeekType.Both;
            Func<Lesson, bool> isNumerator = numerator.Compile();
            Func<Lesson, bool> isDenominator = denominator.Compile();

            Expression<Func<Lesson, bool>> searchedLessons = periodOfTime switch
            {
                EnumPeriodOfTime.Today => evenOrOddWeek switch
                {
                    true => x => x.DayOfWeek == now && (x.LessonWeekType == LessonWeekType.Numerator || x.LessonWeekType == LessonWeekType.Both),
                    false => x => x.DayOfWeek == now && (x.LessonWeekType == LessonWeekType.Denominator || x.LessonWeekType == LessonWeekType.Both)
                },

                EnumPeriodOfTime.Tomorrow => evenOrOddWeek switch
                {
                    true => x => x.DayOfWeek == tomorrow && isNumerator(x),
                    false => x => x.DayOfWeek == tomorrow && isDenominator(x)
                },

                EnumPeriodOfTime.DayAfterTomorrow => evenOrOddWeek switch
                {
                    true => x => x.DayOfWeek == dayAfterTomorrow && isNumerator(x),
                    false => x => x.DayOfWeek == dayAfterTomorrow && isDenominator(x)
                },

                EnumPeriodOfTime.OneWeek => evenOrOddWeek switch
                {
                    true => x => isNumerator(x),
                    false => x => isDenominator(x)
                },

                EnumPeriodOfTime.TwoWeek => !evenOrOddWeek switch
                {
                    true => x => isNumerator(x),
                    false => x => isDenominator(x)
                }
            };

            return searchedLessons;
        }

        private Func<IQueryable<Lesson>, IQueryable<Lesson>> OrderLessonByTime()
        {
            Func<IQueryable<Lesson>, IQueryable<Lesson>> sortedLessons = x => x.OrderBy(a => a.DayOfWeek).ThenBy(a => a.LessonNumber.Number);
            return sortedLessons;
        }
    }
}