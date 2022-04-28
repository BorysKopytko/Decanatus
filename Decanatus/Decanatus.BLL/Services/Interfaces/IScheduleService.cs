using Decanatus.DAL.Models;

namespace Decanatus.BLL.Services.Interfaces
{
    public interface IScheduleService
    {
        IEnumerable<Lesson> GetLessonsAsync();
    }
}
