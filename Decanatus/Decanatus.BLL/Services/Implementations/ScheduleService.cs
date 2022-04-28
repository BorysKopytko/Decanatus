using Decanatus.BLL.Services.Interfaces;
using Decanatus.DAL.Models;
using Decanatus.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Decanatus.BLL.Services
{
    public class ScheduleService: IScheduleService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        private Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>> GetInclude()
        {
            Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>> expr = x => x.Include(i => i.Audience).Include(c => c.Subject).Include(a => a.Lecturers).Include(b => b.Groups);
            return expr;
        }

        public ScheduleService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public IEnumerable<Lesson> GetLessonsAsync() 
        {
            var include = GetInclude();
            var lessons = _repositoryWrapper.LessonRepository.Includer(include);
            return lessons.Result;
        }
    }
}