using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Decanatus.BLL.ViewModels;
using Decanatus.DAL.Models;
using Microsoft.EntityFrameworkCore.Query;

namespace Decanatus.BLL.Services.Interfaces
{
    public interface IGradeService
    {
        Func<IQueryable<Grade>, IIncludableQueryable<Grade, object>> GetInclude();

        Func<IQueryable<Lecturer>, IIncludableQueryable<Lecturer, object>> GetIncludeLecturer();

        IEnumerable<Grade> GetAllGrades();

        IEnumerable<Grade> GetGradesByStudentId(int id);

        Grade GetGradeById(int id);

        Task<bool> UpdateGradeAsync(Grade grade);

        Task<bool> DeleteGradeAsync(int id);

        GradeViewModel CreateGradeViewModel(int id);

        GradeViewModel CreateGradeViewModel(int lecturerId, int subjectId);

        Task AddGrades(GradeViewModel gradeViewModel);
    }
}
