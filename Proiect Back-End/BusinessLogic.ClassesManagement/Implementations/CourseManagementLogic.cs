namespace BusinessLogic.ClassesManagement.Implementations
{
    using System;

    using BusinessLogic.ClassesManagement.Abstractions;

    using DataAccess.ClassesManagement.Abstractions;

    using Entities.ClassesManagement;

    using Models.ClassesManagement;

    public class CourseManagementLogic : BaseLogic, ICourseManagementLogic
    {
        public CourseManagementLogic(IRepository repository)
            : base(repository)
        {
        }

        public void Create(ManagementDto courseDto)
        {
            var newCourse = new CourseManagement()
            {
                ClassId = courseDto.ClassId,
                EntityId = Guid.NewGuid(),
                AuthorId = Guid.NewGuid(),
                UserId = courseDto.UserId,
                UserPosition = courseDto.UserPosition
                // load managed course when read is done
            };

            _repository.Insert(newCourse);
            _repository.Save();
        }
    }
}
