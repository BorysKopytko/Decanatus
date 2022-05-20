using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Decanatus.DAL.Abstractions;

namespace Decanatus.DAL.Models
{
    public class LessonNumber : Entity
    {
        public int Number { get; set; }

        public TimeSpan StartTime { get; set; }

        public TimeSpan EndTime { get; set; }
    }
}
