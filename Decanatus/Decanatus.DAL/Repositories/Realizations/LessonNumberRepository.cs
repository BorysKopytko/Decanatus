using Decanatus.DAL.Data;
using Decanatus.DAL.Models;
using Decanatus.DAL.Repositories.Interfaces;

namespace Decanatus.DAL.Repositories.Realizations
{
    public class LessonNumberRepository : GenericRepository<LessonNumber>, ILessonNumberRepository 
    {
        public LessonNumberRepository(ApplicationDbContext dbContext) : base(dbContext)
        {

        }
    }
}
