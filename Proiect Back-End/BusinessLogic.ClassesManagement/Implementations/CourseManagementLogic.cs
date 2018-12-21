
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

        public void Create(ManagementDto courseManagementDto)
        {
            var newCourse = new CourseManagement()
            {
                ClassId = courseManagementDto.ClassId,
                EntityId = Guid.NewGuid(),
                AuthorId = Guid.NewGuid(),
                UserId = courseManagementDto.UserId,
                UserPosition = courseManagementDto.UserPosition
                // load managed course when read is done
            };

            _repository.Insert(newCourse);
            _repository.Save();
        }

        public void Update(ManagementDto courseManagementDto, Guid courseManagementEntityId)
        {
            var courseManagement = _repository.GetLastByFilter<CourseManagement>(c => c.EntityId == courseManagementEntityId);

            if (courseManagement.DeletedDate != null)
            {
                return;
            }

            courseManagement.Id = Guid.NewGuid();
            courseManagement.AuthorId = Guid.NewGuid();
            courseManagement.ClassId = courseManagementDto.ClassId;
            courseManagement.UserId = courseManagementDto.UserId;
            courseManagement.UserPosition = courseManagementDto.UserPosition;

            _repository.Insert(courseManagement);
            _repository.Save();
        }

        public void Delete(Guid courseManagementEntityId)
        {
            var courseManagement = _repository.GetLastByFilter<CourseManagement>(c => c.EntityId == courseManagementEntityId);

            courseManagement.Id = Guid.NewGuid();
            courseManagement.AuthorId = Guid.NewGuid();
            courseManagement.DeletedDate = DateTime.Now;

            _repository.Insert(courseManagement);
            _repository.Save();
        }
    }
}
