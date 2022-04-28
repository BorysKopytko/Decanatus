using Decanatus.BLL.Services.Interfaces;
using Decanatus.BLL.ViewModels;
using Decanatus.DAL.Models;
using Decanatus.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Decanatus.BLL.Services
{
    public class ScheduleService: IScheduleService
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
            var lessons = await _repositoryWrapper.LessonRepository.Includer(include);
            return lessons;
        }

        public async Task<IEnumerable<Lesson>> GetStudentLessonsAsync(string dayType)
        {

            var include = LessonsInclude();
            var lessons = await _repositoryWrapper.LessonRepository.Includer(include);
            return lessons;
        }

        public void AddNewLessonAsync(Lesson newLesson)
        {
            _repositoryWrapper.LessonRepository.UpdateAsync(newLesson);
            _unitOfWork.Commit();
        }

        public Lesson FindLessonAsync(int? id)
        {
            var include = GetInclude();
            var lesson = _repositoryWrapper.LessonRepository.Includer(include).Result.FirstOrDefault(x => x.Id == id);
            return lesson;
        }

        public LessonViewModel GetLessonViewModel(int? id)
        {
            var include = GetInclude();
            var lesson = _repositoryWrapper.LessonRepository.Includer(include).Result.FirstOrDefault(x=> x.Id== id);
            var lessonsNumbers = _repositoryWrapper.LessonNumberRepository.GetAllAsync().Result;
            var subjects = _repositoryWrapper.SubjectRepository.GetAllAsync();
            var audiences = _repositoryWrapper.AudienceRepository.GetAllAsync();
            var lecturers = _repositoryWrapper.LecturerRepository.GetAllAsync();
            var groups = _repositoryWrapper.GroupRepository.GetAllAsync();
            var lessonViewModel = new LessonViewModel() 
            {
                Lecturers = lecturers,
                Groups = groups,
                Subjects = subjects,
                LessonNumbers = lessonsNumbers,

            };
            return lessonViewModel;
        }
    }
}