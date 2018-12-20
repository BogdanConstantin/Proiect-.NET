using System;

namespace BusinessLogic.ClassesManagement.Write.Implementations
{
    using BusinessLogic.ClassesManagement.Write.Abstractions;

    using DataAccess.ClassesManagement.Write.Abstractions;

    using Entities.ClassesManagement;

    using Models.ClassesManagement;

    public class CourseLogic:BaseLogic, ICourseLogic
    {
        public CourseLogic(IRepository repository)
            : base(repository)
        {
        }

        public void Create(CourseDto courseDto)
        {
            var newCourse = new Course
                                {
                                    AuthorId = Guid.NewGuid(),
                                    CourseTitle = courseDto.CourseTitle,
                                    EntityId = Guid.NewGuid(),
                                    Semester = courseDto.Semester,
                                    Year = courseDto.Year
                                };

            _repository.Insert(newCourse);
            _repository.Save();
        }
    }
}
