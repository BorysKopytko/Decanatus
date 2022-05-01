using Decanatus.BLL.ViewModels;
using Decanatus.DAL.Models;

namespace Decanatus.BLL.Services.Interfaces
{
    public interface IScheduleService
    {

        void AddNewLessonAsync(Lesson lesson);

        Task<IEnumerable<Lesson>> GetStudentLessonsAsync(string dayType);
        Task<IEnumerable<Lesson>> GetLessonsAsync();
        Lesson FindLessonAsync(int? id);
        LessonViewModel GetLessonViewModel(int? id);
        Task <bool> UpdateLessonAsync(LessonViewModel obj);
    }
}
