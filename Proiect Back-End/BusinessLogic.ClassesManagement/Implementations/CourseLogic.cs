namespace BusinessLogic.ClassesManagement.Implementations
{
    using System;

    using BusinessLogic.ClassesManagement.Abstractions;

    using DataAccess.ClassesManagement.Abstractions;

    using Entities.ClassesManagement;

    using Models.ClassesManagement;

    public class CourseLogic : BaseLogic, ICourseLogic
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

        public void Update(CourseDto courseDto, Guid courseEntityId)
        {
            var course = _repository.GetLastByFilter<Course>(c => c.EntityId == courseEntityId);

            if (course.DeletedDate != null)
            {
                return;
            }

            course.Id = Guid.NewGuid();
            course.AuthorId = Guid.NewGuid();
            course.CourseTitle = courseDto.CourseTitle;
            course.Semester = courseDto.Semester;
            course.Year = courseDto.Year;

            _repository.Insert(course);
            _repository.Save();
        }

        public void Delete(Guid courseEntityId)
        {
            var course = _repository.GetLastByFilter<Course>(c => c.EntityId == courseEntityId);

            course.Id = Guid.NewGuid();
            course.AuthorId = Guid.NewGuid();
            course.DeletedDate = DateTime.Now;

            _repository.Insert(course);
            _repository.Save();
        }
    }
}
