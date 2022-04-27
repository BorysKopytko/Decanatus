using Decanatus.BLL.Interfaces;
using Decanatus.DAL.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Decanatus.BLL.Services.Interfaces
{
    public interface IScheduleService
    {
        IEnumerable<Lesson> GetLessonsAsync();
    }
}
