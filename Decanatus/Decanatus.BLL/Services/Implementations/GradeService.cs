using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Decanatus.BLL.Interfaces;
using Decanatus.BLL.Services.Interfaces;
using Decanatus.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Decanatus.BLL.Services.Implementations
{
    public class GradeService : IGradeService
    {
        private readonly IGradeRepository _gradeRepository;

        public GradeService(IGradeRepository gradeRepository)
        {
            _gradeRepository = gradeRepository;
        }

        public Func<IQueryable<Grade>, IIncludableQueryable<Grade, object>> GetInclude()
        {
            Func<IQueryable<Grade>, IIncludableQueryable<Grade, object>> expr = 
                x => x.Include(grade => grade.Student)
                .ThenInclude(student => student.Group)
                .ThenInclude(group => group.Speciality)
                .ThenInclude(speciality => speciality.Faculty)
                .Include(grade => grade.Subject);
            return expr;
        }

        public Expression<Func<Grade, Grade>> GetSelector()
        {
            Expression<Func<Grade, Grade>> expr = x => x;
            return expr;
        }

        public IEnumerable<Grade> GetAllGrades()
        {
            var include = GetInclude();
            var grades = _gradeRepository.Includer(include);

            return grades.Result;
        }
    }
}
