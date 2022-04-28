using Decanatus.DAL.Data;
using Decanatus.DAL.Models;
using Decanatus.DAL.Repositories.Interfaces;

namespace Decanatus.DAL.Repositories.Realizations
{
    public class GroupRepository : GenericRepository<Group>, IGroupRepository
    {
        public GroupRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
        }
    }
}
