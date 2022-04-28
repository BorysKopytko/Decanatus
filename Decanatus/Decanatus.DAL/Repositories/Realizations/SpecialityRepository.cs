using Decanatus.DAL.Data;
using Decanatus.DAL.Models;
using Decanatus.DAL.Repositories.Interfaces;

namespace Decanatus.DAL.Repositories.Realizations
{
    public class SpecialityRepository : GenericRepository<Speciality>, ISpecialityRepository
    {
        public SpecialityRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
