using Decanatus.DAL.Data;
using Decanatus.DAL.Models;
using Decanatus.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Decanatus.DAL.Repositories.Realizations
{
    public class LessonRepository : GenericRepository<Lesson>, ILessonRepository
    {
        private readonly DbSet<Lesson> _lesson;
        public LessonRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _lesson = dbContext.Set<Lesson>();
        }
    }
}
