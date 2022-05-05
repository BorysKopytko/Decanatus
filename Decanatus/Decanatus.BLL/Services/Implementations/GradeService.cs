using Decanatus.BLL.Services.Interfaces;
using Decanatus.DAL.Models;
using Decanatus.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Decanatus.BLL.Services.Implementations
{
    public class GradeService : IGradeService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IUnitOfWork _unitOfWork;

        public GradeService(IRepositoryWrapper repositoryWrapper, IUnitOfWork unitOfWork)
        {
            _repositoryWrapper = repositoryWrapper;
            _unitOfWork = unitOfWork;
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
            var grades = _repositoryWrapper.GradeRepository.Includer(include);

            return grades.Result;
        }

        public IEnumerable<Grade> GetGradesByStudentId(int id)
        {
            var include = GetInclude();
            var grades = _repositoryWrapper.GradeRepository.Includer(include).Result.Where(grade => grade.StudentId == id);

            return grades;
        }

        public Grade GetGradeById(int id)
        {
            var include = GetInclude();
            var grade = _repositoryWrapper.GradeRepository.Includer(include).Result.FirstOrDefault(grade => grade.Id == id);

            return grade;
        }

        public async Task<bool> UpdateGradeAsync(Grade grade)
        {
            var include = GetInclude();
            var _grade = _repositoryWrapper.GradeRepository.Includer(include).Result.FirstOrDefault(x => x.Id == grade.Id);

            _grade.Amount = grade.Amount;
            _grade.MaxAmount = grade.MaxAmount;
            _grade.GradeType = grade.GradeType;
            _grade.Description = grade.Description;
            _grade.Date = grade.Date;

            await _repositoryWrapper.GradeRepository.UpdateAsync(_grade);
            await _unitOfWork.Commit();

            return true;
        }

        public async Task<bool> DeleteGradeAsync(int id)
        {
            var grade = await _repositoryWrapper.GradeRepository.GetByIdAsync(id);

            await _repositoryWrapper.GradeRepository.DeleteAsync(grade);
            await _unitOfWork.Commit();

            return true;
        }
    }
}
