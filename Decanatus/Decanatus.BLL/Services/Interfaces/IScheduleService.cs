using Decanatus.BLL.ViewModels;
using Decanatus.DAL.Models;

namespace Decanatus.BLL.Services.Interfaces
{
    public interface IScheduleService
    {
        Task<IEnumerable<Lesson>> GetLessonsAsync();

        void AddNewLessonAsync(Lesson lesson);

        Task<IEnumerable<Lesson>> GetStudentLessonsAsync(string dayType);
        IEnumerable<Lesson> GetLessonsAsync();
        Lesson FindLessonAsync(int? id);
        LessonViewModel GetLessonViewModel(int? id);
    }
}
