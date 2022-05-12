using AutoMapper;
using Decanatus.BLL.Classes;
using Decanatus.BLL.Services.Interfaces;
using Decanatus.BLL.ViewModels;
using Decanatus.DAL.Models;
using Decanatus.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Collections.ObjectModel;
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
            Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>> expr = x => x.Include(i => i.Audience).Include(c => c.Subject).Include(a => a.Lecturers).Include(b => b.Groups).Include(b => b.LessonNumber).Include(k => k.LessonGroups).Include(k => k.LessonLecturers);
            return expr;
        }

        public async Task<IEnumerable<Lesson>> GetLessonsAsync()
        {
            var include = LessonsInclude();
            var lessons = _repositoryWrapper.LessonRepository.GetData(null, null, null, include).Result.OrderByDescending(x => x.CreationDateTime);

            return lessons;
        }

        public Task<IEnumerable<Lesson>> GetStudentLessonsAsync(EnumPeriodOfTime periodType) 
        {
            var include = LessonsInclude();
            var filterLessons = GetLessonByPeriod(periodType);
            var sortingLessons = OrderLessonByTime();

            var lessons = _repositoryWrapper.LessonRepository.GetData(filterLessons, null, sortingLessons, include);

            return lessons;
        }

        public void AddNewLessonAsync(Lesson newLesson)
        {
            _repositoryWrapper.LessonRepository.UpdateAsync(newLesson);
            _unitOfWork.Commit();
        }

        private Expression<Func<Lesson, bool>> GetLessonByPeriod(EnumPeriodOfTime periodOfTime) 
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
                    true => x => x.DayOfWeekTime == now && (x.LessonWeekType == LessonWeekType.Numerator || x.LessonWeekType == LessonWeekType.Both),
                    false => x => x.DayOfWeekTime == now && (x.LessonWeekType == LessonWeekType.Denominator || x.LessonWeekType == LessonWeekType.Both)
                },

                EnumPeriodOfTime.Tomorrow => evenOrOddWeek switch
                {
                    true => x => x.DayOfWeekTime == tomorrow && isNumerator(x),
                    false => x => x.DayOfWeekTime == tomorrow && isDenominator(x)
                },

                EnumPeriodOfTime.DayAfterTomorrow => evenOrOddWeek switch
                {
                    true => x => x.DayOfWeekTime == dayAfterTomorrow && isNumerator(x),
                    false => x => x.DayOfWeekTime == dayAfterTomorrow && isDenominator(x)
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
            Func<IQueryable<Lesson>, IQueryable<Lesson>> sortedLessons = x => x.OrderBy(a => a.DayOfWeekTime).ThenBy(a => a.LessonNumber.Number);
            return sortedLessons;
        }

        public Lesson FindLessonAsync(int? id)
        {
            var include = LessonsInclude();
            var lesson = _repositoryWrapper.LessonRepository.GetData(null, null, null, include).Result.FirstOrDefault(x => x.Id == id);
            return lesson;
        }

        public LessonViewModel CreateLessonViewModel()
        {
            var lessonViewModel = new LessonViewModel();

            var subjects = _repositoryWrapper.SubjectRepository.GetAllAsync().Result;
            var audiences = _repositoryWrapper.AudienceRepository.GetAllAsync().Result;
            var lecturers = _repositoryWrapper.LecturerRepository.GetAllAsync().Result;
            var groups = _repositoryWrapper.GroupRepository.GetAllAsync().Result;

            lessonViewModel.AllLessonNumbers = _repositoryWrapper.LessonNumberRepository.GetAllAsync().Result.Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Number.ToString() }).ToList();
            lessonViewModel.AllSubjects = _repositoryWrapper.SubjectRepository.GetAllAsync().Result.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList();
            lessonViewModel.AllAudiences = _repositoryWrapper.AudienceRepository.GetAllAsync().Result.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList();
            lessonViewModel.AllLecturers = _repositoryWrapper.LecturerRepository.GetAllAsync().Result.Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.LastName + " " + l.FirstName + " " + l.MiddleName + " " + "(" + l.Position.GetDisplayName() + ")" }).ToList();
            lessonViewModel.AllGroups = _repositoryWrapper.GroupRepository.GetAllAsync().Result.Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name }).ToList();

            return lessonViewModel;
        }

        public async Task<bool> DeleteLessonAsync(int? id)
        {
            var lesson = FindLessonAsync(id);
            await _repositoryWrapper.LessonRepository.DeleteAsync(lesson);
            await _unitOfWork.Commit();

            return true;
        }

        public LessonViewModel GetLessonViewModel(int? id)
        {
            var lessonViewModel = new LessonViewModel();

            var include = LessonsInclude();
            var lesson = _repositoryWrapper.LessonRepository.GetData(null, null, null, include).Result.FirstOrDefault(x => x.Id == id);

            lessonViewModel.Id = lesson.Id;
            lessonViewModel.LessonNumber = lesson.LessonNumberId;
            lessonViewModel.LessonType = lesson.LessonType;
            lessonViewModel.Audience = lesson.AudienceId;
            lessonViewModel.DayOfWeek = lesson.DayOfWeek;

            lessonViewModel.LessonWeekType = lesson.LessonWeekType;
            lessonViewModel.Subject = lesson.SubjectId;
            lessonViewModel.Groups = lesson.Groups.Select(g => g.Id);
            lessonViewModel.Lecturers = lesson.Lecturers.Select(l => l.Id);
            lessonViewModel.CreationDateTime = lesson.CreationDateTime;

            var subjects = _repositoryWrapper.SubjectRepository.GetAllAsync().Result;
            var audiences = _repositoryWrapper.AudienceRepository.GetAllAsync().Result;
            var lecturers = _repositoryWrapper.LecturerRepository.GetAllAsync().Result;
            var groups = _repositoryWrapper.GroupRepository.GetAllAsync().Result;

            lessonViewModel.AllLessonNumbers = _repositoryWrapper.LessonNumberRepository.GetAllAsync().Result.Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.Number.ToString() }).ToList();
            lessonViewModel.AllSubjects = _repositoryWrapper.SubjectRepository.GetAllAsync().Result.Select(s => new SelectListItem { Value = s.Id.ToString(), Text = s.Name }).ToList();
            lessonViewModel.AllAudiences = _repositoryWrapper.AudienceRepository.GetAllAsync().Result.Select(a => new SelectListItem { Value = a.Id.ToString(), Text = a.Name }).ToList();
            lessonViewModel.AllLecturers = _repositoryWrapper.LecturerRepository.GetAllAsync().Result.Select(l => new SelectListItem { Value = l.Id.ToString(), Text = l.LastName + " " + l.FirstName + " " + l.MiddleName + " " + "(" + l.Position.GetDisplayName() + ")" }).ToList();
            lessonViewModel.AllGroups = _repositoryWrapper.GroupRepository.GetAllAsync().Result.Select(g => new SelectListItem { Value = g.Id.ToString(), Text = g.Name }).ToList();

            return lessonViewModel;
        }

        public async Task<bool> UpdateLessonAsync(LessonViewModel lessonViewModel)
        {
            var include = LessonsInclude();
            var preLesson = _repositoryWrapper.LessonRepository.GetData(null, null, null, include).Result.FirstOrDefault(x => x.Id == lessonViewModel.Id);

            var lesson = new Lesson();

            await _repositoryWrapper.LessonRepository.DeleteAsync(preLesson);
            await _unitOfWork.Commit();

            lesson.LessonType = lessonViewModel.LessonType;
            lesson.LessonWeekType = lessonViewModel.LessonWeekType;
            lesson.DayOfWeek = lessonViewModel.DayOfWeek;

            lesson.LessonNumber = _repositoryWrapper.LessonNumberRepository.GetByIdAsync(lessonViewModel.LessonNumber).Result;
            lesson.Audience = _repositoryWrapper.AudienceRepository.GetByIdAsync(lessonViewModel.Audience).Result;
            lesson.Subject = _repositoryWrapper.SubjectRepository.GetByIdAsync(lessonViewModel.Subject).Result;
            lesson.LessonNumberId = lessonViewModel.LessonNumber;
            lesson.AudienceId = _repositoryWrapper.AudienceRepository.GetByIdAsync(lessonViewModel.Audience).Result.Id;
            lesson.SubjectId = _repositoryWrapper.SubjectRepository.GetByIdAsync(lessonViewModel.Subject).Result.Id;
            lesson.Lecturers = new Collection<Lecturer>();
            lesson.Groups = new Collection<Group>();
            lesson.LessonGroups = new Collection<LessonGroup>();
            lesson.LessonLecturers = new Collection<LessonLecturer>();
            lesson.CreationDateTime = lessonViewModel.CreationDateTime;

            foreach (var lecturer in lessonViewModel.Lecturers)
            {
                lesson.Lecturers.Add(_repositoryWrapper.LecturerRepository.GetByIdAsync(lecturer).Result);
            }

            foreach (var group in lessonViewModel.Groups)
            {
                lesson.Groups.Add(_repositoryWrapper.GroupRepository.GetByIdAsync(group).Result);
            }

            await _repositoryWrapper.LessonRepository.AddAsync(lesson);
            await _unitOfWork.Commit();

            return true;
        }

        public async Task<bool> CreateLessonAsync(LessonViewModel lessonViewModel)
        {
            var lesson = new Lesson();

            lesson.LessonType = lessonViewModel.LessonType;
            lesson.LessonWeekType = lessonViewModel.LessonWeekType;
            lesson.DayOfWeek = lessonViewModel.DayOfWeek;

            lesson.LessonNumber = _repositoryWrapper.LessonNumberRepository.GetByIdAsync(lessonViewModel.LessonNumber).Result;
            lesson.Audience = _repositoryWrapper.AudienceRepository.GetByIdAsync(lessonViewModel.Audience).Result;
            lesson.Subject = _repositoryWrapper.SubjectRepository.GetByIdAsync(lessonViewModel.Subject).Result;
            lesson.LessonNumberId = lessonViewModel.LessonNumber;
            lesson.AudienceId = _repositoryWrapper.AudienceRepository.GetByIdAsync(lessonViewModel.Audience).Result.Id;
            lesson.SubjectId = _repositoryWrapper.SubjectRepository.GetByIdAsync(lessonViewModel.Subject).Result.Id;
            lesson.Lecturers = new Collection<Lecturer>();
            lesson.Groups = new Collection<Group>();
            lesson.LessonGroups = new Collection<LessonGroup>();
            lesson.LessonLecturers = new Collection<LessonLecturer>();

            foreach (var lecturer in lessonViewModel.Lecturers)
            {
                lesson.Lecturers.Add(_repositoryWrapper.LecturerRepository.GetByIdAsync(lecturer).Result);
            }

            foreach (var group in lessonViewModel.Groups)
            {
                lesson.Groups.Add(_repositoryWrapper.GroupRepository.GetByIdAsync(group).Result);
            }

            await _repositoryWrapper.LessonRepository.AddAsync(lesson);
            await _unitOfWork.Commit();

            return true;
        }
    }
}