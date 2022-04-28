using Decanatus.DAL.Data;
using Decanatus.DAL.Models;
using Decanatus.DAL.Repositories.Interfaces;

namespace Decanatus.DAL.Repositories.Realizations
{
    public class FacultyRepository : GenericRepository<Faculty>, IFacultyRepository
    {
        public FacultyRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
