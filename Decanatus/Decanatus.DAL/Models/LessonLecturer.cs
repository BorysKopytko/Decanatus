using Decanatus.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
