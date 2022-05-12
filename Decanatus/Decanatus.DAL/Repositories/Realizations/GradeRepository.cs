using Decanatus.DAL.Data;
using Decanatus.DAL.Models;
using Decanatus.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Decanatus.DAL.Repositories.Realizations
{
    public class GradeRepository : GenericRepository<Grade>, IGradeRepository
    {
        private readonly DbSet<Grade> _grade;
        public GradeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _grade = dbContext.Set<Grade>();
        }
    }
}
