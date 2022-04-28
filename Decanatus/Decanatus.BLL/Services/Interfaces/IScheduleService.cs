using Decanatus.BLL.ViewModels;
using Decanatus.DAL.Models;

namespace Decanatus.BLL.Services.Interfaces
{
    public interface IScheduleService
    {
        IEnumerable<Lesson> GetLessonsAsync();
        Lesson FindLessonAsync(int? id);
        LessonViewModel GetLessonViewModel(int? id);
    }
}
