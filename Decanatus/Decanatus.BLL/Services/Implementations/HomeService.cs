using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decanatus.BLL.Interfaces;
using Decanatus.BLL.Services.Interfaces;
using Decanatus.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Decanatus.BLL.Services.Implementations
{
    public class HomeService : IHomeService
    {
        private readonly IStudentRepository _studentRepository;

        public HomeService(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
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
            var students = _studentRepository.Includer(include);
            var student = students.Result.FirstOrDefault(student => student.Id == id);

            return student;
        }
    }
}
