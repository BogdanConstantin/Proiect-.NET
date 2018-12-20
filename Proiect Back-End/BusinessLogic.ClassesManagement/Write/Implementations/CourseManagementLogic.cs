using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessLogic.ClassesManagement.Write.Implementations
{
    using BusinessLogic.ClassesManagement.Write.Abstractions;

    using DataAccess.ClassesManagement.Write.Abstractions;

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
