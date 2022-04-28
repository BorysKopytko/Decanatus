
namespace Decanatus.DAL.Repositories.Interfaces
{
    public interface IRepositoryWrapper
    {
        IGradeRepository GradeRepository { get; }
        ILessonRepository LessonRepository { get; }
        IStudentRepository StudentRepository { get; }
        void Save();

        Task SaveAsync();
    }
}
