﻿using Decanatus.BLL.Services.Interfaces;
using Decanatus.DAL.Models;
using Decanatus.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Decanatus.BLL.Services.Implementations
{
    public class GradeService : IGradeService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public GradeService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
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

        public IEnumerable<Grade> GetAllGrades()
        {
            var include = GetInclude();
            var grades = _repositoryWrapper.GradeRepository.GetData(null, null, null, include);

            return grades.Result;
        }

        public IEnumerable<Grade> GetGradesByStudentId(int id)
        {
            var include = GetInclude();
            var filter = FilterGradesByStudentId(id);
            var grades = _repositoryWrapper.GradeRepository.GetData(filter, null, null, include).Result;//Includer(include).Result.Where(grade => grade.StudentId == id);

            return grades;
        }

        private Expression<Func<Grade, bool>> FilterGradesByStudentId(int id)
        {
            Expression<Func<Grade, bool>> searchedGrades = x => x.StudentId == id;
            return searchedGrades;
        }
    }
}
