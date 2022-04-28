
namespace Decanatus.DAL.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IGradeRepository GradeRepository { get; }
        ILessonRepository LessonRepository { get; }
        IStudentRepository StudentRepository { get; }
        ILessonNumberRepository LessonNumberRepository { get; }
        void Save();

        Task SaveAsync();
    }
}
