namespace BusinessLogic.ClassesManagement.Implementations
{
    using System;
    using System.Collections.Generic;
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

        public Course Update(CourseDto courseDto, Guid courseEntityId)
        {
            var course = _repository.GetLastByFilter<Course>(c => c.EntityId == courseEntityId);

            if (course.DeletedDate != null)
            {
                return null;
            }

            course.Id = Guid.NewGuid();
            course.AuthorId = Guid.NewGuid();
            course.CourseTitle = courseDto.CourseTitle;
            course.Semester = courseDto.Semester;
            course.Year = courseDto.Year;

            _repository.Insert(course);
            _repository.Save();

            return course;
        }

        public Course Delete(Guid courseEntityId)
        {
            var course = _repository.GetLastByFilter<Course>(c => c.EntityId == courseEntityId);

            course.Id = Guid.NewGuid();
            course.AuthorId = Guid.NewGuid();
            course.DeletedDate = DateTime.Now;

            _repository.Insert(course);
            _repository.Save();

            return course;
        }

        public CourseDto GetById(Guid courseEntityId)
        {
            var course = _repository.GetLastByFilter<Course>(c => c.EntityId == courseEntityId);

            var courseDto = new CourseDto
            {
                CourseTitle = course.CourseTitle,
                Year = course.Year,
                Semester = course.Semester
            };

            return courseDto;
        }

        public ICollection<CourseDto> GetAll()
        {
            List<CourseDto> courseDtos = new List<CourseDto>();

            var courses = _repository.GetAll<Course>();

            foreach (var course in courses)
            {
                var courseDto = new CourseDto
                {
                    CourseTitle = course.CourseTitle,
                    Year = course.Year,
                    Semester = course.Semester
                };

                courseDtos.Add(courseDto);
            }

            return courseDtos;
        }
    }
}
