using Decanatus.DAL.Models;

namespace Decanatus.BLL.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<IEnumerable<Lesson>> GetLessonsAsync();

        void AddNewLessonAsync(Lesson lesson);

        Task<IEnumerable<Lesson>> GetStudentLessonsAsync(string dayType);
    }
}
