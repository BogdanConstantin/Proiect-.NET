using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.ClassesManagement
{
    public class Course: BaseEntity
    {
        public string CourseTitle { get; set; }
        public int Year { get; set; }
        public int Semester { get; set; }
    }
}
