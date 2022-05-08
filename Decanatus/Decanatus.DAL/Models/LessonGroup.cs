using Decanatus.DAL.Abstractions;

namespace Decanatus.DAL.Models
{
    public class LessonGroup : Entity
    {
        public int LessonId { get; set; }

        public int GroupId { get; set; }

        public Lesson Lesson { get; set; }

        public Group Group { get; set; }
    }
}
