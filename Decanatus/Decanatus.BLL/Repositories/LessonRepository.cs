using Decanatus.BLL.Interfaces;
using Decanatus.DAL.Data;
using Decanatus.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decanatus.BLL.Repositories
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
