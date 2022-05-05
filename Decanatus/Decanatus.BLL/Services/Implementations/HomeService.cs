using Decanatus.BLL.Services.Interfaces;
using Decanatus.DAL.Models;
using Decanatus.DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Decanatus.BLL.Services.Implementations
{
    public class HomeService : IHomeService
    {
        private readonly IRepositoryWrapper _repositoryWrapper;

        public HomeService(IRepositoryWrapper repositoryWrapper)
        {
            _repositoryWrapper = repositoryWrapper;
        }

        public Func<IQueryable<Student>, IIncludableQueryable<Student, object>> GetInclude()
        {
            Func<IQueryable<Student>, IIncludableQueryable<Student, object>> expr =
                x => x.Include(student => student.Group)
                .ThenInclude(group => group.Speciality)
                .ThenInclude(speciality => speciality.Faculty)
                .Include(student => student.Grades)
                .ThenInclude(grade => grade.Subject)
                .Include(student => student.Group)
                .ThenInclude(group => group.Lessons)
                .ThenInclude(lesson => lesson.LessonNumber)
                .Include(student => student.Group)
                .ThenInclude(group => group.Lessons)
                .ThenInclude(lesson => lesson.Subject)
                .Include(student => student.Group)
                .ThenInclude(group => group.Lessons)
                .ThenInclude(lesson => lesson.Audience)
                .Include(student => student.Group)
                .ThenInclude(group => group.Lessons)
                .ThenInclude(lesson => lesson.Lecturers);
            return expr;
        }

        public Student GetStudent(int id)
        {
            var include = GetInclude();
            var students = _repositoryWrapper.StudentRepository.GetData(null, null, null, include);
            var student = students.Result.FirstOrDefault(student => student.Id == id);

            return student;
        }
    }
}
