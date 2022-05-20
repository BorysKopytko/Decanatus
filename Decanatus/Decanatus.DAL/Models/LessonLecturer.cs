using Decanatus.DAL.Abstractions;

namespace Decanatus.DAL.Models
{
    public class LessonLecturer : Entity
    {
        public int LessonId { get; set; }

        public int LecturerId { get; set; }

        public Lesson Lesson { get; set; }
        
        public Lecturer Lecturer { get; set; }
    }
}
