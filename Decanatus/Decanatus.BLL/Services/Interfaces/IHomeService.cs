using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Decanatus.DAL.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace Decanatus.BLL.Services.Interfaces
{
    public interface IHomeService
    {
        Func<IQueryable<Student>, IIncludableQueryable<Student, object>> GetInclude();

        public Student GetStudent(int id);
    }
}
