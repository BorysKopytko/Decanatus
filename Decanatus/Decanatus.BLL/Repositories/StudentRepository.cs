using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decanatus.BLL.Interfaces;
using Decanatus.DAL.Data;
using Decanatus.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace Decanatus.BLL.Repositories
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        private readonly DbSet<Student> _student;

        public StudentRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _student = dbContext.Set<Student>();
        }
    }
}
