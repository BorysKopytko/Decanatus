using Decanatus.DAL.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decanatus.DAL.Models
{
    public class LessonGroup :Entity
    {
        public int LessonId { get; set; }
        public int GroupId { get; set; }

        public Lesson Lesson { get; set; }
        public Group Group { get; set; }    
    }
}
