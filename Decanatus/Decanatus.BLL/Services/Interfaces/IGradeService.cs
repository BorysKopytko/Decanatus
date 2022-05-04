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
    public interface IGradeService
    {
        Func<IQueryable<Grade>, IIncludableQueryable<Grade, object>> GetInclude();

        IEnumerable<Grade> GetAllGrades();

        IEnumerable<Grade> GetGradesByStudentId(int id);

        Grade GetGradeById(int id);

        Task<bool> UpdateGradeAsync(Grade grade);
    }
}
