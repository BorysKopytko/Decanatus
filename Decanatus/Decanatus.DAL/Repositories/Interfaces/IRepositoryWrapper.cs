
namespace Decanatus.DAL.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IAudienceRepository AudienceRepository { get; }

        IFacultyRepository FacultyRepository { get; }

        IGradeRepository GradeRepository { get; }

        IGroupRepository GroupRepository { get; }

        ILecturerRepository LecturerRepository { get; }

        ILessonRepository LessonRepository { get; }

        ISpecialityRepository SpecialityRepository { get; }

        IStudentRepository StudentRepository { get; }

        ISubjectRepository SubjectRepository { get; }

        ILessonNumberRepository LessonNumberRepository { get; }
        void Save();

        Task SaveAsync();
    }
}
