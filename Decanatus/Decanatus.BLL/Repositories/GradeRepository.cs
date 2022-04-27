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
    public class GradeRepository : GenericRepository<Grade>, IGradeRepository
    {
        private readonly DbSet<Grade> _grade;

        public GradeRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _grade = dbContext.Set<Grade>();
        }
    }
}
