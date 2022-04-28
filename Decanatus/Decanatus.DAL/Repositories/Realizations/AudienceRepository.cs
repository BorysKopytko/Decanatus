using Decanatus.DAL.Data;
using Decanatus.DAL.Models;
using Decanatus.DAL.Repositories.Interfaces;

namespace Decanatus.DAL.Repositories.Realizations
{
    public class AudienceRepository : GenericRepository<Audience>, IAudienceRepository
    {
        public AudienceRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
