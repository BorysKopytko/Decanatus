using Decanatus.BLL.Services.Interfaces;
using Decanatus.BLL.ViewModels;
using Decanatus.DAL.Data;
using Decanatus.DAL.Models;
using Decanatus.DAL.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;

namespace Decanatus.BLL.Services.Implementations
{
    public class GradeService : IGradeService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly ApplicationDbContext _context;

        public GradeService(IRepositoryWrapper repositoryWrapper, IUnitOfWork unitOfWork, ApplicationDbContext context)
        {
            _repositoryWrapper = repositoryWrapper;
            _unitOfWork = unitOfWork;
            _context = context;
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

        public Func<IQueryable<Lecturer>, IIncludableQueryable<Lecturer, object>> GetIncludeLecturer()
        {
            Func<IQueryable<Lecturer>, IIncludableQueryable<Lecturer, object>> expr =
                x => x.Include(lecturer => lecturer.Lessons)
                .ThenInclude(lesson => lesson.Groups)
                .ThenInclude(group => group.Students)
                .Include(lecturer => lecturer.Lessons)
                .ThenInclude(lesson => lesson.Subject);
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

        public Grade GetGradeById(int id)
        {
            var include = GetInclude();
            var grade = _repositoryWrapper.GradeRepository.GetData(null, null, null, include).Result.FirstOrDefault(grade => grade.Id == id);

            return grade;
        }

        public GradeViewModel CreateGradeViewModel(int id)
        {
            var include = GetIncludeLecturer();
            var lecturer = _repositoryWrapper.LecturerRepository.GetData(null, null, null, include).Result.FirstOrDefault(lecturer => lecturer.Id == id);
            var gradeViewModel = new GradeViewModel
            {
                LecturerId = lecturer.Id,
                Subjects = lecturer.Lessons.Select(lesson => new SelectListItem { Value = lesson.SubjectId.ToString(), Text = lesson.Subject.Name.ToString() }).ToList(),
            };

            return gradeViewModel;
        }

        public GradeViewModel CreateGradeViewModel(int lecturerId, int subjectId)
        {
            var include = GetIncludeLecturer();
            var lecturer = _repositoryWrapper.LecturerRepository.GetData(null, null, null, include).Result.FirstOrDefault(lecturer => lecturer.Id == lecturerId);
            var lessons = lecturer.Lessons.Where(lesson => lesson.SubjectId == subjectId);
            var groups = new HashSet<Group>();

            foreach (var lesson in lessons.ToList())
            {
                foreach (var group in lesson.Groups)
                {
                    groups.Add(group);
                }
            }

            var gradeViewModel = new GradeViewModel
            {
                SubjectId = subjectId,
                Groups = groups.Select(group => new SelectListItem { Value = group.Id.ToString(), Text = group.Name.ToString() }).ToList(),
            };

            return gradeViewModel;
        }

        public async Task AddGrades(GradeViewModel gradeViewModel)
        {
            foreach (var groupId in gradeViewModel.GroupsId)
            {
                var students = _repositoryWrapper.StudentRepository.GetAllAsync().Result.Where(student => student.GroupId == groupId);
                foreach (var item in students)
                {
                    var grade = new Grade();
                    grade.MaxAmount = gradeViewModel.MaxAmount;
                    grade.Student = _repositoryWrapper.StudentRepository.GetAllAsync().Result.FirstOrDefault(student => student.Id == item.Id);
                    grade.GradeType = gradeViewModel.GradeType;
                    grade.Date = gradeViewModel.Date;
                    grade.Amount = null;
                    grade.Subject = _repositoryWrapper.SubjectRepository.GetAllAsync().Result.FirstOrDefault(subject => subject.Id == gradeViewModel.SubjectId);
                    grade.Description = string.Empty;
                    await _repositoryWrapper.GradeRepository.AddAsync(grade);
                }
            }

            await _unitOfWork.Commit();
        }

        public async Task<bool> UpdateGradeAsync(Grade grade)
        {
            var include = GetInclude();
            var _grade = _repositoryWrapper.GradeRepository.GetData(null, null, null, include).Result.FirstOrDefault(x => x.Id == grade.Id);

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
