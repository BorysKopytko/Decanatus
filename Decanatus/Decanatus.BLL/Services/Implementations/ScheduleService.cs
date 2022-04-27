using Decanatus.BLL.Interfaces;
using Decanatus.BLL.Services.Interfaces;
using Decanatus.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Decanatus.BLL.Services
{
    public class ScheduleService: IScheduleService
    {
        private readonly ILessonRepositoryAsync _lessonRepository;

        private Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>> GetInclude()
        {
            Func<IQueryable<Lesson>, IIncludableQueryable<Lesson, object>> expr = x => x.Include(i => i.Audience).Include(c => c.Subject).Include(a => a.Lecturers).Include(b => b.Groups);
            return expr;
        }

        public ScheduleService(ILessonRepositoryAsync lessonRepository)
        {
            _lessonRepository = lessonRepository;
        }

        public IEnumerable<Lesson> GetLessonsAsync() 
        {
            var include = GetInclude();
            var lessons = _lessonRepository.Includer(include);
            return lessons.Result;
        }
    }
}