
using System.Collections.Generic;

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
                UserPosition = (UserPosition)Enum.Parse(typeof(UserPosition), courseManagementDto.UserPosition)
                // load managed course when read is done
            };

            _repository.Insert(newCourse);
            _repository.Save();
        }

        public CourseManagement Update(ManagementDto courseManagementDto, Guid courseManagementEntityId)
        {
            var courseManagement = _repository.GetLastByFilter<CourseManagement>(c => c.EntityId == courseManagementEntityId);

            if (courseManagement == null || courseManagement.DeletedDate != null)
            {
                return null;
            }

            courseManagement.Id = Guid.NewGuid();
            courseManagement.AuthorId = Guid.NewGuid();
            courseManagement.ClassId = courseManagementDto.ClassId;
            courseManagement.UserId = courseManagementDto.UserId;
            courseManagement.UserPosition = (UserPosition)Enum.Parse(typeof(UserPosition), courseManagementDto.UserPosition);

            _repository.Insert(courseManagement);
            _repository.Save();

            return courseManagement;
        }

        public CourseManagement Delete(Guid courseManagementEntityId)
        {
            var courseManagement = _repository.GetLastByFilter<CourseManagement>(c => c.EntityId == courseManagementEntityId);

            if (courseManagement == null || courseManagement.DeletedDate != null)
            {
                return null;
            }

            courseManagement.Id = Guid.NewGuid();
            courseManagement.AuthorId = Guid.NewGuid();
            courseManagement.DeletedDate = DateTime.Now;

            _repository.Insert(courseManagement);
            _repository.Save();

            return courseManagement;
        }

        public ManagementDto GetById(Guid courseManagementEntityId)
        {
            var courseManagement = _repository.GetLastByFilter<CourseManagement>(c => c.EntityId == courseManagementEntityId);

            if (courseManagement == null || courseManagement.DeletedDate != null)
            {
                return null;
            }

            var courseManagementDto = new ManagementDto
            {
                ClassId = courseManagement.ClassId,
                UserId = courseManagement.UserId,
                UserPosition = courseManagement.UserPosition.ToString()
            };

            return courseManagementDto;
        }

        public ICollection<ManagementDto> GetAll()
        {
            List<ManagementDto> courseManagementDtos = new List<ManagementDto>();

            var courseManagements = _repository.GetAll<CourseManagement>();

            foreach (var courseManagement in courseManagements)
            {
                var courseManagementDto = new ManagementDto
                                    {
                                        ClassId = courseManagement.ClassId,
                                        UserId = courseManagement.UserId,
                                        UserPosition = courseManagement.UserPosition.ToString()
                                    };

                courseManagementDtos.Add(courseManagementDto);

            }


            return courseManagementDtos;
        }
    }
}
